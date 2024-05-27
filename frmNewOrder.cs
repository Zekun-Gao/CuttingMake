using NPOI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZXing;

namespace CuttingMake
{
    public partial class frmNewOrder : Form
    {
        public frmNewOrder()
        {
            InitializeComponent();
        }
        public event delflash flashcarInfo;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtOrderNumber.Text != "" && txtZHPartNumber.Text != "" )
            {

                string strsql = "insert into tb_OrderNumber(OrderNumber,ZHPartNumber) values ('" + txtOrderNumber.Text + "','" + txtZHPartNumber.Text +  "')" ;
                int i =clsSQL .intExecuteQuery (strsql );
                if(i>0)
                {
                        if (flashcarInfo != null)
                        {
                            flashcarInfo();
                            MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                }
            }
            else
            {
                MessageBox.Show("输入不完整，请确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void frmNewCarItem_Load(object sender, EventArgs e)
        {

        }

     
    }
}