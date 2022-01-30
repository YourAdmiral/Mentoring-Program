using Dictonary_replacer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace DictionaryReplacerTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Replace_WithEmptyStringAndDictionary_Should_ReturnEmptyString()
        {
            string result;

            string str = "";

            var dictionary = new Dictionary<string, string>();

            result = DictionaryReplacer.Replace(str,dictionary);

            Assert.That(() => result, Is.EqualTo(""));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Replace_WithNullArguments_ThrowsArgumentNullException()
        {
            DictionaryReplacer.Replace(null, null);
        }

        [TestMethod]
        public void Replace_Should_Return_Temporary()
        {
            string result;

            string str = "$temp$";

            var dictionary = new Dictionary<string, string>();

            dictionary.Add("temp", "temporary");

            result = DictionaryReplacer.Replace(str, dictionary);

            Assert.That(() => result, Is.EqualTo("temporary"));
        }

        [TestMethod]
        public void Replace_Should_Return_TextWithReplacedWords()
        {
            string result;

            string str = "$temp$ here comes the name $name$";

            var dictionary = new Dictionary<string, string>();

            dictionary.Add("temp", "temporary");

            dictionary.Add("name", "John Doe");

            result = DictionaryReplacer.Replace(str, dictionary);

            Assert.That(() => result, Is.EqualTo("temporary here comes the name John Doe"));
        }
    }
}
