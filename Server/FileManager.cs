using System;
using System.IO;
using System.Runtime.Serialization;


namespace Server
{
    class FileManager
    {

        private Stream stream;
        private Formatter formatter;
        private string fileName;
        public FileManager(string fileName)
        {
            this.fileName = fileName;

        }

        public void openStream()
        {
            try
            {
                stream = File.Open("data.xml", FileMode.Create);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
