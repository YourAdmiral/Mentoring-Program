using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Documents
{
    public class CopyrightDocument : Document
    {
        public List<string> Authors { get; private set; }

        public CopyrightDocument(
            string number, 
            string title, 
            List<string> authors, 
            DateTime datePublished) 
            : base(
                number, 
                title, 
                datePublished)
        {
            Authors = authors;
        }
    }
}
