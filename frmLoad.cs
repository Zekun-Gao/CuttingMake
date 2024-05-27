using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;


namespace CuttingMake
{
    public partial class frmLoad : Form
    {
            public frmLoad()
            {
                InitializeComponent();
            }

            private void btnLogin_Click(object sender, EventArgs e)
            {
            //if (cmbUser.Text.Trim() != "" && txtPassword.Text != "")
            //{
            //    DialogResult = DialogResult.OK;
            //    OleDbDataReader dr;
            //    dr = clsSQL.GetDataReader("select user,password,level from tb_user where user='" + cmbUser.Text.Trim() + "' and PassWord='" + txtPassword.Text + "'");
            //    if (dr.Read())
            //    {

            //        clsLoad.MarkUser = dr.GetString(0);
            //        clsLoad.UserPassword = dr.GetString(1);
            //        clsLoad.LoadLevel = dr.GetString(2);
            //        //Conn.Close();
            //        DialogResult = DialogResult.OK;
            //    }
            //    else
            //    {
            //        //Conn.Close();
            //        MessageBox.Show("用户名或密码不正确！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        cmbUser.Focus();
            //        cmbUser.SelectAll();
            //        DialogResult = DialogResult.No;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("请输入完整！", "信息提示");
            //}
            if (cmbUser.Text.Trim() != "" && txtPassword.Text.Trim() != "")
            {
                string strSQL = "select UserPassword from tb_user where UserName='" + cmbUser.Text + "'";
                string txtpwd = clsSQL.strGetfield(strSQL);
                if ((txtPassword.Text.Trim() == txtpwd))
                {
                    clsLoad.MarkUser = cmbUser.Text;
                    //clsLoad.LoadClass = cmbClass.SelectedIndex.ToString();

                    strSQL = "select UserLevel from tb_user where UserName='" + cmbUser.Text + "' and UserPassword='" + txtPassword.Text + "'";
                    clsLoad.LoadLevel = clsSQL.strGetfield(strSQL);

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("密码错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("请输入完整！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

            private void frmLoad_Load(object sender, EventArgs e)
            {
              fillUserName();
            }

            private void fillUserName()
            {
                string strsql = "select UserName from tb_user where UserName is not null"; // 
                string _tmp = clsSQL.strGetfields(strsql);
                string[] tmp = _tmp.Split('@');
                cmbUser.Items.AddRange(tmp);
                if (cmbUser.Items.Count > 0) cmbUser.Text = cmbUser.Items[0].ToString();
                txtPassword.Focus();
            }



            private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar != 13) return;
                btnLogin_Click(null, null);
            }

            private void btnExit_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
            {
                txtPassword.Text = "";
                txtPassword.Focus();
            }
    }
}
