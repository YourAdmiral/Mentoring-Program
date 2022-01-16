using Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class ConfigurationItemAttribute : Attribute
    {
        public string Name { get; set; }

        public ProviderType Type { get; set; }

        public ConfigurationItemAttribute(
            string name,
            ProviderType type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}
