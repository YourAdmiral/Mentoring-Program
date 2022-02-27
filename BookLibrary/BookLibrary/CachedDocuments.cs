using BookLibrary.Documents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class CachedDocuments
    {
        private const string CacheKey = "availableDocuments";

        public IEnumerable GetAvailableDocuments()
        {
            ObjectCache cache = MemoryCache.Default;

            if (cache.Contains(CacheKey))
            {
                return (IEnumerable)cache.Get(CacheKey);
            }
            else
            {
                var availableStocks = this.GetDefaultDocuments();

                var policy = new CacheItemPolicy
                {
                    Priority = CacheItemPriority.NotRemovable,
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10)
                };

                cache.Add(
                    CacheKey, 
                    availableStocks, 
                    policy);

                return availableStocks;
            }
        }

        private IEnumerable GetDefaultDocuments()
        {
            #region Const

            #region Book const

            const string bookNumber = "1-2-45";
            const string bookTitle = "CLR Via C#";
            const string bookAuthor = "Jeffrey Richter";
            const string bookPublisher = "Microsoft Press";
            const int bookNumberOfPages = 1000;
            List<string> bookAuthors = new List<string>() { bookAuthor };
            DateTime bookDatePublished = DateTime.Now;

            #endregion

            #region LocalizedBook const

            const string localizedBookNumber = "3-9-674";
            const string localizedBookTitle = "C# 4.0 The Complete Reference";
            const string localizedBookAuthor = "Herbert Schildt";
            const string localizedBookPublisher = "Microsoft Press";
            const string localizedBookLocalPulisher = "Belarus press";
            const string countryOfLocalization = "Belarus";
            const int localizedBookNumberOfPages = 883;
            List<string> localizedBookAuthors = new List<string>() { localizedBookAuthor };
            DateTime localizedBookDatePublished = DateTime.Now;

            #endregion

            #region Patent const

            const string patentNumber = "354-812";
            const string patentTitle = "Very important thing";
            const string firstPatentAuthor = "Dave Norton";
            const string secondPatentAuthor = "James Rothschild";
            List<string> patentAuthors = new List<string>()
            {
                firstPatentAuthor,
                secondPatentAuthor
            };
            DateTime patentDatePublished = DateTime.Now;
            DateTime expirationDate = DateTime.Now.AddYears(2);

            #endregion

            #region Magazine const

            const string magazineNumber = "34143232";
            const string magazineTitle = "Daily News";
            const string magazinePublisher = "CNN";
            DateTime magazineDatePublished = DateTime.Now;

            #endregion

            #endregion

            #region Documents

            var book = new Book(
                bookNumber,
                bookTitle,
                bookAuthors,
                bookDatePublished,
                bookNumberOfPages,
                bookPublisher);

            var localizedBood = new LocalizedBook(
                localizedBookNumber,
                localizedBookTitle,
                localizedBookAuthors,
                localizedBookDatePublished,
                localizedBookNumberOfPages,
                localizedBookPublisher,
                localizedBookLocalPulisher,
                countryOfLocalization);

            var patent = new Patent(
                patentNumber,
                patentTitle,
                patentAuthors,
                patentDatePublished,
                expirationDate);

            var magazine = new Magazine(
                magazineNumber,
                magazineTitle,
                magazineDatePublished,
                magazinePublisher);

            var documents = new List<Document>()
            {
                book,
                localizedBood,
                patent,
                magazine
            };

            #endregion

            return documents;
        }
    }
}
