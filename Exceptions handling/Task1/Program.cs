using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                string str;

                Console.WriteLine("Input some value: ");

                str = Console.ReadLine().Trim();

                if (str == null || str.Trim() == "")
                {
                    throw new Exception("Value is not valid");
                }

                Console.WriteLine("Input: '" + str + "'");
                Console.WriteLine("First character: " + str.Substring(0, 1));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}