namespace CuttingMake
{
    partial class frmLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            cmbClass = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            btnExit = new System.Windows.Forms.Button();
            txtPassword = new System.Windows.Forms.TextBox();
            btnLogin = new System.Windows.Forms.Button();
            cmbUser = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            label1.Location = new System.Drawing.Point(35, 31);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(79, 20);
            label1.TabIndex = 17;
            label1.Text = "班 次：";
            label1.Visible = false;
            // 
            // cmbClass
            // 
            cmbClass.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            cmbClass.FormattingEnabled = true;
            cmbClass.Items.AddRange(new object[] { "A班", "B班", "C班" });
            cmbClass.Location = new System.Drawing.Point(146, 31);
            cmbClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            cmbClass.Name = "cmbClass";
            cmbClass.Size = new System.Drawing.Size(225, 27);
            cmbClass.TabIndex = 16;
            cmbClass.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            label4.Location = new System.Drawing.Point(35, 130);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(79, 20);
            label4.TabIndex = 15;
            label4.Text = "密 码：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            label3.Location = new System.Drawing.Point(35, 70);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(89, 20);
            label3.TabIndex = 14;
            label3.Text = "用户名：";
            // 
            // btnExit
            // 
            btnExit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btnExit.Location = new System.Drawing.Point(248, 217);
            btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(104, 42);
            btnExit.TabIndex = 12;
            btnExit.Text = "退出(&E)";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            txtPassword.Location = new System.Drawing.Point(146, 128);
            txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtPassword.MaxLength = 8;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(225, 29);
            txtPassword.TabIndex = 10;
            txtPassword.KeyPress += txtPassword_KeyPress;
            // 
            // btnLogin
            // 
            btnLogin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btnLogin.Location = new System.Drawing.Point(63, 217);
            btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(104, 42);
            btnLogin.TabIndex = 11;
            btnLogin.Text = "登陆(&L)";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // cmbUser
            // 
            cmbUser.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            cmbUser.FormattingEnabled = true;
            cmbUser.Location = new System.Drawing.Point(147, 68);
            cmbUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            cmbUser.Name = "cmbUser";
            cmbUser.Size = new System.Drawing.Size(224, 27);
            cmbUser.TabIndex = 13;
            cmbUser.SelectedIndexChanged += cmbUser_SelectedIndexChanged;
            // 
            // frmLoad
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(430, 310);
            Controls.Add(label1);
            Controls.Add(cmbClass);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnExit);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(cmbUser);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "frmLoad";
            Text = "登陆";
            Load += frmLoad_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox cmbUser;
    }
}