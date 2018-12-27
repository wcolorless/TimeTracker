using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TimeTrackerServiceLib
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        bool Login(CredentialsClass Credentials);

        [OperationContract]
        void StopWork();

        [OperationContract]
        void StartWork();

        [OperationContract]
        void SendPingStatistics(PingStatisticsClass PingStatistics);
    }
}
