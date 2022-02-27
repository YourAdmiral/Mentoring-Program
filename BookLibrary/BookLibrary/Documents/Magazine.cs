using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Documents
{
    public class Magazine : Document
    {
        public string Publisher { get; private set; }

        public Magazine(
            string number, 
            string title, 
            DateTime datePublished,
            string publisher) 
            : base(
                number, 
                title,  
                datePublished)
        {
            Publisher = publisher;
        }
    }
}
