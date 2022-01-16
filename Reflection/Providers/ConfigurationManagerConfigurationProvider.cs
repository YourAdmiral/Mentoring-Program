using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
    public class ConfigurationManagerConfigurationProvider : Provider
    {
        private Configuration _config;

        public ConfigurationManagerConfigurationProvider(Configuration config)
        {
            _config = config;
        }

        public override void SaveSetting(
            PropertyInfo setting,
            object value)
        {
            if (!IsAlreadySavedSetting(setting))
            {
                _config.AppSettings.Settings.Add(
                    setting.Name, 
                    value.ToString());
            }
            else
            {
                _config.AppSettings.Settings[$"{setting.Name}"].Value = value.ToString();
            }

            _config.Save(ConfigurationSaveMode.Minimal);

            ConfigurationManager.RefreshSection("appSettings");
        }

        public override object LoadSetting(PropertyInfo setting)
        {
            Type propType = setting.PropertyType;

            string settingValue = _config.AppSettings.Settings[$"{setting.Name}"].Value.ToString();

            return LoadSettingValues(propType, settingValue);
        }

        private bool IsAlreadySavedSetting(PropertyInfo setting)
        {
            if (_config.AppSettings.Settings[$"{setting.Name}"] != null)
            {
                return true;
            }

            return false;
        }
    }
}
