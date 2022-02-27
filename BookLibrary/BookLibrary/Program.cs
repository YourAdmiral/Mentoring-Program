using System;
using System.Collections.Generic;
using System.Globalization;
using BookLibrary.Documents;
using BookLibrary.Serializer;

namespace BookLibrary
{
    internal class Program
    {
        static void Main(string[] args)
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

            var documents = new List<Document>()
            {
                book,
                localizedBood,
                patent
            };

            #endregion

            var library = new Library(documents);

            var numbers = new List<string>()
            {
                bookNumber,
                patentNumber
            };

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
