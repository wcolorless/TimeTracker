using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows;
using TimeTrackerServiceLib;

namespace TimeTrackerServer
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        WorkFlowClass WorkFlow;

        public Service(WorkFlowClass WorkFlow)
        {
            this.WorkFlow = WorkFlow;
        }


        public bool Login(CredentialsClass Credentials)
        {
            WorkFlow.LoginNewUsers(Credentials);
            return true;
        }

        public void SendPingStatistics(PingStatisticsClass PingStatistics)
        {
            WorkFlow.PingStatisticsUpdate(PingStatistics as IPingStatistics);
        }

        public void StartWork()
        {
            throw new NotImplementedException();
        }

        public void StopWork()
        {
            throw new NotImplementedException();
        }
    }
}
