namespace CuttingMake
{
    partial class frmNewType
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
            txtZHPartSO1CC = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtSN = new System.Windows.Forms.TextBox();
            txtMarkPath = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            txtZPLPrinter = new System.Windows.Forms.TextBox();
            btnAdd = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            txtZHPartModel = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            txtZHPartType = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(29, 75);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(118, 17);
            label1.TabIndex = 0;
            label1.Text = "批号前缀(S01-CC)：";
            // 
            // txtZHPartSO1CC
            // 
            txtZHPartSO1CC.Location = new System.Drawing.Point(166, 71);
            txtZHPartSO1CC.Margin = new System.Windows.Forms.Padding(4);
            txtZHPartSO1CC.Name = "txtZHPartSO1CC";
            txtZHPartSO1CC.Size = new System.Drawing.Size(184, 23);
            txtZHPartSO1CC.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(29, 194);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(104, 17);
            label2.TabIndex = 2;
            label2.Text = "厂家卷号开始号：";
            // 
            // txtSN
            // 
            txtSN.Location = new System.Drawing.Point(166, 191);
            txtSN.Margin = new System.Windows.Forms.Padding(4);
            txtSN.Name = "txtSN";
            txtSN.Size = new System.Drawing.Size(184, 23);
            txtSN.TabIndex = 3;
            // 
            // txtMarkPath
            // 
            txtMarkPath.Location = new System.Drawing.Point(166, 243);
            txtMarkPath.Margin = new System.Windows.Forms.Padding(4);
            txtMarkPath.Name = "txtMarkPath";
            txtMarkPath.Size = new System.Drawing.Size(184, 23);
            txtMarkPath.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(29, 246);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(68, 17);
            label3.TabIndex = 5;
            label3.Text = "标签模板：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(29, 303);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(80, 17);
            label4.TabIndex = 6;
            label4.Text = "目标打印机：";
            // 
            // txtZPLPrinter
            // 
            txtZPLPrinter.Location = new System.Drawing.Point(166, 299);
            txtZPLPrinter.Margin = new System.Windows.Forms.Padding(4);
            txtZPLPrinter.Name = "txtZPLPrinter";
            txtZPLPrinter.Size = new System.Drawing.Size(184, 23);
            txtZPLPrinter.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(405, 45);
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
            btnExit.Location = new System.Drawing.Point(405, 142);
            btnExit.Margin = new System.Windows.Forms.Padding(4);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(88, 33);
            btnExit.TabIndex = 9;
            btnExit.Text = "退出(&E)";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // txtZHPartModel
            // 
            txtZHPartModel.Location = new System.Drawing.Point(166, 130);
            txtZHPartModel.Margin = new System.Windows.Forms.Padding(4);
            txtZHPartModel.Name = "txtZHPartModel";
            txtZHPartModel.Size = new System.Drawing.Size(184, 23);
            txtZHPartModel.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(29, 135);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(98, 17);
            label5.TabIndex = 10;
            label5.Text = "分切宽度(mm)：";
            // 
            // txtZHPartType
            // 
            txtZHPartType.Location = new System.Drawing.Point(166, 18);
            txtZHPartType.Margin = new System.Windows.Forms.Padding(4);
            txtZHPartType.Name = "txtZHPartType";
            txtZHPartType.Size = new System.Drawing.Size(184, 23);
            txtZHPartType.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(29, 21);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(141, 17);
            label6.TabIndex = 12;
            label6.Text = "膜材型号(如F166-500)：";
            // 
            // frmNewType
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(522, 352);
            Controls.Add(txtZHPartType);
            Controls.Add(label6);
            Controls.Add(txtZHPartModel);
            Controls.Add(label5);
            Controls.Add(btnExit);
            Controls.Add(btnAdd);
            Controls.Add(txtZPLPrinter);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtMarkPath);
            Controls.Add(txtSN);
            Controls.Add(label2);
            Controls.Add(txtZHPartSO1CC);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmNewType";
            Text = "新增订单";
            Load += frmNewCarItem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZHPartSO1CC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSN;
        private System.Windows.Forms.TextBox txtMarkPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtZPLPrinter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtZHPartModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtZHPartType;
        private System.Windows.Forms.Label label6;
    }
}