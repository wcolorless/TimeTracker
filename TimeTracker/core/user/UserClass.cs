using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimeTracker
{
    [Serializable]
    public class UserClass : INotifyPropertyChanged
    {
        private static UserClass _instance;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private UserClass() { }

        public static UserClass GetInstance()
        {
            if (_instance == null)
            {
                if(File.Exists(Directory.GetCurrentDirectory() + "\\user.bin"))
                {
                    _instance = ReadWriteStructure<UserClass>.Load("user");
                }
                else
                {
                    _instance = new UserClass();
                    ReadWriteStructure<UserClass>.Save(_instance, "user");
                }
            }
            return _instance;
        }

        private string _Name = "Default user_" + Guid.NewGuid();

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if(_Name != value)
                {
                    _Name = value;
                    NotifyPropertyChanged(Name);
                }
            }
        }

    }
}
