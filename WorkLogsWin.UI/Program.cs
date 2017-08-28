using System;
using System.Threading;
using System.Windows.Forms;

namespace WorkLogsWin.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            bool createNew;
            Mutex mutex = new Mutex(false, "WorkLogsApp", out createNew);
            //没有启动，就创建一个新的
            if (createNew)
            {
                Application.Run(new FrmLogin());
            }
            else
            {
                // 已经启动了
                MessageBox.Show("程序已经启动，不能重复启动！");
            }

        }
    }
}
