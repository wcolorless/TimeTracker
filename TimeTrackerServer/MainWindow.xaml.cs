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

namespace TimeTrackerServer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        WorkFlowClass WorkFlow;
        ServerClass Server;

        public MainWindow()
        {
            InitializeComponent();
            WorkFlow = new WorkFlowClass();
            Server = new ServerClass(WorkFlow);
            GlobalUIVars.SetPanels(ListOfWorkers);

        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void OpenSettingsWindowBtn(object sender, RoutedEventArgs e)
        {
            SettingsWindow Settings = new SettingsWindow() { Owner = this };
            Settings.ShowDialog();
        }

        private void StartOrStopWorkFlowBtn(object sender, RoutedEventArgs e)
        {
            if(Server.StatusService == true)
            {
                Server.StopServer();
                StartOrStopMenuBtn.Header = "Запустить";
            }
            else
            {
                Server.StartServer();
                StartOrStopMenuBtn.Header = "Остановить";
            }
        }
    }
}
