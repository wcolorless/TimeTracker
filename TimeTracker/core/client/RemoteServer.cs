using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ServiceModel;
using System.Runtime.Serialization;
using TimeTrackerServiceLib;

namespace TimeTracker
{
    public class RemoteServerClass
    {
        ClientClass Client;
        SettingsClass Settings;

        public IService ServiceContract
        {
            get
            {
              return  Client.ServiceContract;
            }
        }

        public bool IsConnected
        {
            get
            {
                return Client.IsConnected;
            }
        }

        public RemoteServerClass()
        {
            Settings = SettingsClass.GetInstance();
            Client = new ClientClass("http://localhost:4000/DefaultServer");
        }

        public bool Connect()
        {
            return Client.Connect();
        }

        public void Disconnect()
        {
            Client.Disconnect();
        }
    }

}
