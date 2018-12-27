using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TimeTracker
{
    public interface ILoger
    {
        ILoger Load(string LoadPath);
        void Save(string SavePath);
        List<ILogKeyItem> LogKeyItems { get; set; }
        List<ILogMouseItem> LogMouseItems { get; set; }
    }

    [Serializable]
    public class LogerClass : ILoger
    {
        public List<ILogKeyItem> LogKeyItems { get;  set; }
        public List<ILogMouseItem> LogMouseItems { get; set; }

        public LogerClass()
        {
            LogKeyItems = new List<ILogKeyItem>();
            LogMouseItems = new List<ILogMouseItem>();
        }

        public ILoger Load(string LoadPath)
        {
            using (FileStream fs = new FileStream(LoadPath, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                var tmp = bf.Deserialize(fs) as ILoger;
                fs.Close();
                return tmp;
            }
        }

        public void Save(string  SavePath)
        {
            using (FileStream fs = new FileStream(SavePath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, this);
                fs.Close();
            }
        }
    }
}
