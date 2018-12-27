using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Open.WinKeyboardHook;

namespace TimeTracker
{
    public interface IKeyboardHook
    {
        void StartCapture();
        void StopCapture();
    }

    public class KeyboardHookClass : IKeyboardHook
    {
        KeyboardInterceptor Capturer;
        ILoger Loger;

        public KeyboardHookClass(ILoger Loger)
        {
            this.Loger = Loger;
            Capturer = new KeyboardInterceptor();
            Capturer.KeyDown += Capturer_KeyDown;
        }

        private void Capturer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        { 
            Loger.LogKeyItems.Add(new LogKeyItem() {Date = DateTime.Now, Key = e.KeyCode.ToString() });
        }

        public void StartCapture()
        {
            Capturer.StartCapturing();
        }

        public void StopCapture()
        {
            Capturer.StopCapturing();
        }

    }
}
