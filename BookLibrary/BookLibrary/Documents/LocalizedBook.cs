using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Documents
{
    public class LocalizedBook : Book
    {
        public string LocalPublisher { get; private set; }

        public string CountryOfLocalization { get; private set; }

        public LocalizedBook(
            string number, 
            string title,
            List<string> authors, 
            DateTime datePublished, 
            int numberOfPages, 
            string publisher, 
            string localPublisher, 
            string countryOfLocalization)
            : base(
                number, 
                title, 
                authors, 
                datePublished, 
                numberOfPages, 
                publisher)
        {
            LocalPublisher = localPublisher;
            CountryOfLocalization = countryOfLocalization;
        }
    }
}
