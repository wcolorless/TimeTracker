using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public interface ILogMouseItem
    {
        DateTime Date { get; set; }
        string Event { get; set; }
        double x { get; set; }
        double y { get; set; }

    }


}
