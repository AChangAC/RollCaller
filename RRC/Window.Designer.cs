namespace RRC
{
    partial class Window
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.NameLab = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NFICO = new System.Windows.Forms.NotifyIcon(this.components);
            this.youxiaICON = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JIES = new System.Windows.Forms.Label();
            this.Cicrl = new System.Windows.Forms.PictureBox();
            this.EditNMB = new System.Windows.Forms.Label();
            this.EditBox = new System.Windows.Forms.TextBox();
            this.youxiaICON.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cicrl)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLab
            // 
            this.NameLab.Font = new System.Drawing.Font("站酷快乐体2016修订版", 35F);
            this.NameLab.Location = new System.Drawing.Point(12, 172);
            this.NameLab.Name = "NameLab";
            this.NameLab.Size = new System.Drawing.Size(776, 106);
            this.NameLab.TabIndex = 0;
            this.NameLab.Text = "点击此处开始";
            this.NameLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NameLab.Click += new System.EventHandler(this.NameLab_Click);
            this.NameLab.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.NameLab.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.NameLab.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Fluent Icons", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(740, -15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 70);
            this.label1.TabIndex = 1;
            this.label1.Text = "";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            // 
            // NFICO
            // 
            this.NFICO.ContextMenuStrip = this.youxiaICON;
            this.NFICO.Icon = ((System.Drawing.Icon)(resources.GetObject("NFICO.Icon")));
            this.NFICO.Text = "随机点名器";
            this.NFICO.Visible = true;
            // 
            // youxiaICON
            // 
            this.youxiaICON.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.youxiaICON.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.youxiaICON.Name = "youxiaICON";
            this.youxiaICON.Size = new System.Drawing.Size(109, 28);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // JIES
            // 
            this.JIES.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.JIES.Location = new System.Drawing.Point(7, 326);
            this.JIES.Name = "JIES";
            this.JIES.Size = new System.Drawing.Size(786, 45);
            this.JIES.TabIndex = 2;
            this.JIES.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.JIES.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.JIES.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.JIES.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            // 
            // Cicrl
            // 
            this.Cicrl.Location = new System.Drawing.Point(280, 116);
            this.Cicrl.Name = "Cicrl";
            this.Cicrl.Size = new System.Drawing.Size(252, 224);
            this.Cicrl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Cicrl.TabIndex = 3;
            this.Cicrl.TabStop = false;
            this.Cicrl.Visible = false;
            this.Cicrl.Click += new System.EventHandler(this.Cicrl_Click);
            // 
            // EditNMB
            // 
            this.EditNMB.AutoSize = true;
            this.EditNMB.Font = new System.Drawing.Font("站酷快乐体2016修订版", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EditNMB.ForeColor = System.Drawing.Color.Tomato;
            this.EditNMB.Location = new System.Drawing.Point(374, 421);
            this.EditNMB.Name = "EditNMB";
            this.EditNMB.Size = new System.Drawing.Size(90, 22);
            this.EditNMB.TabIndex = 4;
            this.EditNMB.Text = "编辑名单";
            this.EditNMB.Click += new System.EventHandler(this.EditNMB_Click);
            // 
            // EditBox
            // 
            this.EditBox.Font = new System.Drawing.Font("小米兰亭", 11F);
            this.EditBox.Location = new System.Drawing.Point(12, 453);
            this.EditBox.Multiline = true;
            this.EditBox.Name = "EditBox";
            this.EditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EditBox.Size = new System.Drawing.Size(776, 300);
            this.EditBox.TabIndex = 5;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EditBox);
            this.Controls.Add(this.EditNMB);
            this.Controls.Add(this.Cicrl);
            this.Controls.Add(this.JIES);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameLab);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Window";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "随机点名";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Window_Load);
            this.Click += new System.EventHandler(this.NameLab_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Window_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Window_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Window_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Window_MouseUp);
            this.youxiaICON.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cicrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon NFICO;
        private System.Windows.Forms.ContextMenuStrip youxiaICON;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Label JIES;
        private System.Windows.Forms.PictureBox Cicrl;
        private System.Windows.Forms.Label EditNMB;
        private System.Windows.Forms.TextBox EditBox;
    }
}

