namespace CuttingMake
{
    partial class frmMarkReport
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
            panel1 = new System.Windows.Forms.Panel();
            button1 = new System.Windows.Forms.Button();
            txtEndID = new System.Windows.Forms.MaskedTextBox();
            txtStartID = new System.Windows.Forms.MaskedTextBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            checkBox3 = new System.Windows.Forms.CheckBox();
            btnExp = new System.Windows.Forms.Button();
            btnDel = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            btnCheck = new System.Windows.Forms.Button();
            dateTimePickerEndDay = new System.Windows.Forms.DateTimePicker();
            label3 = new System.Windows.Forms.Label();
            dateTimePickerStartDay = new System.Windows.Forms.DateTimePicker();
            label2 = new System.Windows.Forms.Label();
            checkBox2 = new System.Windows.Forms.CheckBox();
            txtOrderNumber = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            checkBox1 = new System.Windows.Forms.CheckBox();
            panel2 = new System.Windows.Forms.Panel();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(txtEndID);
            panel1.Controls.Add(txtStartID);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(checkBox3);
            panel1.Controls.Add(btnExp);
            panel1.Controls.Add(btnDel);
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnCheck);
            panel1.Controls.Add(dateTimePickerEndDay);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dateTimePickerStartDay);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(txtOrderNumber);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(checkBox1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1265, 148);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(999, 56);
            button1.Margin = new System.Windows.Forms.Padding(4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(113, 78);
            button1.TabIndex = 18;
            button1.Text = "刷新";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtEndID
            // 
            txtEndID.Location = new System.Drawing.Point(493, 105);
            txtEndID.Margin = new System.Windows.Forms.Padding(4);
            txtEndID.Mask = "9999999999999999999999";
            txtEndID.Name = "txtEndID";
            txtEndID.Size = new System.Drawing.Size(160, 23);
            txtEndID.TabIndex = 17;
            // 
            // txtStartID
            // 
            txtStartID.Location = new System.Drawing.Point(198, 105);
            txtStartID.Margin = new System.Windows.Forms.Padding(4);
            txtStartID.Mask = "99999999999999999999";
            txtStartID.Name = "txtStartID";
            txtStartID.Size = new System.Drawing.Size(142, 23);
            txtStartID.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(456, 109);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(20, 17);
            label5.TabIndex = 15;
            label5.Text = "至";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(167, 110);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(21, 17);
            label4.TabIndex = 13;
            label4.Text = "ID";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new System.Drawing.Point(13, 106);
            checkBox3.Margin = new System.Windows.Forms.Padding(4);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new System.Drawing.Size(75, 21);
            checkBox3.TabIndex = 12;
            checkBox3.Text = "记录删除";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // btnExp
            // 
            btnExp.Location = new System.Drawing.Point(837, 56);
            btnExp.Margin = new System.Windows.Forms.Padding(4);
            btnExp.Name = "btnExp";
            btnExp.Size = new System.Drawing.Size(125, 33);
            btnExp.TabIndex = 11;
            btnExp.Text = "导出";
            btnExp.UseVisualStyleBackColor = true;
            btnExp.Click += btnExp_Click;
            // 
            // btnDel
            // 
            btnDel.Location = new System.Drawing.Point(689, 101);
            btnDel.Margin = new System.Windows.Forms.Padding(4);
            btnDel.Name = "btnDel";
            btnDel.Size = new System.Drawing.Size(125, 33);
            btnDel.TabIndex = 10;
            btnDel.Text = "删除数据";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new System.Drawing.Point(837, 101);
            btnExit.Margin = new System.Windows.Forms.Padding(4);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(125, 33);
            btnExit.TabIndex = 9;
            btnExit.Text = "退出";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnCheck
            // 
            btnCheck.Location = new System.Drawing.Point(689, 56);
            btnCheck.Margin = new System.Windows.Forms.Padding(4);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new System.Drawing.Size(125, 33);
            btnCheck.TabIndex = 8;
            btnCheck.Text = "查询统计";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // dateTimePickerEndDay
            // 
            dateTimePickerEndDay.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            dateTimePickerEndDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePickerEndDay.Location = new System.Drawing.Point(493, 58);
            dateTimePickerEndDay.Margin = new System.Windows.Forms.Padding(4);
            dateTimePickerEndDay.Name = "dateTimePickerEndDay";
            dateTimePickerEndDay.ShowUpDown = true;
            dateTimePickerEndDay.Size = new System.Drawing.Size(174, 23);
            dateTimePickerEndDay.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(456, 64);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(20, 17);
            label3.TabIndex = 6;
            label3.Text = "至";
            // 
            // dateTimePickerStartDay
            // 
            dateTimePickerStartDay.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            dateTimePickerStartDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePickerStartDay.Location = new System.Drawing.Point(198, 58);
            dateTimePickerStartDay.Margin = new System.Windows.Forms.Padding(4);
            dateTimePickerStartDay.Name = "dateTimePickerStartDay";
            dateTimePickerStartDay.ShowUpDown = true;
            dateTimePickerStartDay.Size = new System.Drawing.Size(180, 23);
            dateTimePickerStartDay.TabIndex = 5;
            dateTimePickerStartDay.Value = new System.DateTime(2014, 1, 21, 21, 39, 48, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(130, 64);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(48, 17);
            label2.TabIndex = 4;
            label2.Text = "日    期";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new System.Drawing.Point(13, 61);
            checkBox2.Margin = new System.Windows.Forms.Padding(4);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new System.Drawing.Size(75, 21);
            checkBox2.TabIndex = 3;
            checkBox2.Text = "日期查询";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // txtOrderNumber
            // 
            txtOrderNumber.Location = new System.Drawing.Point(198, 13);
            txtOrderNumber.Margin = new System.Windows.Forms.Padding(4);
            txtOrderNumber.Name = "txtOrderNumber";
            txtOrderNumber.Size = new System.Drawing.Size(233, 23);
            txtOrderNumber.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(130, 17);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(68, 17);
            label1.TabIndex = 1;
            label1.Text = "订单号信息";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox1.Location = new System.Drawing.Point(13, 16);
            checkBox1.Margin = new System.Windows.Forms.Padding(4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(75, 21);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "条码查询";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 148);
            panel2.Margin = new System.Windows.Forms.Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(1265, 314);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(0, 0);
            dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 23;
            dataGridView1.Size = new System.Drawing.Size(1263, 312);
            dataGridView1.TabIndex = 1;
            // 
            // frmMarkReport
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1265, 462);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmMarkReport";
            Text = "打印记录查询";
            Load += frmMarkReport_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExp;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.MaskedTextBox txtStartID;
        private System.Windows.Forms.MaskedTextBox txtEndID;
        private System.Windows.Forms.Button button1;
    }
}