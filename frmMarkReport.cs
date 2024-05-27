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

        //���ݲ�ѯ
        private void CheckData()
        {
            try
            {
                string selectStr = "  where  ";
                if (checkBox1.Checked)
                {
                    if (txtOrderNumber.Text.Trim() == "")
                    {
                        MessageBox.Show("�������ѯ��Ϣ��", "��Ϣ��ʾ");
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
                    //// ASP.NET�ڲ������������ݵ�ʱ��,��ACCESS�е�"ʱ��/����"�ֶ��в���������Ҫ���߼�#����SQL SERVER���á� �������C#�е����������޷�ֱ��ת����Access�е���������OleDbType.DBDate���£�������������ACCESS�е�"ʱ��/����"�ֶ��в���DateTime.Nowʱ���ִ�����Ϣ����׼���ʽ���������Ͳ�ƥ�䡣�� 
                    ////����룺String Sql = "update  ly set re_message='" + TextBox1.Text + "',re_date=#" + DateTime.Now + "# where ID=" + page_id;
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
                clsLoad.WriteLog("���ݲ�ѯ����" + ex.Message.ToString());
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
            export.ExportExcel(("��ǩ��ӡ��¼" + datatime + ".xlsx"), dataGridView1, "����", 11);//Ĭ���ļ���,DataGridView�ؼ�������,����,�ֺ�


        }


        //����Excel����
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
                clsLoad.WriteLog("����Excel����" + ex.Message.ToString());
            }


        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            this.DelData();
            button1_Click(null,null);
        }

        //����ɾ��
        private void DelData()
        {
            try
            {
                if (!checkBox3.Checked)
                {
                    MessageBox.Show("���ȹ�ѡ<��¼ɾ��>��", "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (this.checkBox3.Checked == true)
                {
                    if (txtStartID.Text == "" || txtEndID.Text == "")
                    {
                        MessageBox.Show("ID��Ϣ����Ϊ�գ�", "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (Convert.ToInt32(txtStartID.Text) > Convert.ToInt32(txtEndID.Text))
                    {
                        MessageBox.Show("IDֵ�����С����", "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show("0����¼��Ӱ�죡", "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else if (result > 0)
                        {
                            MessageBox.Show(result.ToString() + " ����¼��ɾ���ɹ���", "��Ϣ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLoad.WriteLog("����ɾ������" + ex.Message.ToString());
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
                clsLoad.WriteLog("ˢ�����ݿ���ʾ����:" + ex.Message.ToString());
            }
        }
    }
}