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

namespace TimeTracker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserClass User;
        SettingsClass Settings;
        IKeyboardHook KeyboardHook;
        IMouseHook MouseHookClass;
        StatisticClass Statistic;
        ILoger Loger;
        WorkFlowClass CurrentWorkFlow;
        WorkerClass Worker;
        RemoteServerClass RemoteServer;
        public MainWindow()
        {
            InitializeComponent();
            User = UserClass.GetInstance();
            Settings = SettingsClass.GetInstance();
            Loger = new LogerClass();
            KeyboardActivity.SetLog(Loger.LogKeyItems);
            MouseActivity.SetLog(Loger.LogMouseItems);
            KeyboardHook = new KeyboardHookClass(Loger);
            MouseHookClass = new MouseHookClass(Loger);
            Statistic = new StatisticClass(Loger);
            Worker = new WorkerClass(User, Loger);
            RemoteServer = new RemoteServerClass();
            CurrentWorkFlow = WorkFlowClass.GetWorkFlow(TypeOfWorkFlow.Custom, Convert.ToInt32(Settings.PomodorSize));
            PrimePanel.DataContext = Statistic.CommonPrimeWindowProperty;
            LeftTimeIndicator.DataContext = CurrentWorkFlow;
            KeysActivityIndicator.DataContext = CurrentWorkFlow;
            MouseActivityIndicator.DataContext = CurrentWorkFlow;
            KeyboardHook.StartCapture();
            MouseHookClass.StartCapture();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OpenUserWindowBtn(object sender, RoutedEventArgs e)
        {
            UserWindow user = new UserWindow(User){Owner = this};
            user.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KeyboardHook.StopCapture();
        }

        private void OpenSettingsWindowBtn(object sender, RoutedEventArgs e)
        {
            SettingsWindow SettingsWin = new SettingsWindow(Settings) {Owner = this };
            SettingsWin.ShowDialog();
        }

        private void OpenStatiscticsWindowBtn(object sender, RoutedEventArgs e)
        {
            StatisticsWindow Statistics = new StatisticsWindow(Loger) { Owner = this };
            Statistics.ShowDialog();
        }

        private void AddWorkFlowPomodorBtn(object sender, RoutedEventArgs e)
        {
            CurrentWorkFlow = WorkFlowClass.GetWorkFlow(TypeOfWorkFlow.Pomodor, Convert.ToInt32(Settings.PomodorSize));
            Worker.StartWorking(CurrentWorkFlow);
            LeftTimeIndicator.DataContext = CurrentWorkFlow;
            KeysActivityIndicator.DataContext = CurrentWorkFlow;
            MouseActivityIndicator.DataContext = CurrentWorkFlow;
        }

        private void StopWorkerBtn(object sender, RoutedEventArgs e)
        {
            Worker.StopWorking();
        }

        private void AddWorkFlowStandartDayBtn(object sender, RoutedEventArgs e)
        {
            CurrentWorkFlow = WorkFlowClass.GetWorkFlow(TypeOfWorkFlow.FullDay, Convert.ToInt32(Settings.WorkDay));
            Worker.StartWorking(CurrentWorkFlow);
            LeftTimeIndicator.DataContext = CurrentWorkFlow;
            KeysActivityIndicator.DataContext = CurrentWorkFlow;
            MouseActivityIndicator.DataContext = CurrentWorkFlow;
        }

        private void ConnectOrDisconnectToServerBtn(object sender, RoutedEventArgs e)
        {
            if (RemoteServer.IsConnected == true)
            {
                RemoteServer.Disconnect();
                ConnectOrDisconnectBtn.Header = "Connect to server";
            }
            else
            {
                RemoteServer.Connect();
                Worker.SetServiceContract(RemoteServer.ServiceContract);
                ConnectOrDisconnectBtn.Header = "Disconnect from server";
            }
        }
    }
}
