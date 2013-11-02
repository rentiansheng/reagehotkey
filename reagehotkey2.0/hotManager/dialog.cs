using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hotManager
{
    public partial class frmdialog : Form
    {
        public frmdialog()
        {
            InitializeComponent();
           
        }

        int time = 60;
        private void frmdialog_Load(object sender, EventArgs e)
        {
            this.timfrm.Enabled = true;
            this.timfrm.Interval = 1000;
            this.btnyes.Text = "是（" + time.ToString() + ")";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Image.FromFile (Application .StartupPath +"\\bg.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnyes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void timfrm_Tick(object sender, EventArgs e)
        {
            time--;
            this.btnyes.Text = "是（" + time.ToString() + ")";
            if (0 == time)
            {
                DialogResult = DialogResult.OK;
                this.timfrm.Enabled = false;
                this.Close();
            }
        }
    }
}
