using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hotManager
{
    public partial class frmwait : Form
    {
        string msg;
        Form parentForm;
        public frmwait( Form frmparent)
        {
            InitializeComponent();
            this.parentForm = frmparent;
        }

        private void frmwait_Load(object sender, EventArgs e)
        {
            msg = "正在处理数据，请等待。。。。";
            this.Size = parentForm.Size;
            this.Location = parentForm.Location;
            parentForm.Enabled = true;
            this.StartPosition = FormStartPosition.Manual;
            this.Opacity = 0.7;
            this.lblMsg.Text = msg;
            this.lblMsg.Location = new Point(this.Width /2-this.lblMsg .Width /2,this.Height /2-this.lblMsg .Height /2);
        }
    }
}
