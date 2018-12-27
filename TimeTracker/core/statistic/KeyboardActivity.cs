using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public  class KeyboardActivity
    {
        private static double percent = 1;
        private static readonly double indexOfAverageActivity = 300;
        private static List<ILogKeyItem> LogKeyItems;


        public static void SetLog(List<ILogKeyItem> LogKeyItems)
        {
            KeyboardActivity.LogKeyItems = LogKeyItems;
        }
        public static double GetPercent()
        {
            if(LogKeyItems != null)
            {
                DateTime PastTime = DateTime.Now - TimeSpan.FromMinutes(1);
                List<ILogKeyItem> LastKeys = LogKeyItems.FindAll(x => x.Date > PastTime);
                percent = ((LastKeys.Count / indexOfAverageActivity) * 100);
                return percent >= 100 ? 100 : percent;
            }
            return 1D;
        }
    }
}
