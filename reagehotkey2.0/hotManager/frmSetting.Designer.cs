namespace hotManager
{
    partial class frmSetting
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txttime = new System.Windows.Forms.TextBox();
            this.lstvtime = new System.Windows.Forms.ListView();
            this.colGuid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTxt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colguid1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnadd = new System.Windows.Forms.Button();
            this.chkall = new System.Windows.Forms.CheckBox();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.chkTuesday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTmpTime = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btntmpset = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statuslblmsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.timInit = new System.Windows.Forms.Timer(this.components);
            this.pboxclose = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxclose)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.txttime);
            this.groupBox1.Controls.Add(this.lstvtime);
            this.groupBox1.Controls.Add(this.btnadd);
            this.groupBox1.Controls.Add(this.chkall);
            this.groupBox1.Controls.Add(this.chkSunday);
            this.groupBox1.Controls.Add(this.chkSaturday);
            this.groupBox1.Controls.Add(this.chkFriday);
            this.groupBox1.Controls.Add(this.chkThursday);
            this.groupBox1.Controls.Add(this.chkWednesday);
            this.groupBox1.Controls.Add(this.chkTuesday);
            this.groupBox1.Controls.Add(this.chkMonday);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(31, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "关机设置";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(82, 146);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "保存";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txttime
            // 
            this.txttime.Location = new System.Drawing.Point(77, 38);
            this.txttime.MaxLength = 6;
            this.txttime.Name = "txttime";
            this.txttime.Size = new System.Drawing.Size(100, 21);
            this.txttime.TabIndex = 5;
            this.txttime.Text = "00:00";
            this.txttime.TextChanged += new System.EventHandler(this.txttime_TextChanged);
            this.txttime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttime_KeyPress);
            // 
            // lstvtime
            // 
            this.lstvtime.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstvtime.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGuid,
            this.colName,
            this.colTime,
            this.colTxt,
            this.colguid1});
            this.lstvtime.FullRowSelect = true;
            this.lstvtime.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstvtime.HoverSelection = true;
            this.lstvtime.Location = new System.Drawing.Point(113, 189);
            this.lstvtime.Name = "lstvtime";
            this.lstvtime.Size = new System.Drawing.Size(300, 36);
            this.lstvtime.TabIndex = 5;
            this.lstvtime.UseCompatibleStateImageBehavior = false;
            this.lstvtime.View = System.Windows.Forms.View.Details;
            this.lstvtime.Visible = false;
            this.lstvtime.SelectedIndexChanged += new System.EventHandler(this.lstvtime_SelectedIndexChanged);
            // 
            // colGuid
            // 
            this.colGuid.Text = "";
            this.colGuid.Width = 20;
            // 
            // colName
            // 
            this.colName.Text = "计划名称";
            this.colName.Width = 100;
            // 
            // colTime
            // 
            this.colTime.Text = "时间";
            this.colTime.Width = 70;
            // 
            // colTxt
            // 
            this.colTxt.Text = "时间";
            this.colTxt.Width = 300;
            // 
            // colguid1
            // 
            this.colguid1.Width = 0;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(18, 202);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 4;
            this.btnadd.Text = "新建";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Visible = false;
            // 
            // chkall
            // 
            this.chkall.AutoSize = true;
            this.chkall.Location = new System.Drawing.Point(346, 108);
            this.chkall.Name = "chkall";
            this.chkall.Size = new System.Drawing.Size(48, 16);
            this.chkall.TabIndex = 3;
            this.chkall.Text = "全选";
            this.chkall.UseVisualStyleBackColor = true;
            this.chkall.CheckedChanged += new System.EventHandler(this.chkall_CheckedChanged);
            // 
            // chkSunday
            // 
            this.chkSunday.AutoSize = true;
            this.chkSunday.Location = new System.Drawing.Point(263, 108);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(60, 16);
            this.chkSunday.TabIndex = 2;
            this.chkSunday.Text = "星期天";
            this.chkSunday.UseVisualStyleBackColor = true;
            this.chkSunday.CheckedChanged += new System.EventHandler(this.chkSunday_CheckedChanged);
            // 
            // chkSaturday
            // 
            this.chkSaturday.AutoSize = true;
            this.chkSaturday.Location = new System.Drawing.Point(170, 108);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(60, 16);
            this.chkSaturday.TabIndex = 2;
            this.chkSaturday.Text = "星期六";
            this.chkSaturday.UseVisualStyleBackColor = true;
            this.chkSaturday.CheckedChanged += new System.EventHandler(this.chkSaturday_CheckedChanged);
            // 
            // chkFriday
            // 
            this.chkFriday.AutoSize = true;
            this.chkFriday.Location = new System.Drawing.Point(82, 108);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(60, 16);
            this.chkFriday.TabIndex = 2;
            this.chkFriday.Text = "星期五";
            this.chkFriday.UseVisualStyleBackColor = true;
            this.chkFriday.CheckedChanged += new System.EventHandler(this.chkFriday_CheckedChanged);
            // 
            // chkThursday
            // 
            this.chkThursday.AutoSize = true;
            this.chkThursday.Location = new System.Drawing.Point(346, 76);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(60, 16);
            this.chkThursday.TabIndex = 2;
            this.chkThursday.Text = "星期四";
            this.chkThursday.UseVisualStyleBackColor = true;
            this.chkThursday.CheckedChanged += new System.EventHandler(this.chkThursday_CheckedChanged);
            // 
            // chkWednesday
            // 
            this.chkWednesday.AutoSize = true;
            this.chkWednesday.Location = new System.Drawing.Point(262, 76);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(60, 16);
            this.chkWednesday.TabIndex = 2;
            this.chkWednesday.Text = "星期三";
            this.chkWednesday.UseVisualStyleBackColor = true;
            this.chkWednesday.CheckedChanged += new System.EventHandler(this.chkWednesday_CheckedChanged);
            // 
            // chkTuesday
            // 
            this.chkTuesday.AutoSize = true;
            this.chkTuesday.Location = new System.Drawing.Point(170, 76);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(60, 16);
            this.chkTuesday.TabIndex = 2;
            this.chkTuesday.Text = "星期二";
            this.chkTuesday.UseVisualStyleBackColor = true;
            this.chkTuesday.CheckedChanged += new System.EventHandler(this.chkTuesday_CheckedChanged);
            // 
            // chkMonday
            // 
            this.chkMonday.AutoSize = true;
            this.chkMonday.Location = new System.Drawing.Point(82, 76);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(60, 16);
            this.chkMonday.TabIndex = 2;
            this.chkMonday.Text = "星期一";
            this.chkMonday.UseVisualStyleBackColor = true;
            this.chkMonday.CheckedChanged += new System.EventHandler(this.chkMonday_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(285, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(131, 21);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "默认计划";
            this.txtName.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "关机时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "时间选择：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "计划名称：";
            this.label1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtTmpTime);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btntmpset);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(31, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(501, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "临时关机计划";
            // 
            // txtTmpTime
            // 
            this.txtTmpTime.Location = new System.Drawing.Point(133, 42);
            this.txtTmpTime.MaxLength = 6;
            this.txtTmpTime.Name = "txtTmpTime";
            this.txtTmpTime.Size = new System.Drawing.Size(108, 21);
            this.txtTmpTime.TabIndex = 5;
            this.txtTmpTime.Text = "00:00";
            this.txtTmpTime.TextChanged += new System.EventHandler(this.txttime_TextChanged);
            this.txtTmpTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttime_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(366, 40);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btntmpset
            // 
            this.btntmpset.Location = new System.Drawing.Point(263, 40);
            this.btntmpset.Name = "btntmpset";
            this.btntmpset.Size = new System.Drawing.Size(75, 23);
            this.btntmpset.TabIndex = 7;
            this.btntmpset.Text = "设置";
            this.btntmpset.UseVisualStyleBackColor = true;
            this.btntmpset.Click += new System.EventHandler(this.btntmpset_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "关机时间：";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuslblmsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 357);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(570, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statuslblmsg
            // 
            this.statuslblmsg.Name = "statuslblmsg";
            this.statuslblmsg.Size = new System.Drawing.Size(32, 17);
            this.statuslblmsg.Text = "就绪";
            // 
            // timInit
            // 
            this.timInit.Tick += new System.EventHandler(this.timInit_Tick);
            // 
            // pboxclose
            // 
            this.pboxclose.BackColor = System.Drawing.Color.Transparent;
            this.pboxclose.Image = global::hotManager.Properties.Resources.close;
            this.pboxclose.Location = new System.Drawing.Point(539, 1);
            this.pboxclose.Name = "pboxclose";
            this.pboxclose.Size = new System.Drawing.Size(28, 24);
            this.pboxclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxclose.TabIndex = 3;
            this.pboxclose.TabStop = false;
            this.pboxclose.Click += new System.EventHandler(this.pboxclose_Click);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::hotManager.Properties.Resources.middle;
            this.ClientSize = new System.Drawing.Size(570, 379);
            this.Controls.Add(this.pboxclose);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetting";
            this.Text = "任忌热键设置-关机设置";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmSetting_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmSetting_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmSetting_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxclose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.CheckBox chkall;
        private System.Windows.Forms.CheckBox chkSunday;
        private System.Windows.Forms.CheckBox chkSaturday;
        private System.Windows.Forms.CheckBox chkFriday;
        private System.Windows.Forms.CheckBox chkThursday;
        private System.Windows.Forms.CheckBox chkWednesday;
        private System.Windows.Forms.CheckBox chkTuesday;
        private System.Windows.Forms.CheckBox chkMonday;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttime;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListView lstvtime;
        private System.Windows.Forms.ColumnHeader colGuid;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colTxt;
        private System.Windows.Forms.ColumnHeader colguid1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTmpTime;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btntmpset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statuslblmsg;
        private System.Windows.Forms.Timer timInit;
        private System.Windows.Forms.PictureBox pboxclose;
    }
}