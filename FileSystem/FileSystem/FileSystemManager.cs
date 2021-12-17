using FileSystem;

internal class FileSystemManager
{
    static void Main(string[] args)
    {
        var dir = @"C:\Users\Kiryl_Kartashou\Desktop\Files";

        var fileSystemVisitor = new FileSystemVisitor(dir);

        IList<FileSystemInfo> elements = new List<FileSystemInfo>();

        //var fileSystemVisitor = new FileSystemVisitor(dir, file => file.Equals("file2.txt"));

        foreach (var fileInfo in fileSystemVisitor.GetFilesInfo())
        {
            elements.Add(fileInfo);
        }

        Console.WriteLine("\nFounded files and directories:");

        foreach (var fileInfo in elements)
        {
            Console.WriteLine(fileInfo);
        }
    }
}