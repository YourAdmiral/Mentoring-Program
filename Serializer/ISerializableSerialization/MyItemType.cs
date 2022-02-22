using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ISerializableSerialization
{
    [Serializable]
    public class MyItemType : ISerializable
    {
        private string firstProperty_value;

        private string secondProperty_value;

        public string FirstProperty
        {
            get { return firstProperty_value; }
            set { firstProperty_value = value; }
        }

        public string SecondProperty
        {
            get { return secondProperty_value; }
            set { secondProperty_value = value; }
        }

        public MyItemType()
        {

        }

        public MyItemType(SerializationInfo info, StreamingContext context)
        {
            firstProperty_value = (string)info.GetValue("props1", typeof(string));
            secondProperty_value = (string)info.GetValue("props2", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("props1", firstProperty_value, typeof(string));
            info.AddValue("props2", secondProperty_value, typeof(string));
        }
    }
}
