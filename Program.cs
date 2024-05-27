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

            // �������Ƿ�������״̬
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                clsLoad.strErr = "��������Ѿ����У���رոý��̺�������";
                MessageBox.Show(clsLoad.strErr);
                clsLoad.WriteLog(clsLoad.strErr);
                Application.Exit();
                return;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            clsLoad.fileName = DateTime.Now.ToString("yyMMdd") + ".log";
            //��ʼ����SQL�����½           
            if (clsSQL.strConnect() != "")
            {
                MessageBox.Show("��ʼ�����ݿ�����ʧ��", "���Ӵ���", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
