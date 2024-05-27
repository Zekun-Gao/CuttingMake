using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace CuttingMake
{
    public partial class frmPartType1 : Form
    {
        private int selectID1 = -1;
        private int selectID2 = -1;
        private int selectID3 = -1;
        private string strsql = "";
        OleDbConnection thisconnection;

        OleDbDataAdapter da1;
        DataTable DT1 = new DataTable();
        OleDbCommandBuilder sb1;

        OleDbDataAdapter da2;
        DataTable DT2 = new DataTable();
        OleDbCommandBuilder sb2;

        OleDbDataAdapter da3;
        DataTable DT3 = new DataTable();
        OleDbCommandBuilder sb3;

        private OleDbConnection Conn = new OleDbConnection(clsSQL.strConn);
        public frmPartType1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                int nRow = dataGridView1.CurrentCell.RowIndex;
                selectID1 = int.Parse(dataGridView1[0, nRow].Value.ToString());
                selectID2 = -1;selectID3 = -1;
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount > 0)
            {
                int nRow = dataGridView2.CurrentCell.RowIndex;
                selectID2 = int.Parse(dataGridView2[0, nRow].Value.ToString());
                selectID1 = -1; selectID3 = -1;
            }
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.RowCount > 0)
            {
                int nRow = dataGridView3.CurrentCell.RowIndex;
                selectID3 = int.Parse(dataGridView3[0, nRow].Value.ToString());
                selectID1 = -1; selectID2 = -1;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmNewType f_NewType = new frmNewType();
            f_NewType.flashcarInfo += new delflash(New_flashcarInfo);
            f_NewType.ShowDialog();
        }

        private void btnAddNewOrd_Click(object sender, EventArgs e)
        {
            frmNewOrder f_NewOrder = new frmNewOrder();
            f_NewOrder.flashcarInfo += new delflash(New_flashcarInfo);
            f_NewOrder.ShowDialog();
        }
        private void btnAddNewSCito_Click(object sender, EventArgs e)
        {
            frmNewSCito f_NewSCito = new frmNewSCito();
            f_NewSCito.flashcarInfo += new delflash(New_flashcarInfo);
            f_NewSCito.ShowDialog();
        }

        void New_flashcarInfo()
        {
            LoadCarInfo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewPartType_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadCarInfo();
        }
        private void LoadCarInfo()
        {
            strsql = "select * from tb_PartType order by id asc";
            thisconnection = new OleDbConnection(clsSQL.strConn);
            da1 = new OleDbDataAdapter(strsql, thisconnection);
            sb1 = new OleDbCommandBuilder(da1);
            DT1 = new DataTable();
            da1.Fill(DT1);
            dataGridView1.DataSource = DT1;

            strsql = "select * from tb_OrderNumber order by id asc";
            thisconnection = new OleDbConnection(clsSQL.strConn);
            da2 = new OleDbDataAdapter(strsql, thisconnection);
            sb2 = new OleDbCommandBuilder(da2);
            DT2 = new DataTable();
            da2.Fill(DT2);
            dataGridView2.DataSource = DT2;

            strsql = "select * from tb_ITODate order by id asc";
            thisconnection = new OleDbConnection(clsSQL.strConn);
            da3 = new OleDbDataAdapter(strsql, thisconnection);
            sb3 = new OleDbCommandBuilder(da3);
            DT3 = new DataTable();
            da3.Fill(DT3);
            dataGridView3.DataSource = DT3;

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectID1 == -1&& selectID2 == -1&& selectID3 == -1)
            {
                MessageBox.Show("请选择要删除的行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes) return;

            if (selectID1 != -1)
            {
                strsql = "delete from tb_PartType where id=" + selectID1;
                int i = clsSQL.intExecuteQuery(strsql);
                if (i > 0)
                {
                    selectID1 = -1;
                    LoadCarInfo();
                    MessageBox.Show("操作成功");
                }
            }
            if (selectID2 != -1)
            {
                strsql = "delete from tb_OrderNumber where id=" + selectID2;
                int i = clsSQL.intExecuteQuery(strsql);
                if (i > 0)
                {
                    selectID2 = -1;
                    LoadCarInfo();
                    MessageBox.Show("操作成功");
                }
            }

            if (selectID3 != -1)
            {
                strsql = "delete from tb_ITODate where id=" + selectID3;
                int i = clsSQL.intExecuteQuery(strsql);
                if (i > 0)
                {
                    selectID3 = -1;
                    LoadCarInfo();
                    MessageBox.Show("操作成功");
                }
            }

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectID1 == -1 && selectID2 == -1 && selectID3 == -1)
            {
                MessageBox.Show("请选择要更新的行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (selectID1 != -1)
            {
                da1.UpdateCommand = sb1.GetUpdateCommand();
                int i = da1.Update(DT1);
                if (i > 0)
                {
                    MessageBox.Show("成功更新" + i.ToString() + "条数据");
                }
            }
            if (selectID2 != -1)
            {
                da2.UpdateCommand = sb2.GetUpdateCommand();
                int i = da2.Update(DT2);
                if (i > 0)
                {
                    MessageBox.Show("成功更新" + i.ToString() + "条数据");
                }
            }
            if (selectID3 != -1)
            {
                da3.UpdateCommand = sb3.GetUpdateCommand();
                int i = da3.Update(DT3);
                if (i > 0)
                {
                    MessageBox.Show("成功更新" + i.ToString() + "条数据");
                }
            }


        }

        private void MarkedRecode()
        {

            string strsql = "select top 100 * from tb_CuttingLog  order by ID desc";

            OleDbDataAdapter mark_da = new OleDbDataAdapter();
            DataSet mark_ds = new DataSet();
            OleDbCommand thisCommand = new OleDbCommand(strsql);
            thisCommand.Connection = Conn;
            mark_da.SelectCommand = thisCommand;
            mark_da.Fill(mark_ds, "tb_mark");
            dataGridView1.DataSource = mark_ds.Tables[0];
        }


    }
}