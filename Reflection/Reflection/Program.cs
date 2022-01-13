using Reflection.Class_examples;
using Reflection.Providers;
using System;
using System.IO;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileConfigurationProvider fileProvider = new FileConfigurationProvider(@"..\..\..\TextFile.txt");

            //fileProvider.SaveSetting("str, string");

            //fileProvider.SaveSetting("value, int");

            //string str = fileProvider.LoadSetting();

            //Console.WriteLine(str);

            CustomFile file = new CustomFile(
                1,
                15,
                "Text",
                new TimeSpan(4, 20, 40));

            file.SaveSettings();
        }
    }
}
