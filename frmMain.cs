using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuttingMake
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void ProductPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0) this.MdiChildren[0].Close();
            frmProductPrint frmProductPrint = new frmProductPrint();
            frmProductPrint.MdiParent = this;
            frmProductPrint.WindowState = FormWindowState.Maximized;

            frmProductPrint.Show();
        }


        private void 用户登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0) this.MdiChildren[0].Close();
            frmLoad myfrmLoad = new frmLoad();
            myfrmLoad.MdiParent = this;
            myfrmLoad.WindowState = FormWindowState.Normal;

            myfrmLoad.Show();
        }

        private void 登陆管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsLoad.LoadLevel == "H")
            {
                if (this.MdiChildren.Length > 0) this.MdiChildren[0].Close();
                frmUserM myfrmUserM = new frmUserM();
                myfrmUserM.MdiParent = this;
                myfrmUserM.WindowState = FormWindowState.Normal;

                myfrmUserM.Show();
            }
        }

        private void 添加打印数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0) this.MdiChildren[0].Close();
            frmPartType1 frmPartType = new frmPartType1();
            frmPartType.MdiParent = this;
            frmPartType.WindowState = FormWindowState.Normal;

            frmPartType.Show();
        }

        private void 历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0) this.MdiChildren[0].Close();
            frmMarkReport MarkReport = new frmMarkReport();
            MarkReport.MdiParent = this;
            MarkReport.WindowState = FormWindowState.Normal;

            MarkReport.Show();

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
            //System.Diagnostics.Process.GetCurrentProcess().Kill();

        }

        private void 导入Excel打印数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0) this.MdiChildren[0].Close();
            frmAddExcelData MfrmAddExcelData = new frmAddExcelData();
            MfrmAddExcelData.MdiParent = this;
            MfrmAddExcelData.WindowState = FormWindowState.Normal;

            MfrmAddExcelData.Show();
        }
    }
}
