using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Caching;
using BookLibrary.Documents;
using BookLibrary.Serializer;

namespace BookLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cache = new CachedDocuments();
            var cachedDocuments = (List<Document>) cache.GetAvailableDocuments();

            var library = new Library();

            var numbers = new List<string>();

            foreach (var document in cachedDocuments)
            {
                numbers.Add(document.Number);
            }

            var requiredDocuments = library.GetDocumentsByNumbers(numbers);

            var serializer = new SerializerJson<Document>();

            foreach (var document in requiredDocuments)
            {
                var documentType = document.GetType();

                var jsonFile = $"{documentType.Name}_#{document.Number}";
                
                serializer.Serialize(
                    document, 
                    jsonFile);
            }
        }
    }
}
