using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Providers
{
    public abstract class Provider
    {
        public object LoadSettingValues(Type propType, string propValue)
        {
            int intValue;

            float floatValue;

            TimeSpan timeSpanValue;

            if (propType == typeof(int))
            {
                intValue = Convert.ToInt32(propValue);

                return intValue;
            }
            else if (propType == typeof(float))
            {
                floatValue = Convert.ToSingle(propValue);

                return floatValue;
            }
            else if (propType == typeof(TimeSpan))
            {
                timeSpanValue = TimeSpan.Parse(propValue);

                return timeSpanValue;
            }
            else if (propType == typeof(string))
            {
                return propValue;
            }

            return null;
        }

        public abstract void SaveSetting(
            PropertyInfo setting, 
            object value);

        public abstract object LoadSetting(PropertyInfo setting);
    }
}
