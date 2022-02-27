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
            ChachedDocuments chache = new ChachedDocuments();
            List<Document> chachedDocuments = (List<Document>)chache.GetAvailableDocuments();

            var library = new Library(chachedDocuments);

            var numbers = new List<string>();

            foreach (var document in chachedDocuments)
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
