namespace IM
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.导入词库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.模糊词库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生词词库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.熟悉词库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.串口配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mindviewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minddataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入的词库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.导入词库ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2,
            this.toolStripMenuItem4,
            this.关于ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(795, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(68, 22);
            this.toolStripMenuItem5.Text = "单词识别";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // 导入词库ToolStripMenuItem
            // 
            this.导入词库ToolStripMenuItem.Name = "导入词库ToolStripMenuItem";
            this.导入词库ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.导入词库ToolStripMenuItem.Text = "导入词库";
            this.导入词库ToolStripMenuItem.Click += new System.EventHandler(this.导入词库ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.模糊词库ToolStripMenuItem,
            this.生词词库ToolStripMenuItem,
            this.熟悉词库ToolStripMenuItem,
            this.导入的词库ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 22);
            this.toolStripMenuItem1.Text = "历史词库";
            // 
            // 模糊词库ToolStripMenuItem
            // 
            this.模糊词库ToolStripMenuItem.Name = "模糊词库ToolStripMenuItem";
            this.模糊词库ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.模糊词库ToolStripMenuItem.Text = "模糊词库";
            this.模糊词库ToolStripMenuItem.Click += new System.EventHandler(this.模糊词库ToolStripMenuItem_Click);
            // 
            // 生词词库ToolStripMenuItem
            // 
            this.生词词库ToolStripMenuItem.Name = "生词词库ToolStripMenuItem";
            this.生词词库ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.生词词库ToolStripMenuItem.Text = "生词词库";
            this.生词词库ToolStripMenuItem.Click += new System.EventHandler(this.生词词库ToolStripMenuItem_Click);
            // 
            // 熟悉词库ToolStripMenuItem
            // 
            this.熟悉词库ToolStripMenuItem.Name = "熟悉词库ToolStripMenuItem";
            this.熟悉词库ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.熟悉词库ToolStripMenuItem.Text = "熟悉词库";
            this.熟悉词库ToolStripMenuItem.Click += new System.EventHandler(this.熟悉词库ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.串口配置ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(68, 22);
            this.toolStripMenuItem3.Text = "设备管理";
            // 
            // 串口配置ToolStripMenuItem
            // 
            this.串口配置ToolStripMenuItem.Name = "串口配置ToolStripMenuItem";
            this.串口配置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.串口配置ToolStripMenuItem.Text = "串口配置";
            this.串口配置ToolStripMenuItem.Click += new System.EventHandler(this.串口配置ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mindviewerToolStripMenuItem,
            this.minddataToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(68, 22);
            this.toolStripMenuItem2.Text = "数据管理";
            // 
            // mindviewerToolStripMenuItem
            // 
            this.mindviewerToolStripMenuItem.Name = "mindviewerToolStripMenuItem";
            this.mindviewerToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.mindviewerToolStripMenuItem.Text = "Mindviewer";
            this.mindviewerToolStripMenuItem.Click += new System.EventHandler(this.mindviewerToolStripMenuItem_Click);
            // 
            // minddataToolStripMenuItem
            // 
            this.minddataToolStripMenuItem.Name = "minddataToolStripMenuItem";
            this.minddataToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.minddataToolStripMenuItem.Text = "Minddata";
            this.minddataToolStripMenuItem.Click += new System.EventHandler(this.minddataToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(68, 22);
            this.toolStripMenuItem4.Text = "记忆曲线";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 579);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(795, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLabel1.Text = " ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(724, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = " ";
            // 
            // tLabel1
            // 
            this.tLabel1.Name = "tLabel1";
            this.tLabel1.Size = new System.Drawing.Size(44, 17);
            this.tLabel1.Text = "未连接";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Visible = false;
            // 
            // 导入的词库ToolStripMenuItem
            // 
            this.导入的词库ToolStripMenuItem.Name = "导入的词库ToolStripMenuItem";
            this.导入的词库ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导入的词库ToolStripMenuItem.Text = "导入的词库";
            this.导入的词库ToolStripMenuItem.Click += new System.EventHandler(this.导入的词库ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 601);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.Text = "单词识别系统";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导入词库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mindviewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 串口配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minddataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem 模糊词库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生词词库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 熟悉词库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tLabel1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入的词库ToolStripMenuItem;
    }
}

