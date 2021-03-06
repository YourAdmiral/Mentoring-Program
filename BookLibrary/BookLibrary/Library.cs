using BookLibrary.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Library
    {
        private CachedDocuments _cachedDocuments = new CachedDocuments();

        private IList<Document> _documents;

        public Library()
        {
            _documents = (List<Document>)_cachedDocuments.GetAvailableDocuments();
        }

        public Document GetDocumentByNumber(string number)
        {
            return _documents.FirstOrDefault(document => document.Number.Equals(number));
        }

        public IList<Document> GetDocumentsByNumbers(IList<string> numbers)
        {
            var documents = new List<Document>();

            foreach (var number in numbers)
            {
                var document = GetDocumentByNumber(number);

                if (document != null)
                {
                    documents.Add(document);
                }
            }

            return documents;
        }
    }
}
