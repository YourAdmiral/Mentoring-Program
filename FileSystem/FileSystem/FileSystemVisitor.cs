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

        public FileSystemVisitor(string dir)
        {
            _dir = new DirectoryInfo(dir);
        }

        public IEnumerable<FileSystemInfo> GetFilesInfo()
        {
            return GetFilesInfoFromDir(_dir);
        }

        public IEnumerable<FileSystemInfo> GetFilesInfoFromDir(DirectoryInfo dir)
        {
            DirectoryInfo subDir;

            foreach (var fileInfo in dir.EnumerateFileSystemInfos())
            {
                subDir = fileInfo as DirectoryInfo;

                yield return fileInfo;

                if (subDir != null)
                {
                    foreach (var subFile in GetFilesInfoFromDir(subDir))
                    {
                        yield return subFile;
                    }
                }
            }
        }
    }
}
