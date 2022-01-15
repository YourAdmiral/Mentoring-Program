using Reflection.Attributes;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            using (StreamWriter sw = new StreamWriter(Path, false))
            {
                sw.WriteLine($"{setting.Name},{value}");
            }
        }

        public object LoadSetting(PropertyInfo setting)
        {
            List<string> settingValues;

            int intValue;

            float floatValue;

            List<string> stringList = new List<string>();

            List<List<string>> settingsList = new List<List<string>>();

            TimeSpan timeSpanValue;

            Type propType = setting.PropertyType;

            using (StreamReader sr = new StreamReader(Path))
            {
                while (!sr.EndOfStream)
                {
                    settingValues = sr.ReadLine().Split(',').ToList();

                    if (settingValues[0] == setting.Name)
                    {
                        if (propType == typeof(int))
                        {
                            intValue = Convert.ToInt32(settingValues[1]);

                            return intValue;
                        }
                        else if (propType == typeof(float))
                        {
                            floatValue = Convert.ToSingle(settingValues[1]);

                            return floatValue;
                        }
                        else if (propType == typeof(TimeSpan))
                        {
                            timeSpanValue = TimeSpan.Parse(settingValues[1]);

                            return timeSpanValue;
                        }
                        else
                        {
                            return settingValues[1];

                        }
                    }
                }
            }

            return null;
        }
    }
}
