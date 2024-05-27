namespace CuttingMake
{
    partial class frmNewSCito
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
            btnAdd = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            txtSCITODate = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(82, 116);
            btnAdd.Margin = new System.Windows.Forms.Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(88, 33);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "添加(&N)";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new System.Drawing.Point(340, 116);
            btnExit.Margin = new System.Windows.Forms.Padding(4);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(88, 33);
            btnExit.TabIndex = 9;
            btnExit.Text = "退出(&E)";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // txtSCITODate
            // 
            txtSCITODate.Location = new System.Drawing.Point(159, 56);
            txtSCITODate.Margin = new System.Windows.Forms.Padding(4);
            txtSCITODate.Name = "txtSCITODate";
            txtSCITODate.Size = new System.Drawing.Size(253, 23);
            txtSCITODate.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(50, 59);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(92, 17);
            label6.TabIndex = 12;
            label6.Text = "生产批号日期：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(187, 20);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 17);
            label1.TabIndex = 14;
            label1.Text = "S02-CC-";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
            label2.ForeColor = System.Drawing.Color.Red;
            label2.Location = new System.Drawing.Point(239, 20);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(50, 17);
            label2.TabIndex = 15;
            label2.Text = "231205";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(288, 20);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 17);
            label3.TabIndex = 16;
            label3.Text = "-C6-1-L";
            // 
            // frmNewSCito
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(522, 162);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSCITODate);
            Controls.Add(label6);
            Controls.Add(btnExit);
            Controls.Add(btnAdd);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmNewSCito";
            Text = "新增订单";
            Load += frmNewCarItem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
#pragma warning disable CS0169 // 从不使用字段“frmNewSCito.txtZHPartSO1CC”
        private System.Windows.Forms.TextBox txtZHPartSO1CC;
#pragma warning restore CS0169 // 从不使用字段“frmNewSCito.txtZHPartSO1CC”
        private System.Windows.Forms.Label label2;
#pragma warning disable CS0169 // 从不使用字段“frmNewSCito.txtSN”
        private System.Windows.Forms.TextBox txtSN;
#pragma warning restore CS0169 // 从不使用字段“frmNewSCito.txtSN”
#pragma warning disable CS0169 // 从不使用字段“frmNewSCito.txtMarkPath”
        private System.Windows.Forms.TextBox txtMarkPath;
#pragma warning restore CS0169 // 从不使用字段“frmNewSCito.txtMarkPath”
        private System.Windows.Forms.Label label3;
#pragma warning disable CS0169 // 从不使用字段“frmNewSCito.label4”
        private System.Windows.Forms.Label label4;
#pragma warning restore CS0169 // 从不使用字段“frmNewSCito.label4”
#pragma warning disable CS0169 // 从不使用字段“frmNewSCito.txtZPLPrinter”
        private System.Windows.Forms.TextBox txtZPLPrinter;
#pragma warning restore CS0169 // 从不使用字段“frmNewSCito.txtZPLPrinter”
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
#pragma warning disable CS0169 // 从不使用字段“frmNewSCito.txtZHPartModel”
        private System.Windows.Forms.TextBox txtZHPartModel;
#pragma warning restore CS0169 // 从不使用字段“frmNewSCito.txtZHPartModel”
#pragma warning disable CS0169 // 从不使用字段“frmNewSCito.label5”
        private System.Windows.Forms.Label label5;
#pragma warning restore CS0169 // 从不使用字段“frmNewSCito.label5”
        private System.Windows.Forms.TextBox txtSCITODate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}