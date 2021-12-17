using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    internal class FileSystemVisitor : IFileSystemVisitor
    {
        private DirectoryInfo _dir;

        private Predicate<string> _filter;

        private delegate void NotifyHandler(string message);

        private delegate void ElementHandler(object sender, ElementInfoEventArgs e);

        private event NotifyHandler Notify;

        private event ElementHandler ElementFound;

        public FileSystemVisitor(
            string dir,
            Predicate<string> filter = null)
        {
            _dir = new DirectoryInfo(dir);
            _filter = filter;
            Notify += DisplayMessage;
            ElementFound += DisplayElementInfo;
        }

        public IEnumerable<FileSystemInfo> GetFilesInfo()
        {
            Notify?.Invoke("Search started");

            return GetFilesInfoFromDir(_dir);
        }

        public IEnumerable<FileSystemInfo> GetFilesInfoFromDir(DirectoryInfo dir)
        {
            DirectoryInfo subDir;

            foreach (var fileInfo in dir.EnumerateFileSystemInfos())
            {
                subDir = fileInfo as DirectoryInfo;

                if (_filter == null)
                {
                    if (subDir != null)
                    {
                        ElementFound?.Invoke(this, new ElementInfoEventArgs($"Founded directory {subDir.Name}", subDir));
                    }

                    yield return fileInfo;
                }
                else if (_filter(fileInfo.Name))
                {
                    if (subDir != null)
                    {
                        ElementFound?.Invoke(this, new ElementInfoEventArgs($"Filtered directory founded {subDir.Name}", subDir));
                    }

                    yield return fileInfo;
                }

                if (subDir != null)
                {
                    foreach (var subFile in GetFilesInfoFromDir(subDir))
                    {
                        if (!File.GetAttributes(subFile.FullName).HasFlag(FileAttributes.Directory))
                        {
                            if (_filter == null)
                            {
                                ElementFound?.Invoke(this, new ElementInfoEventArgs($"Founded file {subFile.Name}", subFile));
                            }
                            else if (_filter(subFile.Name))
                            {
                                ElementFound?.Invoke(this, new ElementInfoEventArgs($"Filtered file founded {subFile.Name}", subFile));
                            }
                        }

                        yield return subFile;
                    }
                }
            }

            if (dir.FullName == _dir.FullName)
            {
                Notify?.Invoke("Search finished");
            }
        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void DisplayElementInfo(object sender, ElementInfoEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
