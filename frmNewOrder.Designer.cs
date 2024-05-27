namespace CuttingMake
{
    partial class frmNewOrder
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
            label1 = new System.Windows.Forms.Label();
            txtZHPartNumber = new System.Windows.Forms.TextBox();
            btnAdd = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            txtOrderNumber = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(47, 75);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(92, 17);
            label1.TabIndex = 0;
            label1.Text = "厂家物料编码：";
            // 
            // txtZHPartNumber
            // 
            txtZHPartNumber.Location = new System.Drawing.Point(177, 72);
            txtZHPartNumber.Margin = new System.Windows.Forms.Padding(4);
            txtZHPartNumber.Name = "txtZHPartNumber";
            txtZHPartNumber.Size = new System.Drawing.Size(253, 23);
            txtZHPartNumber.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(108, 116);
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
            btnExit.Location = new System.Drawing.Point(366, 116);
            btnExit.Margin = new System.Windows.Forms.Padding(4);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(88, 33);
            btnExit.TabIndex = 9;
            btnExit.Text = "退出(&E)";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // txtOrderNumber
            // 
            txtOrderNumber.Location = new System.Drawing.Point(177, 18);
            txtOrderNumber.Margin = new System.Windows.Forms.Padding(4);
            txtOrderNumber.Name = "txtOrderNumber";
            txtOrderNumber.Size = new System.Drawing.Size(253, 23);
            txtOrderNumber.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(47, 21);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(56, 17);
            label6.TabIndex = 12;
            label6.Text = "订单号：";
            // 
            // frmNewOrder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(522, 162);
            Controls.Add(txtOrderNumber);
            Controls.Add(label6);
            Controls.Add(btnExit);
            Controls.Add(btnAdd);
            Controls.Add(txtZHPartNumber);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmNewOrder";
            Text = "新增订单";
            Load += frmNewCarItem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
#pragma warning disable CS0169 // 从不使用字段“frmNewOrder.txtZHPartSO1CC”
        private System.Windows.Forms.TextBox txtZHPartSO1CC;
#pragma warning restore CS0169 // 从不使用字段“frmNewOrder.txtZHPartSO1CC”
#pragma warning disable CS0169 // 从不使用字段“frmNewOrder.label2”
        private System.Windows.Forms.Label label2;
#pragma warning restore CS0169 // 从不使用字段“frmNewOrder.label2”
#pragma warning disable CS0169 // 从不使用字段“frmNewOrder.txtSN”
        private System.Windows.Forms.TextBox txtSN;
#pragma warning restore CS0169 // 从不使用字段“frmNewOrder.txtSN”
#pragma warning disable CS0169 // 从不使用字段“frmNewOrder.txtMarkPath”
        private System.Windows.Forms.TextBox txtMarkPath;
#pragma warning restore CS0169 // 从不使用字段“frmNewOrder.txtMarkPath”
#pragma warning disable CS0169 // 从不使用字段“frmNewOrder.label3”
        private System.Windows.Forms.Label label3;
#pragma warning restore CS0169 // 从不使用字段“frmNewOrder.label3”
#pragma warning disable CS0169 // 从不使用字段“frmNewOrder.label4”
        private System.Windows.Forms.Label label4;
#pragma warning restore CS0169 // 从不使用字段“frmNewOrder.label4”
#pragma warning disable CS0169 // 从不使用字段“frmNewOrder.txtZPLPrinter”
        private System.Windows.Forms.TextBox txtZPLPrinter;
#pragma warning restore CS0169 // 从不使用字段“frmNewOrder.txtZPLPrinter”
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
#pragma warning disable CS0169 // 从不使用字段“frmNewOrder.txtZHPartModel”
        private System.Windows.Forms.TextBox txtZHPartModel;
#pragma warning restore CS0169 // 从不使用字段“frmNewOrder.txtZHPartModel”
#pragma warning disable CS0169 // 从不使用字段“frmNewOrder.label5”
        private System.Windows.Forms.Label label5;
#pragma warning restore CS0169 // 从不使用字段“frmNewOrder.label5”
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtZHPartNumber;
    }
}