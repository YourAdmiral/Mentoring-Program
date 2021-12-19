using FileSystemWithTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSystemTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void GetFilesInfoReturnsAllDirectoriesAndFiles()
        {
            var dir = @"C:\Users\Kiryl_Kartashou\Desktop\Files";

            var fileSystemVisitor = new FileSystemVisitor(dir);

            List<FileSystemInfo> elements = new List<FileSystemInfo>();

            List<FileSystemInfo> allElements = new List<FileSystemInfo>()
            {
                new DirectoryInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog"),
                new DirectoryInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog\cat"),
                new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog\file.txt"),
                new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog\file2.txt"),
                new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog\file3.txt"),
                new DirectoryInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog2"),
                new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog2\myfile.txt")
            };

            foreach (var fileInfo in fileSystemVisitor.GetFilesInfo())
            {
                elements.Add(fileInfo);
            }

            CollectionAssert.AreEqual(
                allElements.Select(f => f.FullName).ToList(), 
                elements.Select(f => f.FullName).ToList());
        }

        [TestMethod]
        public void FilterReturnsFile2txt()
        {
            var dir = @"C:\Users\Kiryl_Kartashou\Desktop\Files";

            var fileSystemVisitor = new FileSystemVisitor(dir, file => file.Equals("file2.txt"));

            List<FileSystemInfo> elements = new List<FileSystemInfo>();

            FileInfo filteredFileInfo = new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog\file2.txt");

            foreach (var fileInfo in fileSystemVisitor.GetFilesInfo())
            {
                elements.Add(fileInfo);
            }

            Assert.AreEqual(
                filteredFileInfo.FullName,
                elements.FirstOrDefault().FullName);
        }

        [TestMethod]
        public void CheckExcludedDirectories()
        {
            var dir = @"C:\Users\Kiryl_Kartashou\Desktop\Files";

            var fileSystemVisitor = new FileSystemVisitor(dir);

            List<FileSystemInfo> elementsWithoutExcludedDirectories = new List<FileSystemInfo>()
            {
                new DirectoryInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog\cat"),
                new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog\file.txt"),
                new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog\file2.txt"),
                new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog\file3.txt"),
                new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog2\myfile.txt")
            };

            List<FileSystemInfo> elements = new List<FileSystemInfo>();

            List<DirectoryInfo> excludedDirectories = new List<DirectoryInfo>();

            excludedDirectories.Add(new DirectoryInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog"));

            excludedDirectories.Add(new DirectoryInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog2"));

            foreach (var fileInfo in fileSystemVisitor.GetFilesInfo())
            {
                elements.Add(fileInfo);
            }

            fileSystemVisitor.ExcludeDirectoriesFromList(elements, excludedDirectories);

            CollectionAssert.AreEqual(
                elementsWithoutExcludedDirectories.Select(f => f.FullName).ToList(),
                elements.Select(f => f.FullName).ToList());
        }

        [TestMethod]
        public void CheckExcludedFilesByName()
        {
            var dir = @"C:\Users\Kiryl_Kartashou\Desktop\Files";

            var fileSystemVisitor = new FileSystemVisitor(dir);

            List<FileSystemInfo> elementsWithoutExcludedFiles = new List<FileSystemInfo>()
            {
                new DirectoryInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog"),
                new DirectoryInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog\cat"),
                new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog\file.txt"),
                new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog\file3.txt"),
                new DirectoryInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog2")
            };

            List<FileSystemInfo> elements = new List<FileSystemInfo>();

            List<string> excludedFiles = new List<string>();

            excludedFiles.Add("file2.txt");

            excludedFiles.Add("myfile.txt");

            fileSystemVisitor.ExcludeFilesFromListByName(elements, excludedFiles);

            foreach (var fileInfo in fileSystemVisitor.GetFilesInfo())
            {
                elements.Add(fileInfo);
            }

            fileSystemVisitor.ExcludeFilesFromListByName(elements, excludedFiles);

            CollectionAssert.AreEqual(
                elementsWithoutExcludedFiles.Select(f => f.FullName).ToList(),
                elements.Select(f => f.FullName).ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFilesInfo_ThrowsArgumentNullException()
        {
            string dir = null;

            var fileSystemVisitor = new FileSystemVisitor(dir);

            List<FileSystemInfo> elements = new List<FileSystemInfo>();

            foreach (var fileInfo in fileSystemVisitor.GetFilesInfo())
            {
                elements.Add(fileInfo);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExcludeDirectoriesFromList_ThrowsArgumentNullException()
        {
            var dir = @"C:\Users\Kiryl_Kartashou\Desktop\Files";

            var fileSystemVisitor = new FileSystemVisitor(dir);

            List<FileSystemInfo> elements = new List<FileSystemInfo>();

            foreach (var fileInfo in fileSystemVisitor.GetFilesInfo())
            {
                elements.Add(fileInfo);
            }

            List<DirectoryInfo> excludedDirectories = null;

            fileSystemVisitor.ExcludeDirectoriesFromList(elements, excludedDirectories);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExcludeFilesFromList_ThrowsArgumentNullException()
        {
            var dir = @"C:\Users\Kiryl_Kartashou\Desktop\Files";

            var fileSystemVisitor = new FileSystemVisitor(dir);

            List<FileSystemInfo> elements = new List<FileSystemInfo>();

            foreach (var fileInfo in fileSystemVisitor.GetFilesInfo())
            {
                elements.Add(fileInfo);
            }

            List<FileInfo> excludedFiles = null;

            fileSystemVisitor.ExcludeFilesFromList(elements, excludedFiles);
        }
    }
}
