using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    [Serializable]
    public class LogKeyItem : ILogKeyItem
    {
        public DateTime Date { get; set; }

        public string Key { get; set; }
    }
}
