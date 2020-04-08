using System;
using System.IO;
using System.Runtime.Serialization;


namespace Server
{
    class FileManager
    {

        private Stream stream;
        private const string path = @"c:\temp\DB.bin";
        public FileManager()
        {

        }

        public static void writeStream(Object obj)
        {
            try
            {
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    WriteToBinaryFile(obj);
                }
                else
                {
                    WriteToBinaryFile(obj, true);
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
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        public T ReadFromBinaryFile<T>()
        {
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
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
