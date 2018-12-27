using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using TimeTrackerServiceLib;
using System.Windows;

namespace TimeTrackerServer
{
    public class ServerClass
    {
        WorkFlowClass WorkFlow;
        //
        ServiceHost Host;
        public bool StatusService { get; private set; } = false;
        string DefaultServerName = "http://localhost:4000/DefaultServer";
        string Preambula = "http://";
        string IPAddress = "localhost";
        string Port = "4000";
        string ServerName = "DefaultServer";
        public string DisplayServerName { get; private set; } = "http://localhost:4000/DefaultServer";
        //

        public ServerClass(WorkFlowClass WorkFlow)
        {
            this.WorkFlow = WorkFlow;
        }

        public void SetServerAddress(string IPAddress, string Port, string ServerName)
        {
            this.IPAddress = IPAddress;
            this.Port = Port;
            this.ServerName = ServerName;
            DisplayServerName = Preambula + IPAddress + ":" + Port + "/" + ServerName;
        }

        bool CreateAndRunService()
        {
            Uri address;
            if (IPAddress == "localhost" && Port == "4000" && ServerName == "DefaultServer") address = new Uri(DefaultServerName);
            else address = new Uri(Preambula + IPAddress + ":" + Port + "/" + ServerName);
            BasicHttpBinding binding = new BasicHttpBinding();
            Type contract = typeof(IService);
            Service service_host = new Service(WorkFlow);  
            Host = new ServiceHost(service_host);
            Host.AddServiceEndpoint(contract, binding, address);
            try
            {
                Host.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                StatusService = false;
                return false;
            }
            if (Host.State == CommunicationState.Opened) StatusService = true;
            else StatusService = false;
            return true;
        }

        void StopService()
        {
            if (StatusService == true)
            {
                Host.Abort();
                StatusService = false;
            }
        }

        /// <summary>
        /// Запускает сервер
        /// </summary>
        /// <param name="option">Позволяет выбрать вариант использования сервера (с http сервисом или без)</param>
        /// <returns></returns>
        public bool StartServer()
        {
            CreateAndRunService();
            return true;
        }

        /// <summary>
        /// Останавливает сервер и сервис если он был запущен
        /// </summary>
        /// <returns></returns>
        public bool StopServer()
        {
            StopService();
            return true;
        }
    }
}
