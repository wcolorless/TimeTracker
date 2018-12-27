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
using MouseHook =  Gma.System.MouseKeyHook;

namespace TimeTracker
{

    public interface IMouseHook
    {
        void StartCapture();
        void StopCapture();
    }


    public class MouseHookClass : IMouseHook
    {

        ILoger Loger;
        MouseHook.IKeyboardMouseEvents mouseEvents;
        public MouseHookClass(ILoger Loger)
        {
            this.Loger = Loger;
        }

        private void MouseEvents_MouseDownExt(object sender, MouseHook.MouseEventExtArgs e)
        {
            Loger.LogMouseItems.Add(new LogMouseItem() { Date = DateTime.Now, Event = e.Button.ToString(), x = e.Location.X, y = e.Location.Y});
        }


        public void StartCapture()
        {
            mouseEvents = MouseHook.Hook.GlobalEvents();
            mouseEvents.MouseDownExt += MouseEvents_MouseDownExt;
        }

        public void StopCapture()
        {
            mouseEvents.MouseDownExt -= MouseEvents_MouseDownExt;
            mouseEvents.Dispose();
        }
    }
}
