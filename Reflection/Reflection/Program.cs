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

            ConfigurationManagerConfigurationProvider configurationProvider = new ConfigurationManagerConfigurationProvider();

            //fileProvider.SaveSetting("str, string");

            //fileProvider.SaveSetting("value, int");

            //string str = fileProvider.LoadSetting();

            //Console.WriteLine(str);

            ConfigurationComponentBase componentBase = new ConfigurationComponentBase(
                fileProvider, 
                configurationProvider);

            CustomFile file = new CustomFile(
                1,
                1,
                "1",
                new TimeSpan(11, 11, 11));

            componentBase.SaveSettings(file);

            componentBase.LoadSettings(file);

            Console.WriteLine(file.Value1);

            Console.WriteLine(file.Value2);

            Console.WriteLine(file.Value3);

            Console.WriteLine(file.Value4);
        }
    }
}
