using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
    public class FileConfigurationProvider : Provider
    {
        public string Path { get; set; }   

        public FileConfigurationProvider(string path)
        {
            Path = path;
        }

        public override void SaveSetting(
            PropertyInfo setting, 
            object value)
        {
            List<List<string>> settingsList = LoadFileSettings();

            List<string> savedSetting = settingsList.FirstOrDefault(item => item[0] == setting.Name);

            if (savedSetting == null)
            {
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine($"{setting.Name},{value}");
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(Path, false))
                {
                    sw.Write("");

                    foreach (var settings in settingsList)
                    {
                        if (settings[0] == setting.Name)
                        {
                            settings[1] = value.ToString();
                        }

                        sw.WriteLine($"{settings[0]},{settings[1]}");
                    }
                }
            }
        }

        public override object LoadSetting(PropertyInfo setting)
        {
            Type propType = setting.PropertyType;

            List<List<string>> settingsList = LoadFileSettings();

            foreach (var settingValues in settingsList)
            {
                if (settingValues[0] == setting.Name)
                {
                    return LoadSettingValues(propType, settingValues[1]);
                }
            }

            return null;
        }

        private List<List<string>> LoadFileSettings()
        {
            FileInfo f = new FileInfo(Path);

            List<List<string>> settingsList = new List<List<string>>();

            if (f != null)
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (!sr.EndOfStream)
                    {
                        settingsList.Add(sr.ReadLine().Split(',').ToList());
                    }
                }
            }

            return settingsList;
        }
    }
}
