using Providers;
using Reflection.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Class_examples
{
    internal class CustomFile
    {
        [ConfigurationItemAttribute("Test", ProviderType.File)]
        public int Value1 { get; set; }

        [ConfigurationItemAttribute("Test", ProviderType.Configuration)]
        public float Value2 { get; set; }

        [ConfigurationItemAttribute("Test", ProviderType.File)]
        public string Value3 { get; set; }

        [ConfigurationItemAttribute("Test", ProviderType.Configuration)]
        public TimeSpan Value4 { get; set; }

        public CustomFile(
            int value1,
            float value2,
            string value3,
            TimeSpan value4)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
        }
    }
}
