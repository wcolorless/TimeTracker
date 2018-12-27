using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackerServiceLib;

namespace TimeTrackerServer
{
    public class MemberListClass
    {
        public List<MemberClass> Members { get; }
       

        public MemberListClass()
        {
            Members = new List<MemberClass>();
        }

        public bool AddNewMember(CredentialsClass credentials)
        {
            List<MemberClass> members = Members.FindAll(x => x.Credentials.Name == credentials.Name);
            if(members.Count > 0)
            {
                return false;
            }
            else
            {
                Members.Add(new MemberClass(credentials));
                return true;
            }
        }


        public void StatisticUpdate(IPingStatistics PingStatistics)
        {
            MemberClass Member = Members.Find(x => x.Credentials.Name == PingStatistics.Name);
            if (Member != null) Member.UpdateStatistic(PingStatistics);
        }
    }
}
