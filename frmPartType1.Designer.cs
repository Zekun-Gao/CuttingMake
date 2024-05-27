namespace CuttingMake
{
    partial class frmPartType1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox1 = new System.Windows.Forms.GroupBox();
            btnAddNewType = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            dataGridView3 = new System.Windows.Forms.DataGridView();
            dataGridView2 = new System.Windows.Forms.DataGridView();
            btnExit = new System.Windows.Forms.Button();
            btnAddNewOrd = new System.Windows.Forms.Button();
            btnAddNewSCito = new System.Windows.Forms.Button();
            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(4, 20);
            dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 23;
            dataGridView1.Size = new System.Drawing.Size(1235, 248);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new System.Drawing.Point(9, 10);
            groupBox1.Margin = new System.Windows.Forms.Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4);
            groupBox1.Size = new System.Drawing.Size(1243, 272);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "标签信息";
            // 
            // btnAddNewType
            // 
            btnAddNewType.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            btnAddNewType.Location = new System.Drawing.Point(1260, 52);
            btnAddNewType.Margin = new System.Windows.Forms.Padding(4);
            btnAddNewType.Name = "btnAddNewType";
            btnAddNewType.Size = new System.Drawing.Size(120, 57);
            btnAddNewType.TabIndex = 21;
            btnAddNewType.Text = "添加产品型号";
            btnAddNewType.UseVisualStyleBackColor = true;
            btnAddNewType.Click += btnAddNew_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(622, 539);
            btnDelete.Margin = new System.Windows.Forms.Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(120, 33);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "删除(&D)";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView3.Location = new System.Drawing.Point(4, 20);
            dataGridView3.Margin = new System.Windows.Forms.Padding(4);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowTemplate.Height = 23;
            dataGridView3.Size = new System.Drawing.Size(404, 187);
            dataGridView3.TabIndex = 13;
            dataGridView3.CellClick += dataGridView3_CellClick;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView2.Location = new System.Drawing.Point(4, 20);
            dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 23;
            dataGridView2.Size = new System.Drawing.Size(442, 187);
            dataGridView2.TabIndex = 12;
            dataGridView2.CellClick += dataGridView2_CellClick;
            // 
            // btnExit
            // 
            btnExit.Location = new System.Drawing.Point(823, 539);
            btnExit.Margin = new System.Windows.Forms.Padding(4);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(117, 33);
            btnExit.TabIndex = 24;
            btnExit.Text = "退出(&E)";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnAddNewOrd
            // 
            btnAddNewOrd.Location = new System.Drawing.Point(485, 323);
            btnAddNewOrd.Margin = new System.Windows.Forms.Padding(4);
            btnAddNewOrd.Name = "btnAddNewOrd";
            btnAddNewOrd.Size = new System.Drawing.Size(117, 44);
            btnAddNewOrd.TabIndex = 25;
            btnAddNewOrd.Text = "添加订单号";
            btnAddNewOrd.UseVisualStyleBackColor = true;
            btnAddNewOrd.Click += btnAddNewOrd_Click;
            // 
            // btnAddNewSCito
            // 
            btnAddNewSCito.Location = new System.Drawing.Point(1112, 323);
            btnAddNewSCito.Margin = new System.Windows.Forms.Padding(4);
            btnAddNewSCito.Name = "btnAddNewSCito";
            btnAddNewSCito.Size = new System.Drawing.Size(117, 44);
            btnAddNewSCito.TabIndex = 26;
            btnAddNewSCito.Text = "添加生产批号";
            btnAddNewSCito.UseVisualStyleBackColor = true;
            btnAddNewSCito.Click += btnAddNewSCito_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView2);
            groupBox3.Location = new System.Drawing.Point(13, 290);
            groupBox3.Margin = new System.Windows.Forms.Padding(4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(4);
            groupBox3.Size = new System.Drawing.Size(450, 211);
            groupBox3.TabIndex = 27;
            groupBox3.TabStop = false;
            groupBox3.Text = "新订单号信息";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dataGridView3);
            groupBox4.Location = new System.Drawing.Point(679, 290);
            groupBox4.Margin = new System.Windows.Forms.Padding(4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(4);
            groupBox4.Size = new System.Drawing.Size(412, 211);
            groupBox4.TabIndex = 28;
            groupBox4.TabStop = false;
            groupBox4.Text = "新增生产批次信息";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new System.Drawing.Point(432, 539);
            btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(117, 33);
            btnUpdate.TabIndex = 22;
            btnUpdate.Text = "更新(&U)";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // frmPartType1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(1393, 595);
            Controls.Add(btnExit);
            Controls.Add(groupBox4);
            Controls.Add(btnDelete);
            Controls.Add(btnAddNewSCito);
            Controls.Add(btnAddNewType);
            Controls.Add(btnUpdate);
            Controls.Add(btnAddNewOrd);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmPartType1";
            Text = "标签信息管理";
            Load += frmNewPartType_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }




        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddNewType;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnAddNewOrd;
        private System.Windows.Forms.Button btnAddNewSCito;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnUpdate;
    }
}