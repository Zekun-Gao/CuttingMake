namespace CuttingMake
{
    partial class frmMain
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
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            登陆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            用户登陆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            登陆管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ProductPrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            历史记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            标签数据管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            导入Excel打印数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { 登陆ToolStripMenuItem, ProductPrintToolStripMenuItem, 标签数据管理ToolStripMenuItem, 历史记录ToolStripMenuItem, 导入Excel打印数据ToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            menuStrip1.Size = new System.Drawing.Size(897, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 登陆ToolStripMenuItem
            // 
            登陆ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { 用户登陆ToolStripMenuItem, 登陆管理ToolStripMenuItem });
            登陆ToolStripMenuItem.Name = "登陆ToolStripMenuItem";
            登陆ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            登陆ToolStripMenuItem.Text = "登陆";
            // 
            // 用户登陆ToolStripMenuItem
            // 
            用户登陆ToolStripMenuItem.Name = "用户登陆ToolStripMenuItem";
            用户登陆ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            用户登陆ToolStripMenuItem.Text = "用户登陆";
            用户登陆ToolStripMenuItem.Click += 用户登陆ToolStripMenuItem_Click;
            // 
            // 登陆管理ToolStripMenuItem
            // 
            登陆管理ToolStripMenuItem.Name = "登陆管理ToolStripMenuItem";
            登陆管理ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            登陆管理ToolStripMenuItem.Text = "登陆管理";
            登陆管理ToolStripMenuItem.Click += 登陆管理ToolStripMenuItem_Click;
            // 
            // ProductPrintToolStripMenuItem
            // 
            ProductPrintToolStripMenuItem.Name = "ProductPrintToolStripMenuItem";
            ProductPrintToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            ProductPrintToolStripMenuItem.Text = "产品单据打印";
            ProductPrintToolStripMenuItem.Click += ProductPrintToolStripMenuItem_Click;
            // 
            // 历史记录ToolStripMenuItem
            // 
            历史记录ToolStripMenuItem.Name = "历史记录ToolStripMenuItem";
            历史记录ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            历史记录ToolStripMenuItem.Text = "历史记录";
            历史记录ToolStripMenuItem.Click += 历史记录ToolStripMenuItem_Click;
            // 
            // 标签数据管理ToolStripMenuItem
            // 
            标签数据管理ToolStripMenuItem.Name = "标签数据管理ToolStripMenuItem";
            标签数据管理ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            标签数据管理ToolStripMenuItem.Text = "标签数据管理";
            标签数据管理ToolStripMenuItem.Click += 添加打印数据ToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new System.Drawing.Point(0, 654);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip1.Size = new System.Drawing.Size(897, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Info;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(85, 17);
            toolStripStatusLabel1.Text = "软件版本 V1.0";
            // 
            // 导入Excel打印数据ToolStripMenuItem
            // 
            导入Excel打印数据ToolStripMenuItem.Name = "导入Excel打印数据ToolStripMenuItem";
            导入Excel打印数据ToolStripMenuItem.Size = new System.Drawing.Size(121, 21);
            导入Excel打印数据ToolStripMenuItem.Text = "导入Excel打印数据";
            导入Excel打印数据ToolStripMenuItem.Click += 导入Excel打印数据ToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.ControlDark;
            ClientSize = new System.Drawing.Size(897, 676);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "frmMain";
            Text = "标签打印";
            FormClosing += frmMain_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 登陆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户登陆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登陆管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProductPrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标签数据管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入Excel打印数据ToolStripMenuItem;
    }
}