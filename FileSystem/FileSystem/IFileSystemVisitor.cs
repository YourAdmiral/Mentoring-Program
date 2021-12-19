using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    internal interface IFileSystemVisitor
    {
        public IEnumerable<FileSystemInfo> GetFilesInfo();

        public IEnumerable<FileSystemInfo> GetFilesInfoFromDir(DirectoryInfo dir);
    }
}
