using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TimeTrackerServiceLib;

namespace TimeTracker
{
    public class WorkerClass
    {
        WorkFlowClass WorkFlow;

        Timer Timer;
        IService ServiceContract;
        UserClass User;
        bool Authorization = false;
        ILoger Loger;
        public WorkerClass(UserClass User, ILoger Loger)
        {
            this.User = User;
            this.Loger = Loger;
            Timer = new Timer(1000);
            Timer.Elapsed += Timer_Elapsed;
        }

        public void SetServiceContract(IService ServiceContract)
        {
            if(ServiceContract != null)
            {
                this.ServiceContract = ServiceContract;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (WorkFlow != null)
            {
                WorkFlow.QuantityOfSecond--;
                WorkFlow.TimeLeftPercent = (WorkFlow.QuantityOfSecond / (WorkFlow.IniticalQuantityOfSecond / 100D)) * (385D / 100D);
                WorkFlow.KeysActivity = KeyboardActivity.GetPercent();
                WorkFlow.MouseActivity = MouseActivity.GetPercent();
                if (ServiceContract != null)
                {
                    if (Authorization == false && User != null)
                    {
                        ServiceContract.Login(new CredentialsClass() { Name = User.Name});
                        Authorization = true;
                    }
                   if(Authorization == true)
                    {
                        ServiceContract.SendPingStatistics(new PingStatisticsClass() { Name = User.Name, PingTime = DateTime.Now, ActiveLevel = PingStatisticsGenerator.Get(Loger) });
                    }
                }
                if (WorkFlow.QuantityOfSecond == 0)
                {
                    var Timer = sender as Timer;
                    Timer.Stop();
                }
            }
        }

        void SetWorkFlow(WorkFlowClass WorkFlow)
        {
            this.WorkFlow = WorkFlow;
        }

        public void StartWorking(WorkFlowClass WorkFlow)
        {
            SetWorkFlow(WorkFlow);
            Timer.Start();
        }

        public void StopWorking()
        {
            if(Timer != null && Timer.Enabled == true)
            {
                Timer.Stop();
            }
        }

    }
}
