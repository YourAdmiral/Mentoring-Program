using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Documents
{
    public abstract class Document
    {
        public string Title { get; private set; }

        public List<string> Authors { get; private set; }

        public DateTime DatePublished { get; private set; }
    }
}
