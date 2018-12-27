using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public class PingStatisticsGenerator
    {
        public static int Get(ILoger Loger)
        {
            int result = 0;
            if ((Loger.LogKeyItems != null && Loger.LogKeyItems.Count > 0) && (Loger.LogMouseItems != null && Loger.LogMouseItems.Count > 0))
            {
                DateTime LastTime = DateTime.Now;
                DateTime PartTime = LastTime - TimeSpan.FromSeconds(1);
                List<ILogKeyItem> itemsKey = Loger.LogKeyItems.FindAll(x => x.Date <= LastTime && x.Date >= PartTime);
                List<ILogMouseItem> itemMouse = Loger.LogMouseItems.FindAll(x => x.Date <= LastTime && x.Date >= PartTime);
                if (itemsKey.Count > 0 || itemMouse.Count > 0)   result = (itemsKey.Count + itemMouse.Count) / 2;
            }
            return result;
        }
    }
}
