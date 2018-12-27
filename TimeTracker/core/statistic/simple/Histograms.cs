using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public class Histograms
    {
        static List<List<ILogKeyItem>> GetKeys(List<ILogKeyItem> LogKeyItems)
        {
            List<List<ILogKeyItem>> Gists = new List<List<ILogKeyItem>>();
            if (LogKeyItems != null && LogKeyItems.Count > 0)
            {
                DateTime LastTime = LogKeyItems.Last().Date;
                DateTime PartTime = LastTime - TimeSpan.FromMinutes(5);
                while (true)
                {
                    DateTime tmp = LogKeyItems.First().Date;
                    if (PartTime <= tmp)
                    {
                        if (LastTime > tmp) PartTime = tmp;
                        else break;
                    }
                    List<ILogKeyItem> items = LogKeyItems.FindAll(x => x.Date <= LastTime && x.Date >= PartTime);
                    if (items.Count > 0) Gists.Add(items);
                    LastTime = PartTime;
                    PartTime = PartTime - TimeSpan.FromMinutes(5);
                }                
            }
            return Gists;
        }

        static List<List<ILogMouseItem>> GetMouse(List<ILogMouseItem> LogMouseItems)
        {
            List<List<ILogMouseItem>> Gists = new List<List<ILogMouseItem>>();
            if (LogMouseItems != null && LogMouseItems.Count > 0)
            {
                DateTime LastTime = LogMouseItems.Last().Date;
                DateTime PartTime = LastTime - TimeSpan.FromMinutes(5);
                while (true)
                {
                    DateTime tmp = LogMouseItems.First().Date;
                    if (PartTime <= tmp)
                    {
                        if (LastTime > tmp) PartTime = tmp;
                        else break;
                    }
                    List<ILogMouseItem> items = LogMouseItems.FindAll(x => x.Date <= LastTime && x.Date >= PartTime);
                    if (items.Count > 0) Gists.Add(items);
                    LastTime = PartTime;
                    PartTime = PartTime - TimeSpan.FromMinutes(5);
                }
            }
            return Gists;
        }

        public static (List<double>, List<double>) GetActivity(ILoger Loger)
        {
            var GistsKey = GetKeys(Loger.LogKeyItems);
            var GistsMouse = GetMouse(Loger.LogMouseItems);
            List<double> ActivityKey = new List<double>();
            List<double> ActivityMouse = new List<double>();
            List<double> ResultActivity = new List<double>();
            foreach (List<ILogKeyItem> list in GistsKey)
            {
                ActivityKey.Add(list.Count);
            }
            foreach(List<ILogMouseItem> list in GistsMouse)
            {
                ActivityMouse.Add(list.Count);
            }
            ActivityKey.Reverse();
            ActivityMouse.Reverse();
            return (ActivityKey, ActivityMouse);
        }


    }
}
