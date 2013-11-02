namespace hotManager
{
    partial class frmTop
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
            this.components = new System.ComponentModel.Container();
            this.toolTipApp = new System.Windows.Forms.ToolTip(this.components);
            this.txtKey = new System.Windows.Forms.TextBox();
            this.timFrm = new System.Windows.Forms.Timer(this.components);
            this.CMenuS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMenuIDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMenuIAddKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.CMenuSFrm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSmenuIOwer = new System.Windows.Forms.ToolStripMenuItem();
            this.RMunHidden = new System.Windows.Forms.ToolStripMenuItem();
            this.关机设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加密工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMenuIExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timGJ = new System.Windows.Forms.Timer(this.components);
            this.CMenuS.SuspendLayout();
            this.CMenuSFrm.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTipApp
            // 
            this.toolTipApp.AutoPopDelay = 5000;
            this.toolTipApp.InitialDelay = 50;
            this.toolTipApp.ReshowDelay = 10;
            // 
            // txtKey
            // 
            this.txtKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.txtKey.Location = new System.Drawing.Point(2, 82);
            this.txtKey.Name = "txtKey";
            this.txtKey.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(79, 21);
            this.txtKey.TabIndex = 1;
            this.toolTipApp.SetToolTip(this.txtKey, "按下键就可以设置快捷键");
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // timFrm
            // 
            this.timFrm.Interval = 10;
            this.timFrm.Tick += new System.EventHandler(this.timFrm_Tick);
            // 
            // CMenuS
            // 
            this.CMenuS.ImageScalingSize = new System.Drawing.Size(0, 0);
            this.CMenuS.ImeMode = System.Windows.Forms.ImeMode.On;
            this.CMenuS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMenuIDelete,
            this.TSMenuIAddKeys});
            this.CMenuS.Name = "CMenuS";
            this.CMenuS.ShowImageMargin = false;
            this.CMenuS.Size = new System.Drawing.Size(112, 48);
            // 
            // TSMenuIDelete
            // 
            this.TSMenuIDelete.Name = "TSMenuIDelete";
            this.TSMenuIDelete.Size = new System.Drawing.Size(111, 22);
            this.TSMenuIDelete.Text = "删除";
            this.TSMenuIDelete.Click += new System.EventHandler(this.TSMenuIDelete_Click);
            // 
            // TSMenuIAddKeys
            // 
            this.TSMenuIAddKeys.Name = "TSMenuIAddKeys";
            this.TSMenuIAddKeys.Size = new System.Drawing.Size(111, 22);
            this.TSMenuIAddKeys.Text = "修改快捷键";
            this.TSMenuIAddKeys.Click += new System.EventHandler(this.TSMenuIAddKeys_Click);
            // 
            // CMenuSFrm
            // 
            this.CMenuSFrm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSmenuIOwer,
            this.RMunHidden,
            this.关机设置ToolStripMenuItem,
            this.加密工具ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.TSMenuIExit});
            this.CMenuSFrm.Name = "CMenuSFrm";
            this.CMenuSFrm.ShowImageMargin = false;
            this.CMenuSFrm.ShowItemToolTips = false;
            this.CMenuSFrm.Size = new System.Drawing.Size(100, 136);
            // 
            // TSmenuIOwer
            // 
            this.TSmenuIOwer.Name = "TSmenuIOwer";
            this.TSmenuIOwer.Size = new System.Drawing.Size(99, 22);
            this.TSmenuIOwer.Text = "作者信息";
            this.TSmenuIOwer.Click += new System.EventHandler(this.TSmenuIOwer_Click);
            // 
            // RMunHidden
            // 
            this.RMunHidden.Name = "RMunHidden";
            this.RMunHidden.Size = new System.Drawing.Size(99, 22);
            this.RMunHidden.Text = "隐藏界面";
            this.RMunHidden.Click += new System.EventHandler(this.RMunHidden_Click);
            // 
            // 关机设置ToolStripMenuItem
            // 
            this.关机设置ToolStripMenuItem.Name = "关机设置ToolStripMenuItem";
            this.关机设置ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.关机设置ToolStripMenuItem.Text = "关机设置";
            this.关机设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 加密工具ToolStripMenuItem
            // 
            this.加密工具ToolStripMenuItem.Name = "加密工具ToolStripMenuItem";
            this.加密工具ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.加密工具ToolStripMenuItem.Text = "加密工具";
            this.加密工具ToolStripMenuItem.Click += new System.EventHandler(this.加密工具ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // TSMenuIExit
            // 
            this.TSMenuIExit.Name = "TSMenuIExit";
            this.TSMenuIExit.Size = new System.Drawing.Size(99, 22);
            this.TSMenuIExit.Text = "退出";
            this.TSMenuIExit.Click += new System.EventHandler(this.TSMenuIExit_Click);
            // 
            // timGJ
            // 
            this.timGJ.Interval = 59000;
            this.timGJ.Tick += new System.EventHandler(this.timGJ_Tick);
            // 
            // frmTop
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.Lavender;
            this.BackgroundImage = global::hotManager.Properties.Resources.middle;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(975, 104);
            this.ContextMenuStrip = this.CMenuSFrm;
            this.ControlBox = false;
            this.Controls.Add(this.txtKey);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTop";
            this.Opacity = 0.7D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmTop";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.frmTop_Load);
            this.CMenuS.ResumeLayout(false);
            this.CMenuSFrm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTipApp;
        private System.Windows.Forms.Timer timFrm;
        private System.Windows.Forms.ContextMenuStrip CMenuS;
        private System.Windows.Forms.ToolStripMenuItem TSMenuIDelete;
        private System.Windows.Forms.ToolStripMenuItem TSMenuIAddKeys;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.ContextMenuStrip CMenuSFrm;
        private System.Windows.Forms.ToolStripMenuItem TSMenuIExit;
        private System.Windows.Forms.ToolStripMenuItem TSmenuIOwer;
        private System.Windows.Forms.ToolStripMenuItem RMunHidden;
        private System.Windows.Forms.ToolStripMenuItem 关机设置ToolStripMenuItem;
        private System.Windows.Forms.Timer timGJ;
        private System.Windows.Forms.ToolStripMenuItem 加密工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
    }
}