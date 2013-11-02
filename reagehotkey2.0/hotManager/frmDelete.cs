//======================================================================
//
//        Copyright (C) 2007-2008 三月软件工作室    
//        All rights reserved
//
//        filename :Class
//        description :
//
//        created by任天胜 at  06/07/2011 18:41:28
//        qq:625246906
//        network:www.rtswin.com
//======================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hotManager
{
    public partial class frmDelete : Form
    {
        private Size pPicBoxSize = new Size(40+15, 40+15);
        private Point frmLocation;
        string path;
        bool bl = true;
        PictureBox pb =null;
        public frmDelete(string Apppath)
        {
            InitializeComponent();
              path = Apppath;
              this.TopMost = true;
        }

        private void frmDelete_Load(object sender, EventArgs e)
        {
            this.Size = pPicBoxSize;
            this.BackColor = Color.FromArgb(230, 244, 248);
            pb = new PictureBox();
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Image = System.Drawing.Icon.ExtractAssociatedIcon(path).ToBitmap();
            pb.Name = "11";
            Point pt = pb.Location;
            pb.Size = pPicBoxSize;
            pb.Location = new Point(0, 0);
            this.Controls.Add(pb);
            frmLocation = this.Location;
            this.LocationChanged += new EventHandler(frmDelete_LocationChanged);
        }
        int i = 0;
        void frmDelete_LocationChanged(object sender, EventArgs e)
        {
            if (i++ == 0)
                return;
            
            if (Math .Abs ( this.Location.X - frmLocation.X) > 20)
            {
                bl = false;
            }
            if (Math.Abs(this.Location.Y - frmLocation.Y) > 20)
            {
                bl = false;
            }
           
        }

        private void timFrmChange_Tick(object sender, EventArgs e)
        {
            this.LocationChanged -= new EventHandler(frmDelete_LocationChanged);
            //this.Location = new Point(this.Location.X + 4, this.Location.Y + 4);
            pb.Location = new Point(pb.Location .X -2,pb.Location .Y -2);
            this.Opacity = this.Opacity - 0.05;
            if (this.Width  > 0)
            {
                this.Width -= 5;
            }
            if (this.Height> 0)
            {
                this.Height -= 5;
            }
            if (this.Width <=5 || this.Height <= 5)
            {
                this.timFrmChange.Enabled  = false;
                this.Close();
                this.Dispose();
            }
        }

        private void frmDelete_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bl)
            {
                if (System.IO.File.Exists(path))
                    System.Diagnostics.Process.Start("explorer.exe",path);
            }
        }
    }
}
