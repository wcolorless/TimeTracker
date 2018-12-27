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
    public class SettingsClass : INotifyPropertyChanged
    {
        private static SettingsClass _instance;

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private SettingsClass() { }

        public static SettingsClass GetInstance()
        {
            if (_instance == null)
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "\\settings.bin"))
                {
                    _instance = ReadWriteStructure<SettingsClass>.Load("settings");
                }
                else
                {
                    _instance = new SettingsClass();
                    ReadWriteStructure<SettingsClass>.Save(_instance, "settings");
                }
            }
            return _instance;
        }

        public void Save()
        {
            ReadWriteStructure<SettingsClass>.Save(_instance, "settings");
        }

        private int _PomodorSize = (25 * 60);
        private int _WorkDay = (8 * 60 * 60);
        private int _Custom;
        private string _ServerAddress;


        public string PomodorSize
        {
            get
            {
                return _PomodorSize.ToString();
            }
            set
            {
                _PomodorSize = Convert.ToInt32(value);
                NotifyPropertyChanged("PomodorSize");
            }
        }

        public string WorkDay
        {
            get
            {
                return _WorkDay.ToString();
            }
            set
            {
                _WorkDay = Convert.ToInt32(value);
                NotifyPropertyChanged("WorkDay");
            }
        } 
        public string Custom
        {
            get
            {
                return _Custom.ToString();
            }
            set
            {
                _Custom = Convert.ToInt32(value);
                NotifyPropertyChanged("Custom");
            }
        }

        public string ServerAddress
        {
            get
            {
                return _ServerAddress;
            }
            set
            {
                _ServerAddress = value;
                NotifyPropertyChanged("Custom");
            }
        }


    }
}
