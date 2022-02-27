using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BookLibrary.Serializer
{
    public class SerializerJson<T>
    {
        public void Serialize(
            T obj, 
            string jsonFile)
        {
            var json = new JsonSerializer();

            using (var sw = new StreamWriter(jsonFile))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    json.Serialize(jsonWriter, obj);
                }
            }
        }

        public T Deserialize(string jsonFile)
        {
            JObject jObj = null;
            var json = new JsonSerializer();

            using (var sr = new StreamReader(jsonFile))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    jObj = json.Deserialize(jsonReader) as JObject;
                }
            }

            return (T)jObj.ToObject(typeof(T));
        }
    }
}
