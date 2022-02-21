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
            string fileName = "dataStuff.myData";
            
            IFormatter formatter = new BinaryFormatter();
            
            MyItemType t1 = new MyItemType();
            t1.FirstProperty = "Hello";
            t1.SecondProperty = "World";

            FileStream s1 = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(s1, t1);
            s1.Close();

            FileStream s = new FileStream(fileName, FileMode.Open);
            MyItemType t = (MyItemType)formatter.Deserialize(s);
            Console.WriteLine(t.FirstProperty);
            Console.WriteLine(t.SecondProperty);

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
