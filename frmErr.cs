using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CuttingMake
{
    public delegate void Mprocflash();
    public partial class frmErr : Form
    {
       

        public frmErr()        //////构造函数便于调用
        {
            InitializeComponent();  
        }
#pragma warning disable CS0067 // 从不使用事件“frmErr.flashMarkTimer”
        public event Mprocflash flashMarkTimer;
#pragma warning restore CS0067 // 从不使用事件“frmErr.flashMarkTimer”

        private void label1_Click(object sender, EventArgs e)
        {

        }


        System.Timers.Timer t = new System.Timers.Timer(1);//实例化Timer类，设置间隔时间为10000毫秒；
        private  void frmErr_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            clsLoad.strErr = "";
        }

        private void frmErr_Load(object sender, EventArgs e)
        {
            ErrMessage.Text = clsLoad.strErr;
            clsLoad.WriteLog(clsLoad.strErr);

            ErrMessage.Left = (this.Width - ErrMessage.Width) / 2;
            ErrMessage.Top = (this.Height - ErrMessage.Height) / 2;
            t.Elapsed += new System.Timers.ElapsedEventHandler(theout);//到达时间的时候执行事件；
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
        }

        private void theout(object source, System.Timers.ElapsedEventArgs e)
        {
            t.Stop();
        }





    }
}