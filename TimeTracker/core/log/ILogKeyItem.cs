using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public interface ILogKeyItem
    {
        DateTime Date { get; set; }
        string Key { get; set; }

    }


}
