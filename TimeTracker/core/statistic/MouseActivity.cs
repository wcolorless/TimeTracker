using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public class MouseActivity
    {
        private static double percent = 1;
        private static readonly double indexOfAverageActivity = 25;
        private static List<ILogMouseItem> LogMouseItems;


        public static void SetLog(List<ILogMouseItem> LogMouseItems)
        {
            MouseActivity.LogMouseItems = LogMouseItems;
        }
        public static double GetPercent()
        {
            if (LogMouseItems != null)
            {
                DateTime PastTime = DateTime.Now - TimeSpan.FromMinutes(1);
                List<ILogMouseItem> LastKeys = LogMouseItems.FindAll(x => x.Date > PastTime);
                percent = ((LastKeys.Count / indexOfAverageActivity) * 100);
                return percent >= 100 ? 100 : percent;
            }
            return 1D;
        }
    }
}
