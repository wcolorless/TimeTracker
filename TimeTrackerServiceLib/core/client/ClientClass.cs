using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace TimeTrackerServiceLib
{

    public enum ClientConnectionType
    {
        LocalNetwork,
        CloudService
    }

    public class ClientClass
    {
        string AddressServer;
        public IService Ch { get; private set; }

        public bool IsConnected { get; private set; }
        ChannelFactory<IService> factory;
        public IService ServiceContract { get; set; }

        public ClientClass(string AddressServer)
        {
            this.AddressServer = AddressServer;
        }

        public bool Connect()
        {
            Uri address = new Uri(AddressServer);
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endppint = new EndpointAddress(address);
            factory = new ChannelFactory<IService>(binding, endppint);
            ServiceContract = factory.CreateChannel();
            if (ServiceContract == null) IsConnected = false;
            else IsConnected = true;
            return IsConnected;
        }

        public void Disconnect()
        {
            if (factory != null)
            {
                factory.Abort();
                ServiceContract = null;
                if (factory.State == CommunicationState.Closed) IsConnected = false;
            }
        }
    }
}
