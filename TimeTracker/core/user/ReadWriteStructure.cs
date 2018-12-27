using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TimeTracker
{
    public  class ReadWriteStructure<T>
    {

       public static void Save(T Structure, string FileName)
        {
            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + FileName + ".bin", FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Structure);
                fs.Close();
            }
        }

        public static T Load(string FileName)
        {
            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + FileName + ".bin", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                var tmp = (T)bf.Deserialize(fs);
                fs.Close();
                return tmp;
            }
        }
    }
}
