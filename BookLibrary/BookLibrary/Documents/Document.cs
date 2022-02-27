using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Documents
{
    public abstract class Document
    {
        public string Number { get; set; }

        public string Title { get; private set; }

        public List<string> Authors { get; private set; }

        public DateTime DatePublished { get; private set; }

        public Document(
            string number, 
            string title, 
            List<string> authors, 
            DateTime datePublished)
        {
            Number = number;
            Title = title;
            Authors = authors;
            DatePublished = datePublished;
        }
    }
}
