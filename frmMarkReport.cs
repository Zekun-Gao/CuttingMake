using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Diagnostics.CodeAnalysis;


namespace CuttingMake
{
    public partial class frmMarkReport : Form
    {
        public frmMarkReport()
        {
            InitializeComponent();
        }
        private OleDbDataAdapter mark_da = new OleDbDataAdapter();
        string datatime = DateTime.Now.ToString("yyyyMMdd");
        private OleDbDataAdapter da = new OleDbDataAdapter();

        private OleDbConnection Conn = new OleDbConnection(clsSQL.strConn);
        private BindingSource mark_bind = new BindingSource();
        private DataSet mark_ds = new DataSet();



        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.CheckData();


        }

        //数据查询
        private void CheckData()
        {
            try
            {
                string selectStr = "  where  ";
                if (checkBox1.Checked)
                {
                    if (txtOrderNumber.Text.Trim() == "")
                    {
                        MessageBox.Show("请输入查询信息！", "信息提示");
                        txtOrderNumber.Focus();
                        return;
                    }
                    selectStr += " ZHOrderNumber  like '%" + txtOrderNumber.Text.Trim() + "%'";
                }
                else if (checkBox2.Checked)
                {
                    if (checkBox1.Checked)
                    {
                        selectStr += " and  ";
                    }
                    //// ASP.NET在操作日期型数据的时候,向ACCESS中的"时间/日期"字段中插入数据需要两边加#，而SQL SERVER不用。 这可能是C#中的日期类型无法直接转换成Access中的日期类型OleDbType.DBDate所致，因此上面代码向ACCESS中的"时间/日期"字段中插入DateTime.Now时出现错误信息“标准表达式中数据类型不匹配。” 
                    ////如代码：String Sql = "update  ly set re_message='" + TextBox1.Text + "',re_date=#" + DateTime.Now + "# where ID=" + page_id;
                    //string startTime = dateTimePickerStartDay.Value.ToString("yyMMdd") + dateTimePickerStartHour.Value.ToString("HHmmss");
                    //string endTime = dateTimePickerEndDay.Value.ToString("yyMMdd") + dateTimePickerEndHour.Value.ToString("HHmmss");
                    selectStr += "( PrintDate between #" + dateTimePickerStartDay.Value + "# and #" + dateTimePickerEndDay.Value + "#) ";
                    //selectStr += "( MarkDate between  "+startTime+" and  "+endTime+") ";
                }
                else
                {
                    selectStr = "";
                }

                OleDbDataAdapter mark_da = new OleDbDataAdapter();
                DataSet mark_ds = new DataSet();
                OleDbCommand thisCommand = new OleDbCommand(" select * from tb_CuttingLog " + selectStr);
                thisCommand.Connection = Conn;
                mark_da.SelectCommand = thisCommand;
                mark_da.Fill(mark_ds, "tb_mark");
                dataGridView1.DataSource = mark_ds.Tables[0];
                checkBox1.Focus();
            }
            catch (Exception ex)
            {
                clsLoad.WriteLog("数据查询出错：" + ex.Message.ToString());
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnExp_Click(object sender, EventArgs e)
        {
            //ExportDataGridView(null,null);

            NPOIHelper export = new NPOIHelper();
            export.ExportExcel(("标签打印记录" + datatime + ".xlsx"), dataGridView1, "宋体", 11);//默认文件名,DataGridView控件的名称,字体,字号


        }


        //数据Excel导出
        private void ExportDataGridView(object sender, EventArgs e)
        {
            int i;
            int j;
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    return;
                }
                Microsoft.Office.Interop.Excel.Application myExcel = new Microsoft.Office.Interop.Excel.Application();
                myExcel.Workbooks.Add(true);
                myExcel.Visible = true;
                for (i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    myExcel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                for (i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        myExcel.Cells[i + 2, j + 1] = "'" + dataGridView1[j, i].Value.ToString();
                    }
                }
                myExcel.Quit();
                myExcel = null;
            }
            catch (Exception ex)
            {
                clsLoad.WriteLog("数据Excel出错：" + ex.Message.ToString());
            }


        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            this.DelData();
            button1_Click(null,null);
        }

        //数据删除
        private void DelData()
        {
            try
            {
                if (!checkBox3.Checked)
                {
                    MessageBox.Show("请先勾选<记录删除>！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (this.checkBox3.Checked == true)
                {
                    if (txtStartID.Text == "" || txtEndID.Text == "")
                    {
                        MessageBox.Show("ID信息不能为空！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (Convert.ToInt32(txtStartID.Text) > Convert.ToInt32(txtEndID.Text))
                    {
                        MessageBox.Show("ID值必须从小到大！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    else if (txtStartID.Text != "" && txtEndID.Text != "")
                    {
                        string strStartId = txtStartID.Text.Trim();
                        string strEndId = txtEndID.Text.Trim();
                        string strSql = " delete from tb_CuttingLog where ID between " + strStartId + " and " + strEndId;
                        int result = clsSQL.intExecuteQuery(strSql);
                        if (result == 0)
                        {
                            MessageBox.Show("0条记录受影响！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else if (result > 0)
                        {
                            MessageBox.Show(result.ToString() + " 条记录被删除成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLoad.WriteLog("数据删除出错：" + ex.Message.ToString());
            }

        }

        private void frmMarkReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            frmLoad();
        }
        //
        private void frmLoad()
        {
            OleDbDataAdapter mark_da = new OleDbDataAdapter();
            OleDbCommand thisCommand = new OleDbCommand("select * from tb_CuttingLog");
            thisCommand.Connection = Conn;
            Conn.Open();
            mark_da.SelectCommand = thisCommand;
            mark_da.Fill(mark_ds, "tb_mark");
            dataGridView1.DataSource = mark_ds.Tables[0];
            //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ////OleDbDataAdapter mark_da = new OleDbDataAdapter();
                DataSet mark_ds = new DataSet();
                OleDbCommand thisCommand = new OleDbCommand(" select  * from tb_CuttingLog ");
                thisCommand.Connection = Conn;
                mark_da.SelectCommand = thisCommand;
                mark_da.Fill(mark_ds, "tb_mark");
                dataGridView1.DataSource = mark_ds.Tables[0];
                dataGridView1.Refresh();
                this.Refresh();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                clsLoad.WriteLog("刷新数据库显示出错:" + ex.Message.ToString());
            }
        }
    }
}