using FileSystem;

internal class FileSystemManager
{
    static void Main(string[] args)
    {
        var dir = @"C:\Users\Kiryl_Kartashou\Desktop\Files";

        var fileSystemVisitor = new FileSystemVisitor(dir);

        List<FileSystemInfo> elements = new List<FileSystemInfo>();

        //var fileSystemVisitor = new FileSystemVisitor(dir, file => file.Equals("file2.txt"));

        foreach (var fileInfo in fileSystemVisitor.GetFilesInfo())
        {
            elements.Add(fileInfo);
        }

        //List<FileInfo> excludedFiles = new List<FileInfo>();

        //excludedFiles.Add(new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog\file2.txt"));

        //excludedFiles.Add(new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog2\myfile.txt"));

        //fileSystemVisitor.ExcludeFilesFromList(elements, excludedFiles);

        //----------------------------------------------------------------

        //List<DirectoryInfo> excludedDirectories = new List<DirectoryInfo>();

        //excludedDirectories.Add(new DirectoryInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog"));

        //excludedDirectories.Add(new DirectoryInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Files\Catalog2"));

        //fileSystemVisitor.ExcludeDirectoriesFromList(elements, excludedDirectories);

        //Console.WriteLine("\nFounded files and directories:");

        //----------------------------------------------------------------

        //List<string> excludedFiles = new List<string>();

        //excludedFiles.Add("file2.txt");

        //excludedFiles.Add("myfile.txt");

        //fileSystemVisitor.ExcludeFilesFromListByName(elements, excludedFiles);

        //----------------------------------------------------------------

        //List<string> excludedDirectories = new List<string>();

        //excludedDirectories.Add("Catalog");

        //excludedDirectories.Add("Catalog2");

        //fileSystemVisitor.ExcludeDirectoriesFromListByName(elements, excludedDirectories);

        foreach (var fileInfo in elements)
        {
            Console.WriteLine(fileInfo);
        }
    }
}