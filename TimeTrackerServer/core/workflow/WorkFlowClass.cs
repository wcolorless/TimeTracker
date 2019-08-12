using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization.Formatters.Binary;
using TimeTrackerServiceLib;

namespace TimeTrackerServer
{

    public class WorkFlowClass
    {

        MemberListClass MemberList;



        public WorkFlowClass()
        {

            MemberList = new MemberListClass();
        }


        public void LoginNewUsers(CredentialsClass Credentials)
        {
            if (MemberList.AddNewMember(Credentials))
            {
                Grid grid = new Grid() { Height = 50, Width = 680, HorizontalAlignment = HorizontalAlignment.Center };
                grid.Children.Add(new Border() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(1) });
                grid.Children.Add(new TextBlock() { Text = "User: " + Credentials.Name, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Margin = new Thickness(10) });
                grid.Children.Add(new TextBlock() { Text = "Activity level: 0", HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Bottom, Margin = new Thickness(10) });
                grid.Children.Add(new TextBlock() { Text = "Last activity update: " + DateTime.Now.ToLongTimeString(), HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Bottom, Margin = new Thickness(10) });
                GlobalUIVars.ListOfWorkers.Children.Add(grid);
            }

        }

        public void PingStatisticsUpdate(IPingStatistics PingStatistics)
        {
            MemberList.StatisticUpdate(PingStatistics);
            Draw();
        }



        public void Draw()
        {
            GlobalUIVars.ListOfWorkers.Children.Clear();
            for (int i = 0; i < MemberList.Members.Count; i++)
            {
                Grid grid = new Grid() { Height = 50, Width = 680, HorizontalAlignment = HorizontalAlignment.Center };
                grid.Children.Add(new Border() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(1) });
                grid.Children.Add(new TextBlock() { Text = "User: " + MemberList.Members[i].Credentials.Name, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Margin = new Thickness(10) });
                grid.Children.Add(new TextBlock() { Text = "Activity level: " + MemberList.Members[i].PingStatistics.ActiveLevel, HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Bottom, Margin = new Thickness(10) });
                grid.Children.Add(new TextBlock() { Text = "Last activity update: " + DateTime.Now.ToLongTimeString(), HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Bottom, Margin = new Thickness(10) });
                GlobalUIVars.ListOfWorkers.Children.Add(grid);
            }
        }



    }
}
