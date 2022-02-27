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
        private List<Document> _documents;

        public Library(List<Document> documents)
        {
            _documents = documents;
        }

        public Document GetDocumentByNumber(string number)
        {
            return _documents.FirstOrDefault(document => document.Number.Equals(number));
        }

        public List<Document> GetDocumentsByNumbers(List<string> numbers)
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
