using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerServiceLib;

namespace TimeTrackerServer
{
    public class MemberClass
    {
        public CredentialsClass Credentials { get; }
        public IPingStatistics PingStatistics { get; private set; }

        public MemberClass(CredentialsClass Credentials)
        {
            this.Credentials = Credentials;
        }

        public void UpdateStatistic(IPingStatistics PingStatistics)
        {
            this.PingStatistics = PingStatistics;
        }


    }
}
