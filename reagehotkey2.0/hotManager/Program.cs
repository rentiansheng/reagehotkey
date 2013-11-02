using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace hotManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool runNow;
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                using (System.Threading.Mutex mutex = new Mutex(true, Application.ProductName, out runNow))
                {
                    if (runNow)
                    {
                        Application.Run(new frmTop());
                        //Application.Run(new  frmSetting(@"C:\Program Files\Renji\file.xml"));
                    }
                   
                }
                //Application.Run(new Form1());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString ());
                Application.Restart();
            }
        }
    }
}
