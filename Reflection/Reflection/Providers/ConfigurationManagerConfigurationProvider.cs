using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Providers
{
    internal class ConfigurationManagerConfigurationProvider
    {
        public void SaveSetting(
            PropertyInfo setting,
            object value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (!IsAlreadySavedSetting(setting))
            {
                config.AppSettings.Settings.Add(
                    setting.Name, 
                    value.ToString());
            }
            else
            {
                config.AppSettings.Settings[$"{setting.Name}"].Value = value.ToString();
            }

            config.Save(ConfigurationSaveMode.Minimal);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public object LoadSetting(PropertyInfo setting)
        {
            Type propType = setting.PropertyType;

            string stringValue;

            int intValue;

            float floatValue;

            TimeSpan timeSpanValue;

            if (propType == typeof(int))
            {
                intValue = Convert.ToInt32(ConfigurationManager.AppSettings[$"{setting.Name}"]);

                return intValue;
            }
            else if (propType == typeof(float))
            {
                floatValue = Convert.ToSingle(ConfigurationManager.AppSettings[$"{setting.Name}"]);

                return floatValue;
            }
            else if (propType == typeof(TimeSpan))
            {
                timeSpanValue = TimeSpan.Parse(ConfigurationManager.AppSettings[$"{setting.Name}"]);

                return timeSpanValue;
            }
            else if (propType == typeof(string))
            {
                stringValue = ConfigurationManager.AppSettings[$"{setting.Name}"];

                return stringValue;
            }

            return null;
        }

        private bool IsAlreadySavedSetting(PropertyInfo setting)
        {
            if (ConfigurationManager.AppSettings[$"{setting.Name}"] != null)
            {
                return true;
            }

            return false;
        }
    }
}
