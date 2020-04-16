using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UserDatabase
{
    class FileManager
    {
        private Stream stream;
        private const string path = @"c:\temp\DB.bin";
        private const string directPath = @"c:\temp";
        public FileManager()
        {

        }

        public static void writeStream(Object obj)
        {
            try
            {
                if (!Directory.Exists(directPath))
                {
                    Directory.CreateDirectory(directPath);
                }
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    WriteToBinaryFile(obj);
                }
                else
                {
                    WriteToBinaryFile(obj, false);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        /* https://stackoverflow.com/questions/6115721/how-to-save-restore-serializable-object-to-from-file */
        private static void WriteToBinaryFile(Object objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(path, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        public T ReadFromBinaryFile<T>()
        {
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        public static List<T> ReadBinaryFile<T>()
        {
            List<T> list;
            if (File.Exists(path))
            {

                using (Stream fileStream = File.OpenRead(path))
                {
                    BinaryFormatter deserializer = new BinaryFormatter();
                    list = (List<T>)deserializer.Deserialize(fileStream);
                }

                return list;
            }

            return new List<T>();
        }

        public void closeStream()
        {
            try
            {
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
