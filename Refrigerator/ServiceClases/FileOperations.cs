using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.IO;

namespace Refrigerator
{
    public class FileOperations
    {
        public static void SaveBinaryFormat(object smartHouse, string fileName)
        {
            BinaryFormatter myBin = new BinaryFormatter();
            using(Stream myFStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                myBin.Serialize(myFStream, smartHouse);
            }
            Console.WriteLine("--> Saving smart house in binary format");
            Console.ReadLine();
        
        }

        public static void LoadFromBynaryFormat (string fileName)
        {
            BinaryFormatter myBin = new BinaryFormatter();
            using (Stream myFStream = File.OpenRead(fileName))
            {
                Device deviceFromBinaryFile = (Device)myBin.Deserialize(myFStream);
            }
        }

        public static void SaveSoapFormat(object smartHouse, string fileName)
        {
            SoapFormatter myBin = new SoapFormatter();
            using (Stream myFStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                try
                {
                    myBin.Serialize(myFStream, smartHouse);
                    Console.WriteLine("--> Saving smart house in SOAP format");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
           
            Console.ReadLine();
        }

        public static void LoadFromSOPAPFormat(string fileName)
        {
            SoapFormatter myBin = new SoapFormatter();
            using (Stream myFStream = File.OpenRead(fileName))
            {
                Device deviceFromBinaryFile = (Device)myBin.Deserialize(myFStream);
            }
        }

        public void SaveXMLFormat()
        {
        }
    }
}
