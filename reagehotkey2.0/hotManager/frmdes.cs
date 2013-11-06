using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace hotManager
{
    public partial class frmDes : Form
    {
        public frmDes()
        {
            InitializeComponent();
            //this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\bg.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnFileExplorer_Click(object sender, EventArgs e)
        {
            if (this.rbtnEncrypt.Checked)
                Explorer("所有文件(*.*)|*.*");
            else
                Explorer("密码文件(*.rg)|*.rg|所有文件(*.*)|*.*");
        }



        #region myfunction

        private void Explorer(string filter)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = filter;// "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"; ;
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                this.txtFile.Text = openfile.FileName;
            }
        }

        private void Wait()
        {
            frmwait frmWait = new frmwait(this);
            frmWait.ShowDialog();
        }
        #endregion

        private void rbtnDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            this.panDecrypt.Enabled = !this.panDecrypt.Enabled;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.txtFile.Text.Equals(""))
            {
                if (this.rbtnDecrypt.Checked)
                    this.statusLblContext.Text = "请选择要解密的文件";
                else
                    this.statusLblContext.Text = "请选择要加密的文件";
                return;
            }
            if (!(System.IO.File.Exists(this.txtFile.Text.Trim()) || System.IO.Directory.Exists(this.txtFile.Text.Trim())))
            {
                this.statusLblContext.Text = "你选择的文件或者目录不存在";
                return;
            }
            if (this.txtPwd.Text.Equals(""))
            {

                if (this.rbtnDecrypt.Checked)
                    this.statusLblContext.Text = "请输入要解密的密码";
                else
                    this.statusLblContext.Text = "请输入要加密的密码";
                return;
            }
            SaveFileDialog savefile = new SaveFileDialog ();
            if (this.rbtnDecrypt.Checked)
            {
                string file = CryptoHelp.DecryptFileName(this.txtFile .Text .Trim ());
                if ("" == file) file = "*";
                savefile.Filter =string.Format ( "所有文件（*.{0}）|*.{0}", System.IO.Path .GetExtension (file));
            }
            else
            {
                savefile.Filter = "密码文件(*.rg)|*.rg";
            }

            string path = "";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                path = savefile.FileName;
                Thread th = new Thread(new ThreadStart(Wait));
                th.Start();
                try
                {
                    if (this.rbtnDecrypt.Checked)
                    {
                        hotManager.CryptoHelp.DecryptFile(this.txtFile.Text, path, this.txtPwd.Text);
                    }
                    else
                    {
                        hotManager.CryptoHelp.EncryptFile(this.txtFile.Text, path, this.txtPwd.Text);
                    }
                    this.statusLblContext.Text = "操作完成";
                }
                catch
                {
                    this.statusLblContext.Text = "操作失败";
                }
                th.Abort();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           // Application.Exit();
            this.Close();
        }

        bool ismove = false;
        Point frmpoint = new Point();
        private void frmDes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ismove = true;
                frmpoint.X -= e.X;
                frmpoint.Y -= e.Y;
            }
        }

        private void frmDes_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismove)
            {
                Point mouseoffset = Control.MousePosition;
                mouseoffset.Offset(frmpoint .X , frmpoint .Y );
                this.Location = mouseoffset;
            }
        }

        private void frmDes_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ismove = false ;
            }
        }

        
      
    }
}
