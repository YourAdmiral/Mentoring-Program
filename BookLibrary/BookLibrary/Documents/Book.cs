using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Documents
{
    public class Book : Document
    {
        public string ISBN { get; private set; }

        public int NumberOfPages { get; private set; }

        public string Publisher { get; private set; }
    }
}
