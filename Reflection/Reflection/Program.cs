using Reflection.Class_examples;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var DLL = Assembly.LoadFile(@"C:\Users\Kiryl_Kartashou\Desktop\Git\Mentoring-Program\Reflection\Reflection\Providers.dll");

            FileInfo f = new FileInfo(@"C:\Users\Kiryl_Kartashou\Desktop\Git\Mentoring-Program\Reflection\Reflection\Providers.dll");

            Assembly assembly = Assembly.LoadFrom(f.FullName);

            Type configurationProviderType = assembly.GetType("Providers.ConfigurationManagerConfigurationProvider");

            Type fileProviderType = assembly.GetType("Providers.FileConfigurationProvider");

            dynamic configInstance = Activator.CreateInstance(configurationProviderType, ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None));

            dynamic fileInstance = Activator.CreateInstance(fileProviderType, @"..\..\..\TextFile.txt");

            ConfigurationComponentBase componentBase = new ConfigurationComponentBase(
                fileInstance,
                configInstance);

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
