using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteJson
{
    public class Json
    {
        public string Read(string PathWithFileName)
        {
            string ReadString = string.Empty;
            //Open the file              
            var stream = File.OpenText(PathWithFileName);
            //Read the file              
            ReadString = stream.ReadToEnd();
            return ReadString;
        }
        public bool Write(string PathWithFileName, string Json)
        {
            bool WFlag = false;
            try
            {
                System.IO.File.WriteAllText(PathWithFileName, Json);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return WFlag;
        }
        public bool Write(string PathWithFileName, object value)
        {
            bool WFlag = false;
            try
            {
                using (StreamWriter file = File.CreateText(PathWithFileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return WFlag;
        }
    }
}
