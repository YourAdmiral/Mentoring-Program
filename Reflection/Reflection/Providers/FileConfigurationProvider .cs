using Reflection.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public void SaveSetting(ConfigurationItemAttribute setting)
        {
            using (StreamWriter sw = new StreamWriter(Path, true))
            {
                sw.WriteLine(setting.Name);
            }
        }

        public string LoadSetting(ConfigurationItemAttribute setting)
        {
            using (StreamReader sr = new StreamReader(Path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
