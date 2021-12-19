using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemWithTests
{
    internal class ElementInfoEventArgs
    {
        public string Message { get; private set; }

        public FileSystemInfo ElementInfo { get; private set; }

        public ElementInfoEventArgs(string message, FileSystemInfo elementInfo)
        {
            this.Message = message;
            this.ElementInfo = elementInfo;
        }
    }
}
