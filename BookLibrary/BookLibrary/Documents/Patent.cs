using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Documents
{
    public class Patent : Document
    {
        public int Id { get; private set; }

        public DateTime ExpirationDate { get; private set; }
    }
}
