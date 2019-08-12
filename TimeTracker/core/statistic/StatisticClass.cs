using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimeTracker
{
    public class CommonPrimeWindowPropertyClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _TotalKeyPressed;
        private string _TotalMouseMove;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string TotalKeyPressed
        {
            get { return _TotalKeyPressed; }
            set
            {
               if(_TotalKeyPressed != value)
                {
                    _TotalKeyPressed = value;
                    NotifyPropertyChanged("TotalKeyPressed");
                }
            }
        }

        public string TotalMouseMove
        {
            get { return _TotalMouseMove; }
            set
            {
                if(_TotalMouseMove != value)
                {
                    _TotalMouseMove = value;
                    NotifyPropertyChanged("TotalMouseMove");
                }
            }
        }
    }


    public class StatisticClass
    {
        ILoger Loger;
        Timer TickTimer;
        public CommonPrimeWindowPropertyClass CommonPrimeWindowProperty { get; set; }

        public StatisticClass(ILoger Loger)
        {
            CommonPrimeWindowProperty = new CommonPrimeWindowPropertyClass() { TotalKeyPressed = "Keyboard keystrokes: 0", TotalMouseMove = "Mouse clicks: 0" };
            this.Loger = Loger;
            TickTimer = new Timer(100);
            TickTimer.Elapsed += TickTimer_Elapsed;
            TickTimer.Start();
        }

        private void TickTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CommonPrimeWindowProperty.TotalKeyPressed = "Keyboard keystrokes: " + Loger.LogKeyItems.Count.ToString();
            CommonPrimeWindowProperty.TotalMouseMove = "Mouse clicks: " + Loger.LogMouseItems.Count.ToString();
        }
    }
}
