namespace StandardLibrary
{
    public class MessageLibrary
    {
        public string GetName()
        {
            Console.WriteLine("Write your Name:");

            return Console.ReadLine();
        }

        public void ShowMessage(string name)
        {
            Console.WriteLine($"Hello {name}!");
        }
    }
}