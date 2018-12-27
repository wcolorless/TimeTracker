using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Windows;

namespace TimeTrackerServiceLib
{

    public interface IPingStatistics
    {
        string Name { get; set; }
        int ActiveLevel { get; set; }
        DateTime PingTime { get; set; }
    }



    [DataContract]
    public class PingStatisticsClass : IPingStatistics
    {
        [DataMember] public string Name { get; set; }
        [DataMember] public int ActiveLevel { get; set; }
        [DataMember] public DateTime PingTime { get; set; }
    }
}
