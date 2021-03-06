using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Documents
{
    public class Patent : CopyrightDocument
    {
        public DateTime ExpirationDate { get; private set; }

        public Patent(
            string number, 
            string title, 
            List<string> authors, 
            DateTime datePublished,
            DateTime expirationDate)
            : base(
                number, 
                title, 
                authors, 
                datePublished)
        {
            ExpirationDate = expirationDate;
        }
    }
}
