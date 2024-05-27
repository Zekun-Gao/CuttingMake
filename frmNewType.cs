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
#pragma warning disable CS8981 // 该类型名称仅包含小写 ascii 字符。此类名称可能会成为该语言的保留值。
    public delegate void delflash();
#pragma warning restore CS8981 // 该类型名称仅包含小写 ascii 字符。此类名称可能会成为该语言的保留值。
    public partial class frmNewType : Form
    {
        public frmNewType()
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
            if (txtZHPartSO1CC.Text != "" && txtSN.Text != "" && txtMarkPath.Text != "" && txtZPLPrinter.Text != "" && txtZHPartModel.Text != "" && txtZHPartType.Text != "")
            {
                int indexOfSpace = txtZHPartType.Text.IndexOf('-');
                string result = "";
                if (indexOfSpace != -1)
                {
                    result = txtZHPartType.Text.Substring(0, indexOfSpace);
                    //Console.WriteLine("结果为：" + result);
                }
                else
                {
                    MessageBox.Show("不支持此型号添加", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    //Console.WriteLine("未找到指定字符");
                    return;
                }

                string strsql = "insert into tb_PartType(ZHPartType,ZHMakePart,ZHPartSO1CC,ZHPartModel,BarCode,SN,SN_Week,MarkPath,ZPLPrinter) values ('" + 
                    txtZHPartType.Text + "','" + result + "','"+ txtZHPartSO1CC.Text + "','"+ txtZHPartModel.Text + "mm','" + "xxx" + "','" + txtSN.Text + "','" + "星期一" + "','" + txtMarkPath.Text + "','" + txtZPLPrinter.Text  + "')" ;
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