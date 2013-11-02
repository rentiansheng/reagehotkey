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
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;
using IWshRuntimeLibrary;
using Microsoft.Win32;
using System.Diagnostics;

namespace hotManager
{
    public partial class frmTop : Form
    {
        public frmTop()
        {
            InitializeComponent();
            try
            {
                RunSys();
                
                Control.CheckForIllegalCrossThreadCalls = false;
            }
            catch
            {
                ShowMessage("权限不够，无法自动启动！");
            }
           
        }

        #region Var
        /// true 表示变大。false表示变小
        /// <summary>
        /// true 表示变大。false表示变小
        /// </summary>
        private bool blChange = false;
        private Size pFrmSize = new Size(700, 75);
        private Size pPicBoxSize = new Size(40, 40);
        private Point pFrmLoction = new Point(300,0);
        private Point PPicBoxLoction ;
        private Point PpicboxInitLocation = new Point(15, 10);
        //每一个图片之间的间隔
        private int increment = 5;
        private int pbCount = 0;
        //图片移动的增量
        private int incrementMov = 10;
        /// <summary>
        /// 表示是否拖拽图片
        /// </summary>
        private bool blPbDrag = false;
        /// <summary>
        /// 表示txtKey控件的TextKey事件是否执行过了true执行过
        /// </summary>
        private bool txtchangebl = true;
        WriteData wd = new WriteData();

        private int  allowAppCount=15;
        //xml文件的路径
        private string  xmlPath=@"C:\Program Files\Renji";
        //表示本次之前的按键状态为按下
        private bool KeyDownState = true;
        //键值的集合
        private ArrayList keyLst = new ArrayList();
        /// 表示按键的状态。false添加快捷键。true表示打开程序
        /// <summary>
        /// 表示按键的状态。false添加快捷键。true表示打开程序
        /// </summary>
        private bool blKeyState = true;
        private frmDispLoc frmDispLocation;

        /// <summary>
        /// 是否启用关机
        /// </summary>
        private bool isshutdown = false;
        /// <summary>
        /// 临时关机计划时间
        /// </summary>
        string tmptime = "";
        /// <summary>
        /// 关机时间
        /// </summary>
        string time = "";

        bool isDelay = false;
        int delay_time = 10 ;

        HookKey.HOOKPROC prc;

        enum  frmDispLoc
        {
            left,
            right,
            top,
            buttom,
            center,
        }

        #endregion

        #region SystemEvent
        private void frmTop_Load(object sender, EventArgs e)
        {
            frmDispLocation = frmDispLoc.top;
            PPicBoxLoction =new Point ( PpicboxInitLocation.X ,PpicboxInitLocation .Y +10);
            TxtKey(false);
            this.Size = pFrmSize;
            //Region  rg= new Region (this.TranPicbox((Bitmap) this.BackgroundImage));
            //this.Region = rg;
            LoadEvent();
            try
            {    
                ////控制键盘
                HookKey h = new HookKey();
                prc = new HookKey.HOOKPROC(H);
                h.InstallHookKey(prc);
            }
            catch
            { }
            //显示数据
            wd.path = xmlPath + "\\file.xml";
            if (System.IO.File.Exists(xmlPath + "\\file.xml"))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(xmlPath + "\\file.xml");
                if (ds.Tables.Count >= 1)
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        if ("appliction" == dt.TableName)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                AddPictureBox(dr);
                            }
                           
                        }
                        else if ("clock" == dt.TableName) 
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if(null != dr[2])
                                time = dr[2].ToString();
                                string week = DateTime.Now.DayOfWeek.ToString ();
                                if (-1 < dr["week"].ToString().IndexOf(week))
                                {
                                    isshutdown = true;
                                    time = dr["time"].ToString();
                                    this.timGJ.Enabled = true;
                                }
                                else
                                {
                                    isshutdown = false;
                                    this.timGJ.Enabled = false;
                                }
                            }
                        }
                    }
                }
                  
            } 
            else
            {
                wd.CreateFile();
                
            }
            pFrmLoction=new Point((Screen .GetWorkingArea(this).Width-this.Width )/2 ,this.Location .Y );
            this.Location =pFrmLoction  ;
            this.timFrm.Enabled = true;
        }
      

        void pb_Click(object sender, EventArgs e)
        {
            try
            {
                TxtKey(false);
                string[] tag = ((PictureBox)sender).Tag.ToString().Split('|');
                if (tag.Length >= 0)
                {
                    if (System.IO.File.Exists(tag[1]))
                        System.Diagnostics.Process.Start("explorer.exe",tag[1]);
                }
            }
            catch
            {
                ShowMessage("启动程序时出错！");
            }
        }

        /// <summary>
        /// 设置可以拖拽的对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
            blChange = true;
            this.timFrm.Enabled = true;
        }

        private void frmTop_DragDrop(object sender, DragEventArgs e)
        {
            string filePath, fileName = "";
            string guid,keys;
            try
            {
                if (pbCount >= allowAppCount)
                {
                    ShowMessage("你已经超过范围了,请勿在添加程序");
                    return;
                }
                string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                if (!System.IO.File.Exists(path))
                    return;
                if (Path.HasExtension(path))
                {
                    fileName = Path.GetFileName(path).Replace(Path.GetExtension(path), "");
                    filePath = GetPath(path);
                }
                else
                {
                    fileName = Path.GetFileName(path);
                    filePath = path;
                }
                foreach (Control ct in this.Controls)
                {
                    if (ct.Name.IndexOf("pb") >= 0)
                    {
                        string[] parar = ct.Tag.ToString().Split('|');
                        if (filePath == parar[1])
                        {
                            ShowMessage("要添加的程序已经存在！");
                            return;
                        }
                    }
                }
                wd.path = xmlPath + "\\file.xml";
                keys = "";

                try
                {
                    guid = Guid.NewGuid().ToString();
                    wd.AddRecord(fileName, filePath, keys, guid,pbCount.ToString () );
                    DataTable dt = new DataTable();
                    dt.Columns.Add("name", typeof(string));
                    dt.Columns.Add("path", typeof(string));
                    dt.Columns.Add("keys", typeof(string));
                    dt.Columns.Add("guid", typeof(string));
                    DataRow dr = dt.NewRow();
                    dr[0] = fileName;
                    dr[1] = filePath;
                    dr[2] = keys;
                    dr[3] = guid;
                    AddPictureBox(dr);
                }
                catch
                {
                    ShowMessage("添加失败！保存数据出错");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("添加失败！未知错误");
            }

        }

        private void FrmMouseEnter(object sender, EventArgs e)
        {
            blChange = true;
            
            this.Focus();
            this.TopMost = true;
            this.timFrm.Enabled  = true;

        }

        private void FrmMouseLeave(object sender, EventArgs e)
        {
            blChange = false;
           this.timFrm.Enabled = true;
        }

        private void timFrm_Tick(object sender, EventArgs e)
        {
            int bottom;
            if (blChange)
            {
                this.Focus();
                bottom = this.Location.Y + this.Height + increment;
                if (bottom < pFrmSize.Height)
                {
                    this.Location = new Point(this.Location.X, this.Location.Y + increment);
                }
                else
                {
                    this.Location = pFrmLoction;
                    this.timFrm.Enabled = false;
                }
            }
            else
            {
                bottom = this.Location.Y + this.Height - increment;
                if (bottom > 5)
                {
                    this.Location = new Point(this.Location.X, this.Location.Y - increment);
                }
                else
                {
                    TxtKey(false);
                    this.CMenuS.Visible = false;
                    this.CMenuSFrm.Visible = false;
                    bottom = increment - pFrmSize.Height - pFrmLoction.Y;
                    this.Location = new Point(this.Location.X, bottom); ;
                    this.timFrm.Enabled = false;
                }
            }
        }

        private void TSMenuIDelete_Click(object sender, EventArgs e)
        {
            try
            {
                TxtKey(false);
                int left = ((System.Windows.Forms.ToolStripMenuItem)sender).Owner.Left;
                string[] keysArray;
                Control ct;
                List<Control> ArrayCt = new List<Control>();
                //0没有找到要删除的文件，1找到要删除的文件，2.已经删除过文件
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    ct = this.Controls[i];
                    if (ct.Name.IndexOf("pb") > -1)
                    {
                        if (this.Location.X + ct.Left <= left && this.Location.X + ct.Left + ct.Width >= left)
                        {
                            string[] keyApp = ct.Tag.ToString().Split('|');
                            if (keyApp.Length >= 3)
                            {

                                ArrayCt.Add(ct);
                            }
                        }
                        else
                        {
                            if (this.Location.X + ct.Left > left)
                            {
                                ct.Location = new Point(ct.Left - pPicBoxSize.Width - increment, ct.Location.Y);
                                keysArray = ct.Tag.ToString().Split('|');
                                if (keysArray.Length >= 5)
                                {
                                    if (keysArray[4] == "Sys")
                                    {
                                        //名字，路径，guid，快捷键,可选表示是否系统自定的
                                        string k = keysArray[3].Split(',', '+')[1];
                                        ct.Tag = string.Format("{0}|{1}|{2}|shift,{3}|Sys", keysArray[0], keysArray[1], keysArray[2], (char)(char.Parse(k) - 1), keysArray[4]);
                                    }
                                }
                            }
                        }

                    }
                }
                foreach (Control ctt in ArrayCt)
                {
                    string[] keyApp = ctt.Tag.ToString().Split('|');
                    wd.DeleteRecord(keyApp[2].ToString());
                    this.Controls.Remove(ctt);
                    pbCount--;
                    PPicBoxLoction = new Point(PPicBoxLoction.X - pPicBoxSize.Width - increment, PPicBoxLoction.Y);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("删除失败，数据错误");
            }
        }

        private void TSMenuIAddKeys_Click(object sender, EventArgs e)
        {
            try
            {
                int left = ((System.Windows.Forms.ToolStripMenuItem)sender).Owner.Left;
                int top = ((System.Windows.Forms.ToolStripMenuItem)sender).Owner.Top;
                Control ct = null;
                foreach (Control ctt in this.Controls)
                {

                    if (ctt.Name.IndexOf("pb") > -1)
                    {
                        string[] keyApp = ctt.Tag.ToString().Split('|');
                       
                        if (this.Location.X + ctt.Left <= left && this.Location.X + ctt.Left + ctt.Width >= left)
                        {

                            if (keyApp.Length >= 5)
                            {
                                ct = ctt;
                                break;
                            }
                           
                        } 

                    }
                }
                if (ct != null)
                {
                    TxtKey(true);
                    txtKey.TextChanged -= new EventHandler(txtKey_TextChanged);
                    try
                    {
                        txtKey.Location = new Point(ct.Location.X, ct.Location.Y + ct.Height);
                        string[] tag = ct.Tag.ToString().Split('|');
                        txtKey.Text = tag[3].Replace(",", "+");
                        txtKey.BorderStyle = BorderStyle.Fixed3D;
                        txtKey.SelectAll();
                        txtchangebl = false;
                        blKeyState = false;
                    }
                    catch
                    { }
                    txtKey.TextChanged += new EventHandler(txtKey_TextChanged);
                    
                }

            }
            catch (Exception ex)
            {
                ShowMessage("快捷键修改出错");
            }
          
        }
        
        private void TSMenuIExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void TSmenuIOwer_Click(object sender, EventArgs e)
        {
            ShowMessage("作者：任忌\r\nQQ：625246906\r\nEmail:rentiansheng@163.com\r\n版本号2.0\r\nblog:http://www.rhttp.cn");
          
        }

        

        #endregion

        #region Myfunction

        private void LoadEvent()
        {
            this.Click += new EventHandler(delegate(object obj, EventArgs eArgs)
            {
                TxtKey(false);
            });
            CMenuS.MouseEnter += new EventHandler(FrmMouseEnter);
            CMenuS.MouseLeave += new EventHandler(FrmMouseLeave);
            CMenuSFrm.MouseEnter += new EventHandler(FrmMouseEnter);
            CMenuSFrm.MouseLeave += new EventHandler(FrmMouseLeave);
            this.MouseEnter += new EventHandler(FrmMouseEnter);
            this.MouseLeave += new EventHandler(FrmMouseLeave);
            this.txtKey.MouseEnter += new EventHandler(FrmMouseEnter);
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(frmTop_DragEnter);
            this.DragDrop += new DragEventHandler(frmTop_DragDrop);
        }

        /// 键盘钩子的回调事件
        /// <summary>
        /// 键盘钩子的回调事件
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private int H(int nCode, int wParam, IntPtr lParam)
        {
            string keys = "";
            try
            {
                if (nCode >= 0)
                {
                    GetKey getKey = new GetKey();
                    HookKey.KeyClass key = new HookKey.KeyClass();
                    if (wParam % 2 == 0)
                    {
                        // 键盘按下 
                        KeyDownState = true;
                        key = (HookKey.KeyClass)System.Runtime.InteropServices.Marshal.PtrToStructure(lParam, typeof(HookKey.KeyClass));
                        keyLst.Add(key.vkCode);
                    }
                    if (wParam % 2 != 0 && KeyDownState)
                    {

                        // 键盘抬起 
                        KeyDownState = false;
                        Keys skey;
                        foreach (int k in keyLst)
                        {

                            skey = (Keys)k;
                            string strK = getKey.GetKeyText(skey);
                            if (keys == "")
                                keys = strK;
                            else
                            {
                                if(-1 == keys.IndexOf (strK ))
                                if (strK.Length > 1)
                                    keys = strK + "," + strK;
                                else keys += "," + strK;
                            }
                        }
                        // this.richTextBox1.Text += "抬起 ";
                        BllControl(keys);
                        keyLst.Clear();
                    }

                    int i = HookKey.CallNextHookEx((int)HookKey.IdHook.WH_KEYBOARD_LL, nCode, wParam, lParam);

                }

            }
            catch (Exception ex)
            {
                if (!blKeyState)
                Application.Restart();
            }
            return 0;
        }

        /// <summary>
        /// 判断是要执行快捷键还是要写入快捷键呀
        /// </summary>
        /// <param name="keys"></param>
        private void BllControl(string keys)
        {
            string[] sys = new string[] { "shift,esc", "esc,shift", "esc,esc"};
            try
            {
                if ((keys.ToLower() == sys[1] || keys.ToLower() == sys[0] || keys.ToLower() == sys[2]) && blKeyState)
                {
                    this.Visible = !this.Visible;
                    return;
                }
                if (blKeyState)
                {
                    string[] keysAry = keys.ToLower().Split(',');
                    string[] keysApp;
                    int keysAppLength;

                    foreach (Control ct in this.Controls)
                    {
                        if (ct.Name.IndexOf("pb") > -1)
                        {
                            keysApp = ct.Tag.ToString().ToLower().Split('|');
                            if (keysApp.Length >= 5)
                            {
                                if (keys.Length != keysApp[3].Length)
                                    continue;
                                foreach (string key in keysAry)
                                {
                                    if (keysApp[3]!="")
                                    keysApp[3] = keysApp[3].Replace(key, "");
                                }

                                if (keysApp[3]!=""&&keysApp[3].Replace("+", "").Trim() == "")
                                {
                                    if (System.IO.File.Exists(keysApp[1]))
                                        System.Diagnostics.Process.Start("explorer.exe", keysApp[1]);
                                    
                                }
                            }
                        }
                    }

                }
                else
                {
                    if (keys != "")
                    {
                        this.txtKey.Text = keys.Replace(",", "+");
                    }
                    
                }
            }
            catch (Exception ex)
            {
               
            }
        }


        /// 得到路径
        /// <summary>
        /// 得到路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetPath(string path)
        {
            if (path.IndexOf(".lnk") > 0 || path.IndexOf(".LNK") > 0)
            {
                IWshShell_Class shell = new IWshShell_ClassClass();
                IWshShortcut _shortcut = shell.CreateShortcut(path) as IWshShortcut;
                if(0 >_shortcut.TargetPath .IndexOf ("{") )
                return _shortcut.TargetPath;
            }
            return path;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg,"提示");
        }


        private bool AddPictureBox(DataRow dr)
        {
            string keys;
            try
            {
                
                PictureBox pb = new PictureBox();
                pb.BackColor = this.BackColor;
                pb.AllowDrop = true;
                pb.Size = pPicBoxSize;
                pb.Location = PPicBoxLoction;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Name = "pb" + pbCount.ToString();
                string path = dr[1].ToString();
                Icon icon;
                if (System.IO.File.Exists(path))
                {
                    icon = System.Drawing.Icon.ExtractAssociatedIcon(path);
                }
                else
                {
                    return false;
                    icon = null;
                }
                pb.Image = icon.ToBitmap();
                //应用新的区域
                //pb.Region = new Region(TranPicbox ((Bitmap )(pb.Image )));
                //TranPicbox((Bitmap)(pb.Image));
                pb.Cursor = Cursors.Hand;
                keys = dr[2].ToString().Trim();
               
                if (keys == "")
                {
                    if (pbCount < 10)
                    {
                        keys = "Alt+" + pbCount.ToString();
                    }
                    else
                    {
                        keys ="Alt+" +(char)(55+pbCount );
                    }
                }

                string notice = string.Format("{0}\r\n快捷键：{1}", dr[0], keys.Replace (",","+") /*pbCount[2]*/);
                //路径，guid，快捷键,可选表示是否系统自定的
                if (dr[2].ToString().Trim() == "")
                    keys = keys + "|Sys";
                else
                    keys += "|User";
                //名字，路径，guid,keys,sys
                pb.Tag = dr[0]+"|"+dr[1] + "|" + dr[3] + "|" + keys;
                frmDelete frm=null;
                Control ct = null;
                Point pMousDown = new Point(0,0);
                //用于移动frmDelete的矫正
                Point pMouseLocation = new Point(0,0);
                //用于看pb控件移动前的位置
                Point pMouseLocation1 = new Point(0, 0);
                pb.MouseEnter += new EventHandler(delegate(object sender, EventArgs ea)
                    {
                        pb.Size = new Size(pPicBoxSize.Width + 15, pPicBoxSize.Height  + 15);
                        pb.BringToFront();
                        if (frmDispLocation == frmDispLoc.top || frmDispLocation == frmDispLoc.buttom)
                           MouseEnterMove(pb.Location.X  );
                        else
                            MouseEnterMove(pb.Location.Y );
                        
                    });
                pb.MouseLeave  += new EventHandler(delegate(object sender, EventArgs ea)
                {
                    if (pb.Size != pPicBoxSize)
                    {
                        pb.Size = pPicBoxSize;
                        if (frmDispLocation == frmDispLoc.top || frmDispLocation == frmDispLoc.buttom)
                            MouseLeaveMove(pb.Location.X);
                        else
                            MouseLeaveMove(pb.Location.Y );

                    }
                });
                //pb左右移动的的距离
                pb.MouseDown += new MouseEventHandler(delegate(object obj, MouseEventArgs mouse)
                    {
                        if (pb.Size != pPicBoxSize)
                        {
                            pb.Size = pPicBoxSize;
                            if (frmDispLocation == frmDispLoc.top || frmDispLocation == frmDispLoc.buttom)
                                MouseLeaveMove(pb.Location.X);
                            else
                                MouseLeaveMove(pb.Location.Y);
                        }
                        if (mouse.Button == MouseButtons.Left)
                        {
                            blPbDrag = true;
                            pMousDown = mouse.Location;
                            pMouseLocation =MousePosition  ;
                            pMouseLocation1=MousePosition ;
                        }
                    }
                    );
                pb.MouseMove += new MouseEventHandler(delegate(object ebj, MouseEventArgs e)
                {

                    if (e.Button == MouseButtons.Left)
                    {
                        if (blPbDrag)
                        {
                            if (frm == null || frm.IsDisposed)
                            {
                                //pb.DoDragDrop("任忌热键删除动作", DragDropEffects.All);
                                ct = ((Control)ebj);
                                frm = new frmDelete(ct.Tag.ToString().Split('|')[1]);
                                frm.Show();
                                ct.Visible = false;
                            }
                            //pb.Location = new Point();
                            frm.Location = new Point(MousePosition.X - pMousDown.X, MousePosition.Y - pMousDown.Y);
                            Point p = IsMovePb(MousePosition.X - pMouseLocation1.X, frm.Location.X, ct);
                            {
                                if (p != new Point())
                                {
                                    pMouseLocation1 = MousePosition;
                                }
                            }
                            //frm.Show();
                        }
                    }
                  
                });
                pb.MouseUp += new MouseEventHandler(delegate(object obj, MouseEventArgs mouse)
                    {
                        try
                        {
                            if (blPbDrag)
                            if (!frm.IsDisposed && frm != null)
                            {
                                if (frm.Location.Y + frm.Height < this.Location.Y || mouse.Y > this.Location.Y + this.Height || this.Location.X + this.Width < frm.Location .X || this.Location.X > frm.Location.X + frm.Width)
                                {

                                    frm.Show();
                                    frm.Location = new Point(MousePosition.X - pMousDown.X, MousePosition.Y - pMousDown.Y);
                                    frm.timFrmChange.Enabled = true;
                                    DeletePb(ct);

                                }
                                else
                                {

                                    frm.Close();
                                    frm.Dispose();
                                    ct.Visible = true;
                                }
                            }
                            blPbDrag = false;
                        }
                        catch (Exception ex)
                        {
                            blPbDrag = false;
                            ShowMessage(ex.ToString ());
                        }
                    });
                toolTipApp.SetToolTip(pb, notice);
                pb.ContextMenuStrip = this.CMenuS;
                this.Controls.Add(pb);
                pb.MouseEnter += new EventHandler(FrmMouseEnter);
               // pb.Click += new EventHandler(pb_Click);
                PPicBoxLoction = new Point(PPicBoxLoction.X + pb.Width + increment, PPicBoxLoction.Y);
                pbCount++;
                return true;
            }
            catch(Exception ex)
            {
                ShowMessage(ex.ToString ());
                return false;
            }

        }

        private GraphicsPath TranPicbox(Bitmap bmp)
        {
            GraphicsPath resultPath = new GraphicsPath();
            int height, width;
            height = bmp.Height ;
            width = bmp.Width;
            int nextCol;
            Color tranSparent = bmp.GetPixel(0, 0);
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (bmp.GetPixel(col,row) == tranSparent)
                    {

                        //bmp.SetPixel(col, row,Color.Transparent );
                        for (nextCol = col; nextCol < width; nextCol++)
                        {
                            if (bmp.GetPixel(nextCol, row) == tranSparent)
                            {

                                break;
                            }
                        }
                        resultPath.AddRectangle(new Rectangle(row, col, width - col, 1));
                        col = nextCol;
                    }
                }
            }
            return resultPath;
        }


        private Point  IsMovePb(int moveX,int locationX,Control ct)
        {
            Point beforeLoction=ct.Location ;
            Point p=new Point ();
            Control ctt=null ;
            bool bl = false;
            //标识ct是否后移 true是
            bool blMove = false;
            if (moveX > pPicBoxSize.Width / 2+5 && locationX > ct.Parent.Location.X + ct.Location.X  + pPicBoxSize.Width / 2 )
            { 
                bl = true;
                p = new Point(ct.Location.X + pPicBoxSize.Width + increment, ct.Location.Y);
                ctt = GetPb(p);
                //名字，路径，guid,keys,sys
                blMove = true;
                
            }
            if (-moveX > pPicBoxSize.Width / 2 + 5 /*&& locationX > ct.Parent.Location.X + ct.Location.X + ct.Width + pPicBoxSize.Width / 2 + 5*/)
            {
                if (locationX< ct.Parent.Location.X + ct.Location.X  - pPicBoxSize.Width / 2)
                {
                    bl = true;
                    p = new Point(ct.Location.X - pPicBoxSize.Width - increment, ct.Location.Y);
                    ctt = GetPb(p);
                    blMove = false;
                }
            }
            if (p != new Point())
            {
                if (p.X >= PPicBoxLoction.X)
                    ct.Location = new Point(PPicBoxLoction.X - pPicBoxSize.Width - increment, PPicBoxLoction.Y);
                else
                    ct.Location = p;
                SetTipControl(ctt, !blMove);
                SetTipControl(ct,blMove );
            }
            if (ctt != null && bl)
            {
                ctt.Location = beforeLoction;

            }
            return p;
        }

        private void MouseEnterMove(int locationx)
        {
            foreach (Control ct in this.Controls)
            {
                if (ct.Name.IndexOf("pb") > -1)
                {
                    if (frmDispLocation == frmDispLoc.top || frmDispLocation == frmDispLoc.buttom)
                    {
                        if (ct.Left > locationx)
                        {
                            ct.Location = new Point(ct.Location.X + 15, ct.Location.Y);
                        }
                    }
                    else
                    {
                        if (ct.Top  > locationx)
                        {
                            ct.Location = new Point(ct.Location.X , ct.Location.Y+ 15);
                        }
                    }

                }
            }  
        }

        private void MouseLeaveMove(int locationx)
        {
            foreach (Control ct in this.Controls)
            {
                if (ct.Name.IndexOf("pb") > -1)
                {
                    if (frmDispLocation == frmDispLoc.top || frmDispLocation == frmDispLoc.buttom)
                    {
                        if (ct.Left > locationx)
                        {
                            ct.Location = new Point(ct.Location.X - 15, ct.Location.Y);
                        }
                    }
                    else
                    {
                        if (ct.Top > locationx)
                        {
                            ct.Location = new Point(ct.Location.X, ct.Location.Y - 15);
                        }
                    }

                }
            }  
        }

        private Control GetPb(Point p)
        {
            foreach (Control ct in this.Controls)
            {
                if (ct.Name.IndexOf("pb") > -1)
                {
                    if (ct.Left == p.X )
                    {
                        return ct;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 使用线程移动图片了
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ct"></param>
        private void ThreadMovePic(int dlocation, Control ct)
        {
            try
            {
                int ctlocation = ct.Location.X;
                if (dlocation < ctlocation)
                    incrementMov = -incrementMov;
                while (dlocation != ctlocation)
                 {
                    if (incrementMov < 0)
                    {
                        if (ct.Location.X + incrementMov < dlocation)
                        {
                            ct.Location = new Point(dlocation, ct.Location.Y);
                        }
                        else
                        {
                            ct.Location = new Point(ct.Location.X + incrementMov, ct.Location.Y);
                        }
                    }
                    else
                    {
                        if (ct.Location.X + incrementMov > dlocation)
                        {
                            ct.Location = new Point(dlocation, ct.Location.Y);
                        }
                        else
                        {
                            ct.Location = new Point(ct.Location.X + incrementMov, ct.Location.Y);
                        }
                    }
                    ctlocation = ct.Location.X;
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="bl">是否向后移动</param>
        private void SetTipControl(Control ct, bool bl)
        {
            try
            {
                string[] tag = ct.Tag.ToString().Split('|');
                string notice;
                if (tag.Length >= 5)
                {
                    if (tag[4] == "Sys")
                    {
                        //名字，路径，guid，快捷键,可选表示是否系统自定的
                        string k = tag[3].Split(',', '+')[1];
                        if (bl)
                        {
                            if (k == "9")
                                k = ((char)(char.Parse("A"))).ToString();
                            else
                                k = ((char)(char.Parse(k) + 1)).ToString();
                        }
                        else
                        {
                            if (k == "A")
                                k = ((char)(char.Parse("9"))).ToString();
                            else
                                k = ((char)(char.Parse(k) - 1)).ToString();
                        }
                        ct.Tag = string.Format("{0}|{1}|{2}|ALT+{3}|Sys", tag[0], tag[1], tag[2], k, tag[4]);
                        notice = string.Format("{0}\r\n快捷键：{1}", tag[0], "Alt+" + k /*pbCount[2]*/);
                        toolTipApp.SetToolTip(ct, notice);
                    }
                }
            }catch (Exception ex)
            {}
        }


        /// <summary>
        /// 设置txtKey是否显示了
        /// </summary>
        /// <param name="bl">true显示</param>
        private void TxtKey(bool bl)
        {
            this.txtKey.Visible = bl;
            blKeyState =bl?false:true;
        }

        private void RunSys()
        {
            try
            {
                string appPath = Application.ExecutablePath;
                RegistryKey registry = Registry.LocalMachine;

                object hotkey = registry.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\").GetValue("HookKey");


                if (hotkey == null)
                {
                    
                    RegistryKey run = registry.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    run.SetValue("HookKey", appPath);
                    run.Close();
                    frmhelp f = new frmhelp();
                    f.Show();

                }
                else
                {

                    if (hotkey.ToString() != appPath)
                    {
                        //RegistryKey run = registry.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                        //run.SetValue("HookKey", appPath);
                       //run.Close();
                    }

                }

            }
            catch (Exception ex)
            {
                ShowMessage("没有权限设置自动启动！");
            }
        }


        private void DeletePb(Control ct)
        {
            Control pbCt;
            try
            {
                string[] keyApp = ct.Tag.ToString().Split('|');
                wd.DeleteRecord(keyApp[2].ToString());
                this.Controls.Remove(ct);
                pbCount--;
                PPicBoxLoction = new Point(PPicBoxLoction.X - pPicBoxSize.Width - increment, PPicBoxLoction.Y);
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    string[] keysArray;
                    pbCt = this.Controls[i];
                    if (pbCt.Name.IndexOf("pb") > -1)
                    {
                        if (pbCt.Left > ct.Left)
                        {
                            pbCt.Location = new Point(pbCt.Left - pPicBoxSize.Width - increment, ct.Location.Y);
                            keysArray = pbCt.Tag.ToString().Split('|');
                            if (keysArray.Length >= 5)
                            {
                                if (keysArray[4] == "Sys")
                                {
                                    //名字，路径，guid，快捷键,可选表示是否系统自定的
                                    string k = keysArray[3].Split(',', '+')[1];
                                    ct.Tag = string.Format("{0}|{1}|shift,{2}|{3}", keysArray[0], keysArray[1], keysArray[3], (char)(char.Parse(k) - 1), keysArray[4]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage("删除错误！");
            }
        }

       
        #endregion

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            ArrayList keysArr = new ArrayList();

            Control ct = null, findControl = (Control)sender;
            foreach (Control ctt in this.Controls)
            {

                if (ctt.Name.IndexOf("pb") > -1)
                {
                    string[] keyApp = ctt.Tag.ToString().Split('|');

                    if (ctt.Left <= findControl.Location.X && ctt.Left + ctt.Width >= findControl.Location.X)
                    {

                        if (keyApp.Length >= 5)
                        {
                            ct = ctt;
                            continue;
                        }

                    }
                    keysArr.Add(keyApp[3]);

                }
            }
            try
            {
                if (ct != null)
                {
                    string[] tag = ct.Tag.ToString().Split('|');
                    string notice = string.Format("{0}\r\n快捷键：{1}", tag[0], txtKey.Text);

                    if (txtKey.Text.Trim() != "" && txtKey.Text.Trim() != "快捷键已存在！从新输入")
                    {
                        string[] txtKeys = this.txtKey.Text.Split('+');
                        string k;
                        foreach (string txtk in keysArr)
                        {
                            k = txtk.ToLower();
                            foreach (string skey in txtKeys)
                            {
                                if (k == "")
                                    continue;
                                k = k.Replace(skey.ToLower(), "");


                            }

                            if (k != "" && k.Replace("+", "").Trim() == "")
                            {
                                txtKey.TextChanged -= new EventHandler(txtKey_TextChanged);
                                this.txtKey.Text = "快捷键已存在！从新输入";
                                txtKey.TextChanged += new EventHandler(txtKey_TextChanged);
                                txtKey.Tag = "false";
                                blKeyState = false;
                                txtchangebl = false;
                                return;

                            }

                        }

                        txtKey.Tag = "true";
                        if (txtKey.Tag != null && txtKey.Tag.ToString().Trim() == "true")
                        {
                            ct.Tag = string.Format("{0}|{1}|{2}|{3}|User", tag[0], tag[1], tag[2], txtKey.Text);
                            wd.EditRecord(tag[0], tag[1], txtKey.Text, tag[2]);
                            this.txtKey.BorderStyle = BorderStyle.None;
                            this.toolTipApp.SetToolTip(ct, notice);
                            blKeyState = true;
                            txtchangebl = true;
                            //txtKey.TextChanged -= new EventHandler(txtKey_TextChanged);
                            //txtKey.Location = new Point(8000, 1025);
                            //this.txtKey.Clear();
                            //txtKey.TextChanged += new EventHandler(txtKey_TextChanged);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtKey.TextChanged -= new EventHandler(txtKey_TextChanged);
                txtKey .Text =("快捷键修改出错");
                txtKey.TextChanged += new EventHandler(txtKey_TextChanged);
            }

        }

        private void 顶部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.frmDispLocation != frmDispLoc.top)
            {
                if (this.frmDispLocation != frmDispLoc.buttom )
                ChangeDisHorizontal();
                int i = Screen.PrimaryScreen.WorkingArea.Width;
                this.Location = new Point(i/2-this.Width /2,0);
                this.frmDispLocation = frmDispLoc.top;
            }
        }

        private void ChangeDisHorizontal()
        {
            PPicBoxLoction = new Point(PpicboxInitLocation.X, PpicboxInitLocation.Y  + 10);
            
            foreach (Control ct in this.Controls)
            {
                if (ct.Name.IndexOf("pb") >= 0)
                {
                    ct.Location  = PPicBoxLoction;
                    PPicBoxLoction = new Point(PPicBoxLoction.X + this.pPicBoxSize.Width + increment,ct.Location .Y );
                    this.Size = new Size(PPicBoxLoction.X,pFrmSize .Height  );
                }
            }
        }

        private void 左边ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDispLocation != frmDispLoc.left)
            {
                if(  frmDispLocation != frmDispLoc.right)
                ChangeDisVertical();
                int i = Screen.PrimaryScreen.WorkingArea.Height;
                this.Location = new Point(0, i / 2 - this.Height / 2);
                this.frmDispLocation = frmDispLoc.left;
            }
        }

        private void ChangeDisVertical()
        {
            PPicBoxLoction =new Point ( PpicboxInitLocation.X +10,PpicboxInitLocation .Y );
            foreach (Control ct in this.Controls)
            {
                if (ct.Name.IndexOf("pb") >= 0)
                {
                    ct.Location = PPicBoxLoction;
                    PPicBoxLoction = new Point(ct.Location .X  , ct.Location.Y+ this.pPicBoxSize.Height  + increment);
                    this.Size = new Size(pFrmSize .Height , PPicBoxLoction.Y);
                }
            }
        }

        private void 右边ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmDispLocation != frmDispLoc.right)
            {
                if (frmDispLocation != frmDispLoc.left )
                ChangeDisVertical();
                int i = Screen.PrimaryScreen.WorkingArea.Height;
                int width = Screen.PrimaryScreen.WorkingArea.Width-this.Size.Width   ;
                this.Location = new Point(width, i / 2 - this.Height / 2);
                this.frmDispLocation = frmDispLoc.right ;
            }
        }

        private void 下边ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.frmDispLocation != frmDispLoc.buttom)
            {
                if (this.frmDispLocation != frmDispLoc.top)
                    ChangeDisHorizontal();
                int i = Screen.PrimaryScreen.WorkingArea.Width;
                int top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
                this.Location = new Point(i / 2 - this.Width / 2, top);
                this.frmDispLocation = frmDispLoc.buttom ;
            }
        }

        private void RMunHidden_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSetting frmset = new frmSetting(xmlPath + "\\file.xml",tmptime );
            bool bl = isshutdown;
            frmset.ShowDialog();
            if (isshutdown)
            {
                if (frmset.loginout)
                {
                    isshutdown = true;
                    tmptime  = frmset.shutdowntime;
                }
                else
                {
                    tmptime = "";
                    isshutdown = false;
                }


            }
            DataSet ds = new DataSet();
            ds.ReadXml(xmlPath + "\\file.xml");
            if (ds.Tables.Count >= 1)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    if ("clock" == dt.TableName)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            if (null != dr[2])
                                time = dr[2].ToString();
                            string week = DateTime.Now.DayOfWeek.ToString();
                            if (-1 < dr["week"].ToString().IndexOf(week))
                            {
                                isshutdown = true;
                                time = dr["time"].ToString();
                                this.timGJ.Enabled = true;
                            }
                            else
                            {
                                isshutdown = false;
                                this.timGJ.Enabled = false;
                            }
                        }
                    }
                }
            }

          
        }
       
        private void timGJ_Tick(object sender, EventArgs e)
        {
            bool  isgj=false ;
            if (isshutdown)
            {
                int nowHour = DateTime.Now.Hour;
                int nowMinutes = DateTime.Now.Minute;
                if ("" != tmptime)
                {
                    string[] tmp = tmptime.Split(':');
                    if (int.Parse(tmp[0]) == nowHour && int.Parse(tmp[1]) == nowMinutes) isgj = true;
                }
                if ("" != time)
                {
                    string[] tmp = time.Split(':');
                    if (int.Parse(tmp[0]) == nowHour && int.Parse(tmp[1]) == nowMinutes) isgj = true;
                }
            }
            if (isgj)
            {
                frmdialog  dialog = new frmdialog ();
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    Process winrar = new Process();
                    winrar.StartInfo.FileName = "shutdown.exe";
                    winrar.StartInfo.CreateNoWindow = true;
                    winrar.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    winrar.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    winrar.StartInfo.Arguments = " -s -f -t 1";
                    winrar.Start();

                    winrar.Close();
                    Application.Exit();
                }
            }
        }

        private void 加密工具ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDes frmdes = new frmDes();
            frmdes.Show();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmhelp f = new frmhelp();
            f.Show();
        }
    }
}
