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
            JsonSerializer json = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(jsonFile))
            {
                using (JsonWriter jsonWriter = new JsonTextWriter(sw))
                {
                    json.Serialize(jsonWriter, obj);
                }
            }
        }

        public T Deserialize(string jsonFile)
        {
            JObject jObj = null;
            JsonSerializer json = new JsonSerializer();

            using (StreamReader sr = new StreamReader(jsonFile))
            {
                using (JsonReader jsonReader = new JsonTextReader(sr))
                {
                    jObj = json.Deserialize(jsonReader) as JObject;
                }
            }

            return (T)jObj.ToObject(typeof(T));
        }
    }
}
