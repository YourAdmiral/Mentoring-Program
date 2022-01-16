using Providers;
using Reflection.Attributes;
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
                            prop.SetValue(
                                customFile,
                                _fileProvider.LoadSetting(prop));
                        }
                        else if (attribute.Type == ProviderType.Configuration)
                        {
                            prop.SetValue(
                                customFile,
                                _configurationProvider.LoadSetting(prop));
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
                            _configurationProvider.SaveSetting(
                                prop,
                                prop.GetValue(customFile));
                        }
                    }
                }
            }
        }
    }
}
