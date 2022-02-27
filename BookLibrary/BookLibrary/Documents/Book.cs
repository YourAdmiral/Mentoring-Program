using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Documents
{
    public class Book : CopyrightDocument
    {
        public int NumberOfPages { get; private set; }

        public string Publisher { get; private set; }

        public Book(
            string number, 
            string title, 
            List<string> authors, 
            DateTime datePublished, 
            int numberOfPages, 
            string publisher) 
            : base(
                number, 
                title, 
                authors, 
                datePublished)
        {
            NumberOfPages = numberOfPages;
            Publisher = publisher;
        }
    }
}
