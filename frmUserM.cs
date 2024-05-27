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
    public partial class frmUserM : Form
    {
        private OleDbDataAdapter mark_da = new OleDbDataAdapter();
        private OleDbConnection Conn = new OleDbConnection(clsSQL.strConn);
        private BindingSource mark_bind = new BindingSource();
        private DataSet mark_ds = new DataSet();

        public frmUserM()
        {
            InitializeComponent();
        }


        private void frmUserM_Load(object sender, EventArgs e)
        {
            frmLoad();
        }
        //
        private void frmLoad()
        {
            ////OleDbDataAdapter mark_da = new OleDbDataAdapter();
            OleDbCommand thisCommand = new OleDbCommand("select * from tb_user");
            thisCommand.Connection = Conn;
            Conn.Open();
            mark_da.SelectCommand = thisCommand;
            mark_da.Fill(mark_ds, "tb_mark");
            dataGridView1.DataSource = mark_ds.Tables[0];
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.cmbLevel.Items.Clear();
            ////this.cmbLevel.Items.Add("H");
            this.cmbLevel.Items.Add("H");
            this.cmbLevel.Items.Add("L");
        }

        //显示选中用户信息
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            this.tbCode.Text = dataGridView1[2, i].Value.ToString();
            this.cmbName.Text = dataGridView1[1, i].Value.ToString();
            this.cmbLevel.Text = dataGridView1[3, i].Value.ToString();
        }

        //给指定用户修改密码
        private void btnEditCode_Click(object sender, EventArgs e)
        {
            
            EditCode();
            RefreshData();
        }

        //修改密码
        private  void EditCode()
        {
            try
            {
                if (cmbName.Text == "" || tbCode.Text == "" || cmbLevel.Text == "")
                {
                    MessageBox.Show("请先选中需要修改的用户信息！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {

                    string strSql = "update [tb_user] set [UserPassword]='" + this.tbCode.Text + "'  where [UserName]='" + this.cmbName.Text + "' ";

                    int i = clsSQL.intExecuteQuery(strSql);
                    if (i != 1)
                    {
                        MessageBox.Show("密码修改失败！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("密码修改成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                clsLoad.WriteLog("密码修改出错:"+ex.Message.ToString());
            }
          
        }

        //删除用户，只能删除普通用户，不可删除管理员
        private void btnDel_Click(object sender, EventArgs e)
        {

            DelUser();
            RefreshData();
        }

        //删除用户
        private void DelUser()
        {
            try
            {
                if (cmbName.Text == "")
                {
                    MessageBox.Show("没有可删除的用户信息,请先选中一用户后再删除!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else if (cmbLevel.Text == "H")
                {
                    MessageBox.Show("不可删除管理员用户！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                string strSql = "delete from tb_user where UserName='" + cmbName.Text.Trim() + "'";
                int result = clsSQL.intExecuteQuery(strSql);
                if (result == 0)
                {
                    MessageBox.Show("删除用户失败！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else
                {
                    MessageBox.Show("删除用户成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsLoad.WriteLog("删除用户出错："+ex.Message.ToString());
            }
        }

        //注册用户，不可重名，UserName必须唯一
        private void btnRegister_Click(object sender, EventArgs e)
        {
        
            RegisterUser();
            RefreshData();
            
        }
        //注册用户
        private  void RegisterUser()
        {

            try
            {
                string strSQL = null;

                if (cmbName.Text == "" || tbCode.Text == "" || cmbLevel.Text == "")
                {
                    MessageBox.Show("信息不能为空", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else if (cmbName.Text != "" && tbCode.Text != "" && cmbLevel.Text != "")
                {
                    strSQL = "select count(*) from tb_user where UserName='" + cmbName.Text.Trim() + "'";
                    strSQL = clsSQL.strGetfield(strSQL);
                    if ("0" != strSQL)
                    {
                        MessageBox.Show("注册用户错误,数据库已经存在该用户：" + cmbName.Text, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    //else if (cmbLevel.Text == "H")
                    //{
                    //    MessageBox.Show("没有权限注册管理员用户！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //    return;
                    //}
                    else
                    {

                        strSQL = "insert into [tb_user]([UserName],[UserPassword],[UserLevel])  values('" + cmbName.Text + "','" + tbCode.Text + "','" + cmbLevel.Text + "')";
                        int i = clsSQL.intExecuteQuery(strSQL);
                        if (i != 1)
                        {
                            MessageBox.Show("注册用户失败，请重新注册！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("注册用户成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLoad.WriteLog("注册用户出错："+ex.Message.ToString());
            }
        }


        //刷新显示数据
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {

            try
            {
                ////OleDbDataAdapter mark_da = new OleDbDataAdapter();
                DataSet mark_ds = new DataSet();
                OleDbCommand thisCommand = new OleDbCommand(" select  * from [tb_user] ");
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
                clsLoad.WriteLog("刷新数据库显示出错:"+ex.Message.ToString());
            }
        }

      

    }
}
