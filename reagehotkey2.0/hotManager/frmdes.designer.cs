namespace hotManager
{
    partial class frmDes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblType = new System.Windows.Forms.Label();
            this.rbtnDecrypt = new System.Windows.Forms.RadioButton();
            this.rbtnEncrypt = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFileExplorer = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbtntwo = new System.Windows.Forms.RadioButton();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.rbtnOne = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.rbtnTemp = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtnOutfile = new System.Windows.Forms.RadioButton();
            this.panDecrypt = new System.Windows.Forms.Panel();
            this.statustool = new System.Windows.Forms.StatusStrip();
            this.statusLblContext = new System.Windows.Forms.ToolStripStatusLabel();
            this.statuslblCopy = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panDecrypt.SuspendLayout();
            this.statustool.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.rbtnDecrypt);
            this.panel1.Controls.Add(this.rbtnEncrypt);
            this.panel1.Location = new System.Drawing.Point(32, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 30);
            this.panel1.TabIndex = 0;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(22, 10);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 12);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "类型:";
            // 
            // rbtnDecrypt
            // 
            this.rbtnDecrypt.AutoSize = true;
            this.rbtnDecrypt.Location = new System.Drawing.Point(181, 6);
            this.rbtnDecrypt.Name = "rbtnDecrypt";
            this.rbtnDecrypt.Size = new System.Drawing.Size(47, 16);
            this.rbtnDecrypt.TabIndex = 0;
            this.rbtnDecrypt.Text = "解密";
            this.rbtnDecrypt.UseVisualStyleBackColor = true;
            this.rbtnDecrypt.CheckedChanged += new System.EventHandler(this.rbtnDecrypt_CheckedChanged);
            // 
            // rbtnEncrypt
            // 
            this.rbtnEncrypt.AutoSize = true;
            this.rbtnEncrypt.Checked = true;
            this.rbtnEncrypt.Location = new System.Drawing.Point(82, 6);
            this.rbtnEncrypt.Name = "rbtnEncrypt";
            this.rbtnEncrypt.Size = new System.Drawing.Size(47, 16);
            this.rbtnEncrypt.TabIndex = 0;
            this.rbtnEncrypt.TabStop = true;
            this.rbtnEncrypt.Text = "加密";
            this.rbtnEncrypt.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtFile);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnFileExplorer);
            this.panel2.Location = new System.Drawing.Point(32, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 39);
            this.panel2.TabIndex = 1;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(86, 8);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(166, 21);
            this.txtFile.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "文件位置：";
            // 
            // btnFileExplorer
            // 
            this.btnFileExplorer.Location = new System.Drawing.Point(269, 8);
            this.btnFileExplorer.Name = "btnFileExplorer";
            this.btnFileExplorer.Size = new System.Drawing.Size(63, 23);
            this.btnFileExplorer.TabIndex = 0;
            this.btnFileExplorer.Text = "浏览";
            this.btnFileExplorer.UseVisualStyleBackColor = true;
            this.btnFileExplorer.Click += new System.EventHandler(this.btnFileExplorer_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbtntwo);
            this.panel3.Controls.Add(this.txtPwd);
            this.panel3.Controls.Add(this.rbtnOne);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(32, 112);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 39);
            this.panel3.TabIndex = 1;
            // 
            // rbtntwo
            // 
            this.rbtntwo.AutoSize = true;
            this.rbtntwo.Location = new System.Drawing.Point(181, 38);
            this.rbtntwo.Name = "rbtntwo";
            this.rbtntwo.Size = new System.Drawing.Size(41, 16);
            this.rbtntwo.TabIndex = 0;
            this.rbtntwo.Text = "2次";
            this.rbtntwo.UseVisualStyleBackColor = true;
            this.rbtntwo.Visible = false;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(82, 8);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(166, 21);
            this.txtPwd.TabIndex = 3;
            // 
            // rbtnOne
            // 
            this.rbtnOne.AutoSize = true;
            this.rbtnOne.Checked = true;
            this.rbtnOne.Location = new System.Drawing.Point(82, 38);
            this.rbtnOne.Name = "rbtnOne";
            this.rbtnOne.Size = new System.Drawing.Size(41, 16);
            this.rbtnOne.TabIndex = 0;
            this.rbtnOne.TabStop = true;
            this.rbtnOne.Text = "1次";
            this.rbtnOne.UseVisualStyleBackColor = true;
            this.rbtnOne.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "次数：";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(56, 173);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(78, 28);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // rbtnTemp
            // 
            this.rbtnTemp.AutoSize = true;
            this.rbtnTemp.Checked = true;
            this.rbtnTemp.Location = new System.Drawing.Point(82, 14);
            this.rbtnTemp.Name = "rbtnTemp";
            this.rbtnTemp.Size = new System.Drawing.Size(71, 16);
            this.rbtnTemp.TabIndex = 0;
            this.rbtnTemp.TabStop = true;
            this.rbtnTemp.Text = "查看文件";
            this.rbtnTemp.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "解密类型：";
            // 
            // rbtnOutfile
            // 
            this.rbtnOutfile.AutoSize = true;
            this.rbtnOutfile.Location = new System.Drawing.Point(181, 14);
            this.rbtnOutfile.Name = "rbtnOutfile";
            this.rbtnOutfile.Size = new System.Drawing.Size(71, 16);
            this.rbtnOutfile.TabIndex = 0;
            this.rbtnOutfile.Text = "导出文件";
            this.rbtnOutfile.UseVisualStyleBackColor = true;
            // 
            // panDecrypt
            // 
            this.panDecrypt.Controls.Add(this.rbtnOutfile);
            this.panDecrypt.Controls.Add(this.label4);
            this.panDecrypt.Controls.Add(this.rbtnTemp);
            this.panDecrypt.Enabled = false;
            this.panDecrypt.Location = new System.Drawing.Point(394, 179);
            this.panDecrypt.Name = "panDecrypt";
            this.panDecrypt.Size = new System.Drawing.Size(360, 46);
            this.panDecrypt.TabIndex = 3;
            this.panDecrypt.Visible = false;
            // 
            // statustool
            // 
            this.statustool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLblContext,
            this.statuslblCopy});
            this.statustool.Location = new System.Drawing.Point(0, 207);
            this.statustool.Name = "statustool";
            this.statustool.Size = new System.Drawing.Size(404, 22);
            this.statustool.TabIndex = 4;
            this.statustool.Text = "statusStrip1";
            // 
            // statusLblContext
            // 
            this.statusLblContext.Name = "statusLblContext";
            this.statusLblContext.Size = new System.Drawing.Size(0, 17);
            // 
            // statuslblCopy
            // 
            this.statuslblCopy.Name = "statuslblCopy";
            this.statuslblCopy.Size = new System.Drawing.Size(158, 17);
            this.statuslblCopy.Text = "            Reage安全工具1.0";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(185, 169);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 28);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "关闭";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmDes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 229);
            this.Controls.Add(this.statustool);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panDecrypt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDes";
            this.Text = "Reage安全工具";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panDecrypt.ResumeLayout(false);
            this.panDecrypt.PerformLayout();
            this.statustool.ResumeLayout(false);
            this.statustool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.RadioButton rbtnDecrypt;
        private System.Windows.Forms.RadioButton rbtnEncrypt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFileExplorer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbtntwo;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.RadioButton rbtnOne;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton rbtnTemp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnOutfile;
        private System.Windows.Forms.Panel panDecrypt;
        private System.Windows.Forms.StatusStrip statustool;
        private System.Windows.Forms.ToolStripStatusLabel statusLblContext;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolStripStatusLabel statuslblCopy;

    }
}

