using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonSerialization
{
    public class SerializerJson
    {
        private string _jsonFile;

        public SerializerJson(string fileName)
        {
            _jsonFile = fileName;
        }

        public void Serialize(Department department)
        {
            JsonSerializer json = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(_jsonFile))
            {
                using (JsonWriter jsonWriter = new JsonTextWriter(sw))
                {
                    json.Serialize(jsonWriter, department);
                }
            }
        }

        public Department Deserialize()
        {
            JObject jObj = null;
            JsonSerializer json = new JsonSerializer();

            using (StreamReader sr = new StreamReader(_jsonFile))
            {
                using (JsonReader jsonReader = new JsonTextReader(sr))
                {
                    jObj = json.Deserialize(jsonReader) as JObject;
                }
            }

            return (Department) jObj.ToObject(typeof(Department));
        }
    }
}
