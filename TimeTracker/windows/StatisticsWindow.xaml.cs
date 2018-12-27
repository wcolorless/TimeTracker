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
using Microsoft.Win32;
using System.IO;

namespace TimeTracker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {

        ILoger Loger;
        public StatisticsWindow(ILoger Loger)
        {
            InitializeComponent();
            this.Loger = Loger;
            DrawHistograms.Draw(Loger, PrimePanelKey, PrimePanelMouse);
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void OpenLogBtn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog() { Filter = "Log File|*.log" };
            if(of.ShowDialog() == true)
            {
                if (File.Exists(of.FileName))
                {
                    Loger = Loger.Load(of.FileName);
                    if(Loger != null)
                    {
                        DrawHistograms.Draw(Loger, PrimePanelKey, PrimePanelMouse);
                    }
                }
            }
        }

        private void SaveLogBtn(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog() { Filter = "Log File|*.log" };
            if (sf.ShowDialog() == true)
            {               
                if (Loger != null)
                {
                    Loger.Save(sf.FileName);
                }
            }
        }
    }
}
