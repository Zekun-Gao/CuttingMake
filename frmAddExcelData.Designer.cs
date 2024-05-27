namespace CuttingMake
{
    partial class frmAddExcelData
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
            button1 = new System.Windows.Forms.Button();
            btnIntoExl = new System.Windows.Forms.Button();
            txtStartID = new System.Windows.Forms.MaskedTextBox();
            txtEndID = new System.Windows.Forms.MaskedTextBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            btnDel = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            btnUpdate = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(212, 215);
            button1.Margin = new System.Windows.Forms.Padding(4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(125, 41);
            button1.TabIndex = 19;
            button1.Text = "刷新";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnIntoExl
            // 
            btnIntoExl.Location = new System.Drawing.Point(56, 215);
            btnIntoExl.Margin = new System.Windows.Forms.Padding(4);
            btnIntoExl.Name = "btnIntoExl";
            btnIntoExl.Size = new System.Drawing.Size(125, 41);
            btnIntoExl.TabIndex = 20;
            btnIntoExl.Text = "导入数据";
            btnIntoExl.UseVisualStyleBackColor = true;
            btnIntoExl.Click += btnIntoExl_Click;
            // 
            // txtStartID
            // 
            txtStartID.Location = new System.Drawing.Point(88, 390);
            txtStartID.Margin = new System.Windows.Forms.Padding(4);
            txtStartID.Mask = "99999999999999999999";
            txtStartID.Name = "txtStartID";
            txtStartID.Size = new System.Drawing.Size(108, 23);
            txtStartID.TabIndex = 21;
            txtStartID.Visible = false;
            // 
            // txtEndID
            // 
            txtEndID.Location = new System.Drawing.Point(226, 390);
            txtEndID.Margin = new System.Windows.Forms.Padding(4);
            txtEndID.Mask = "9999999999999999999999";
            txtEndID.Name = "txtEndID";
            txtEndID.Size = new System.Drawing.Size(117, 23);
            txtEndID.TabIndex = 22;
            txtEndID.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(56, 390);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(21, 17);
            label4.TabIndex = 23;
            label4.Text = "ID";
            label4.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(201, 393);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(20, 17);
            label5.TabIndex = 24;
            label5.Text = "至";
            label5.Visible = false;
            // 
            // btnDel
            // 
            btnDel.Location = new System.Drawing.Point(212, 315);
            btnDel.Margin = new System.Windows.Forms.Padding(4);
            btnDel.Name = "btnDel";
            btnDel.Size = new System.Drawing.Size(125, 41);
            btnDel.TabIndex = 25;
            btnDel.Text = "删除数据";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            label1.Location = new System.Drawing.Point(88, 55);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(253, 28);
            label1.TabIndex = 26;
            label1.Text = "注意：Excel数据从第一行";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            label2.Location = new System.Drawing.Point(88, 93);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(264, 28);
            label2.TabIndex = 27;
            label2.Text = "第一列开始写入表格共两列";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            label3.Location = new System.Drawing.Point(119, 132);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(159, 28);
            label3.TabIndex = 28;
            label3.Text = "分切卷号，长度";
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnDel);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtStartID);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtEndID);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnIntoExl);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label5);
            panel1.Dock = System.Windows.Forms.DockStyle.Right;
            panel1.Location = new System.Drawing.Point(571, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(378, 485);
            panel1.TabIndex = 29;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new System.Drawing.Point(56, 315);
            btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(125, 41);
            btnUpdate.TabIndex = 29;
            btnUpdate.Text = "更新(&U)";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(571, 485);
            panel2.TabIndex = 30;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(0, 0);
            dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 23;
            dataGridView1.Size = new System.Drawing.Size(569, 483);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // frmAddExcelData
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(949, 485);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmAddExcelData";
            Text = "frmAddExcelData";
            Load += frmAddExcelData_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIntoExl;
        private System.Windows.Forms.MaskedTextBox txtStartID;
        private System.Windows.Forms.MaskedTextBox txtEndID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}