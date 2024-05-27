namespace CuttingMake
{
    partial class frmUserM
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
            cmbName = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            btnEditCode = new System.Windows.Forms.Button();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            label3 = new System.Windows.Forms.Label();
            cmbLevel = new System.Windows.Forms.ComboBox();
            btnRegister = new System.Windows.Forms.Button();
            btnDel = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();
            tbCode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(24, 368);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 17);
            label1.TabIndex = 11;
            label1.Text = "用户名：";
            // 
            // cmbName
            // 
            cmbName.BackColor = System.Drawing.SystemColors.Window;
            cmbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cmbName.ForeColor = System.Drawing.Color.Black;
            cmbName.FormattingEnabled = true;
            cmbName.Location = new System.Drawing.Point(99, 363);
            cmbName.Margin = new System.Windows.Forms.Padding(4);
            cmbName.Name = "cmbName";
            cmbName.Size = new System.Drawing.Size(128, 25);
            cmbName.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label2.Location = new System.Drawing.Point(233, 368);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 17);
            label2.TabIndex = 8;
            label2.Text = "密   码：";
            // 
            // btnEditCode
            // 
            btnEditCode.Location = new System.Drawing.Point(476, 421);
            btnEditCode.Margin = new System.Windows.Forms.Padding(4);
            btnEditCode.Name = "btnEditCode";
            btnEditCode.Size = new System.Drawing.Size(141, 47);
            btnEditCode.TabIndex = 10;
            btnEditCode.Text = "密码修改";
            btnEditCode.UseVisualStyleBackColor = true;
            btnEditCode.Click += btnEditCode_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(13, 13);
            dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 23;
            dataGridView1.Size = new System.Drawing.Size(622, 342);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(441, 368);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(62, 17);
            label3.TabIndex = 14;
            label3.Text = "权   限：";
            // 
            // cmbLevel
            // 
            cmbLevel.BackColor = System.Drawing.SystemColors.Window;
            cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cmbLevel.ForeColor = System.Drawing.Color.Black;
            cmbLevel.FormattingEnabled = true;
            cmbLevel.Location = new System.Drawing.Point(503, 363);
            cmbLevel.Margin = new System.Windows.Forms.Padding(4);
            cmbLevel.Name = "cmbLevel";
            cmbLevel.Size = new System.Drawing.Size(108, 25);
            cmbLevel.TabIndex = 15;
            // 
            // btnRegister
            // 
            btnRegister.Location = new System.Drawing.Point(24, 421);
            btnRegister.Margin = new System.Windows.Forms.Padding(4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new System.Drawing.Size(141, 47);
            btnRegister.TabIndex = 16;
            btnRegister.Text = "注册";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnDel
            // 
            btnDel.Location = new System.Drawing.Point(174, 421);
            btnDel.Margin = new System.Windows.Forms.Padding(4);
            btnDel.Name = "btnDel";
            btnDel.Size = new System.Drawing.Size(141, 47);
            btnDel.TabIndex = 17;
            btnDel.Text = "删除";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new System.Drawing.Point(325, 421);
            btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(141, 47);
            btnRefresh.TabIndex = 18;
            btnRefresh.Text = "刷新";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // tbCode
            // 
            tbCode.Location = new System.Drawing.Point(299, 363);
            tbCode.Margin = new System.Windows.Forms.Padding(4);
            tbCode.MaxLength = 8;
            tbCode.Name = "tbCode";
            tbCode.Size = new System.Drawing.Size(116, 23);
            tbCode.TabIndex = 19;
            // 
            // frmUserM
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(648, 490);
            Controls.Add(tbCode);
            Controls.Add(btnRefresh);
            Controls.Add(btnDel);
            Controls.Add(btnRegister);
            Controls.Add(cmbLevel);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(cmbName);
            Controls.Add(label2);
            Controls.Add(btnEditCode);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmUserM";
            Text = "用户管理界面";
            Load += frmUserM_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEditCode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox tbCode;



    }
}