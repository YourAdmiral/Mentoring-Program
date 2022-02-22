﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerialization
{
    public class SerializerBinary
    {
        private string _binaryFile;

        public SerializerBinary(string fileName)
        {
            _binaryFile = fileName;
        }

        public void Serialize(Department department)
        {
            var bf = new BinaryFormatter();

            using (var fs = new FileStream(_binaryFile, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, department);
            }
        }

        public Department Deserialize()
        {
            var bf = new BinaryFormatter();

            using (var fs = new FileStream(_binaryFile, FileMode.OpenOrCreate))
            {
                return (Department) bf.Deserialize(fs);
            }
        }
    }
}
