using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    [Serializable]
    public class LogMouseItem : ILogMouseItem
    {
        public DateTime Date { get; set; }

        public string Event { get; set; }

        public double x { get; set; }

        public double y { get; set; }
    }
}
