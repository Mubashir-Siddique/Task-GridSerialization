using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask_GridSerialization
{
    public delegate void UpdateDataDelegate();
    public class Operations
    {
        public List<Employee> Staff { get; set; }
        public UpdateDataDelegate MyDelegate { get; set; }
        public string Selected_Operation { get; set; }
        public Operations()
        {
            this.Staff = new List<Employee>();
        }

        public void DeserializeData()
        {
            try
            {
                string path = @"C:\Users\Mubashir Siddique\source\repos\DemoTask_GridSerialization\DemoTask_GridSerialization\Files\Serial.txt";

                if (File.Exists(path))
                {
                    using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        Staff = (List<Employee>)formatter.Deserialize(stream);
                        stream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Serialization()
        {
            try
            {
                string path = @"C:\Users\Mubashir Siddique\source\repos\DemoTask_GridSerialization\DemoTask_GridSerialization\Files\Serial.txt";
                using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, Staff);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
