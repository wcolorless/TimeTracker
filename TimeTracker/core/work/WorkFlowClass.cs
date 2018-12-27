using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimeTracker
{
    public enum TypeOfWorkFlow
    {
        FullDay,
        Pomodor,
        Custom
    }


    public class WorkFlowClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private TypeOfWorkFlow Type;
        private DateTime StartTime;
        public double IniticalQuantityOfSecond { get; }
        private double _TimeLeftPercent;
        private double _KeysActivity;
        private double _MouseActivity;
        private int _QuantityOfSecond;

        public int QuantityOfSecond
        {
            get
            {
                return _QuantityOfSecond;
            }
            set
            {
                _QuantityOfSecond = value;
            }
        }

        public double TimeLeftPercent
        {
            get { return _TimeLeftPercent; }
            set
            {
                if(_TimeLeftPercent != value)
                {
                    _TimeLeftPercent = value;
                    NotifyPropertyChanged("TimeLeftPercent");
                }
            }
        }

        public double KeysActivity
        {
            get { return _KeysActivity; }
            set
            {
                if(_KeysActivity != value)
                {
                    _KeysActivity = value;
                    NotifyPropertyChanged("KeysActivity");
                }
            }
        }

        public double MouseActivity
        {
            get { return _MouseActivity; }
            set
            {
                if(_MouseActivity != value)
                {
                    _MouseActivity = value;
                    NotifyPropertyChanged("MouseActivity");
                }
            }
        }
        private WorkFlowClass(TypeOfWorkFlow Type, int QuantityOfSecond)
        {
            this.Type = Type;
            this.QuantityOfSecond = QuantityOfSecond;
            IniticalQuantityOfSecond = QuantityOfSecond;
            StartTime = DateTime.Now;
            TimeLeftPercent = 385;
            KeysActivity = 100;
            MouseActivity = 100;
        }


        public static WorkFlowClass GetWorkFlow(TypeOfWorkFlow Type, int QuantityOfSecond)
        {
            
            WorkFlowClass WorkFlow = new WorkFlowClass(Type, QuantityOfSecond);


            return WorkFlow;
        }
    }
}
