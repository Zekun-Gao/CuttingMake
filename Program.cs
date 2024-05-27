using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuttingMake
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bolRun = true;

            // 检查进程是否在运行状态
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                clsLoad.strErr = "软件程序已经运行，请关闭该进程后再启动";
                MessageBox.Show(clsLoad.strErr);
                clsLoad.WriteLog(clsLoad.strErr);
                Application.Exit();
                return;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            clsLoad.fileName = DateTime.Now.ToString("yyMMdd") + ".log";
            //初始本地SQL服务登陆           
            if (clsSQL.strConnect() != "")
            {
                MessageBox.Show("初始化数据库连接失败", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bolRun = false;
            }
            if (bolRun == true)
            {

                string _login = clsLoad.ReadIniStr("Login", "Enable", "", Application.StartupPath + "\\Land.ini");
                if (_login == "1")
                {
                    frmLoad LoadForm = new frmLoad();
                    if (LoadForm.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new frmMain());
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    clsLoad.MarkUser = "admin";
                    Application.Run(new frmMain());
                }
            }
            else
            {
                Application.Exit();
            }

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
