using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataTable = System.Data.DataTable;


namespace CuttingMake
{
    public partial class frmAddExcelData : Form
    {

        public frmAddExcelData()
        {
            InitializeComponent();
            LoadCarInfo();
        }
        NPOIHelper NPOIHelper = new NPOIHelper();
        private int selectID1 = -1;
        private string strsql = "";
        OleDbConnection thisconnection;

        OleDbDataAdapter da1;
        DataTable DT1 = new DataTable();
        OleDbCommandBuilder sb1;

        private OleDbConnection Conn = new OleDbConnection(clsSQL.strConn);


        private void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                int nRow = dataGridView1.CurrentCell.RowIndex;
                selectID1 = int.Parse(dataGridView1[0, nRow].Value.ToString());
            }
        }

        private void btnIntoExl_Click(object sender, EventArgs e)
        {
            NPOIHelper.GetExcelxlsx();
            LoadCarInfo();
        }

        private void LoadCarInfo()
        {
            strsql = "select * from tb_UpData order by id asc";
            thisconnection = new OleDbConnection(clsSQL.strConn);
            da1 = new OleDbDataAdapter(strsql, thisconnection);
            sb1 = new OleDbCommandBuilder(da1);
            DT1 = new DataTable();
            da1.Fill(DT1);
            dataGridView1.DataSource = DT1;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectID1 == -1)
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
        }

        //数据删除
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (selectID1 == -1)
            {
                MessageBox.Show("请选择要删除的行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes) return;

            if (selectID1 != -1)
            {
                strsql = "delete from tb_UpData where id=" + selectID1;
                int i = clsSQL.intExecuteQuery(strsql);
                if (i > 0)
                {
                    selectID1 = -1;
                    LoadCarInfo();
                    MessageBox.Show("操作成功");
                }
            }
        }

        private void frmAddExcelData_Load(object sender, EventArgs e)
        {
            LoadCarInfo();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadCarInfo();
        }
    }
}
