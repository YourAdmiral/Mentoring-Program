using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ISerializableSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "dataStuff.myData";
            const string firtstValue = "Hello";
            const string secondValue = "World";

            var formatter = new BinaryFormatter();
            
            var myItem = new MyItemType();
            myItem.FirstProperty = firtstValue;
            myItem.SecondProperty = secondValue;

            var fs = new FileStream(fileName, 
                FileMode.Create);

            formatter.Serialize(fs, myItem);
            fs.Close();

            fs = new FileStream(fileName, 
                FileMode.Open);

            var deserializedItem = (MyItemType) formatter.Deserialize(fs);
        }
    }
}
