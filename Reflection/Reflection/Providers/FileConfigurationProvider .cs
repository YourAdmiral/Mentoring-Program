using Reflection.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Providers
{
    internal class FileConfigurationProvider
    {
        public string Path { get; set; }   

        public FileConfigurationProvider(string path)
        {
            Path = path;
        }

        public void SaveSetting(
            PropertyInfo setting, 
            object value)
        {
            using (StreamWriter sw = new StreamWriter(Path, true))
            {
                sw.WriteLine($"{setting.Name}, {setting.PropertyType.Name}, {value};");
            }
        }

        public string LoadSetting()
        {
            using (StreamReader sr = new StreamReader(Path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
