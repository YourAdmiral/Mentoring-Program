using FileSystem;

internal class FileSystemManager
{
    static void Main(string[] args)
    {
        var dir = @"C:\Users\Kiryl_Kartashou\Desktop\Files";

        var fileSystemVisitor = new FileSystemVisitor(dir);

        //var fileSystemVisitor = new FileSystemVisitor(dir, file => file.Equals("Catalog"));

        foreach (var fileInfo in fileSystemVisitor.GetFilesInfo())
        {
            Console.WriteLine(fileInfo);
        }
    }
}