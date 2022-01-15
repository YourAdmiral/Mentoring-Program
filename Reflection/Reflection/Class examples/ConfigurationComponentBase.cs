using Reflection.Attributes;
using Reflection.Providers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Class_examples
{
    internal class ConfigurationComponentBase
    {
        private FileConfigurationProvider _fileProvider;

        private ConfigurationManagerConfigurationProvider _configurationProvider;

        public ConfigurationComponentBase(
            FileConfigurationProvider fileProvider,
            ConfigurationManagerConfigurationProvider configurationProvider)
        {
            _fileProvider = fileProvider;
            _configurationProvider = configurationProvider;
        }

        public void LoadSettings(CustomFile customFile)
        {
            PropertyInfo[] propInfos = typeof(CustomFile).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in propInfos)
            {
                object[] attrs = prop.GetCustomAttributes(true);

                foreach (object attr in attrs)
                {
                    ConfigurationItemAttribute attribute = attr as ConfigurationItemAttribute;

                    if (attribute != null)
                    {
                        if (attribute.Type == ProviderType.File)
                        {

                        }
                        else if (attribute.Type == ProviderType.Configuration)
                        {
                            Type propType = prop.PropertyType;

                            string stringValue;

                            int intValue;

                            float floatValue;

                            TimeSpan timeSpanValue;

                            if (propType == typeof(int))
                            {
                                intValue = Convert.ToInt32(ConfigurationManager.AppSettings[$"{prop.Name}"]);

                                prop.SetValue(customFile, intValue);
                            }
                            else if (propType == typeof(float))
                            {
                                floatValue = Convert.ToSingle(ConfigurationManager.AppSettings[$"{prop.Name}"]);

                                prop.SetValue(customFile, floatValue);
                            }
                            else if (propType == typeof(TimeSpan))
                            {
                                timeSpanValue = TimeSpan.Parse(ConfigurationManager.AppSettings[$"{prop.Name}"]);

                                prop.SetValue(customFile, timeSpanValue);
                            }
                            else
                            {
                                stringValue = ConfigurationManager.AppSettings[$"{prop.Name}"];

                                prop.SetValue(customFile, stringValue);
                            }
                        }
                    }
                }
            }
        }

        public void SaveSettings(CustomFile customFile)
        {
            PropertyInfo[] propInfos = typeof(CustomFile).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in propInfos)
            {
                object[] attrs = prop.GetCustomAttributes(true);

                foreach (object attr in attrs)
                {
                    ConfigurationItemAttribute attribute = attr as ConfigurationItemAttribute;

                    if (attribute != null)
                    {
                        if (attribute.Type == ProviderType.File)
                        {
                            _fileProvider.SaveSetting(
                                prop,
                                prop.GetValue(customFile));
                        }
                        else if (attribute.Type == ProviderType.Configuration)
                        {
                            //_configurationProvider.SaveSetting(prop);
                        }
                    }
                }
            }
        }
    }
}
