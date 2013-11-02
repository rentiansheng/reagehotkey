using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace hotManager
{
    public partial class frmSetting : Form
    {
       
        public frmSetting(string path)
        {
            InitializeComponent();
            this.path = path;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\bg.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        public frmSetting(string path,string tmptime)
        {
            InitializeComponent();
            this.path = path;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\bg.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            shutdowntime = tmptime;
            if (null == tmptime || "" == tmptime.Trim())
                tmptime = "00:00";
            this.txtTmpTime.Text = tmptime;
        }

        string path;
        string strt = "";
        public bool loginout = false;
        public string shutdowntime = "";
        private void frmSetting_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.timInit.Enabled = true;
            this.lstvtime .MultiSelect  =true ;
            this.lstvtime.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            if (ds.Tables.Count >= 1)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    if ("clock" == dt.TableName)
                    {
                       
                        if (4 > dt.Columns.Count) break;
                        ListViewItem lstitem = new ListViewItem();
                        foreach (DataRow dr in dt.Rows)
                        {
                            #region
                            //    lstitem.SubItems.Add(dr[1].ToString ());
                            //    lstitem.SubItems.Add(dr[2].ToString());
                            //    string strweek="";
                            //    foreach (string week in dr[3].ToString ().Split(','))
                            //    {
                            //        switch (week.Trim())
                            //        {
                            //            case "Monday": strweek += "星期一,"; break;
                            //            case "Tuesday": strweek += "星期二,"; break;
                            //            case "Wednesday": strweek += "星期三,"; break;
                            //            case "Thursday": strweek += "星期四,"; break;
                            //            case "Friday": strweek += "星期五,"; break;
                            //            case "Saturday": strweek += "星期六,"; break;
                            //            case "Sunday": strweek += "星期日,"; break;
                            //        }
                            //    }
                            //    lstitem.SubItems.Add(strweek);
                            //    lstitem.SubItems.Add(dr[4].ToString());
                            //    this.lstvtime.Items.Add(lstitem );
                            #endregion
                            this.txtName.Text = dr[1].ToString();
                            this.txtName.Tag = dr[0].ToString();
                            this.txttime.Text = dr[2].ToString();
                            foreach (string week in dr[3].ToString ().Split(','))
                            {
                                switch (week.Trim())
                                {
                                    case "Monday": this.chkMonday.Checked = true; break;
                                    case "Tuesday": this.chkTuesday.Checked = true; break;
                                    case "Wednesday": this.chkWednesday.Checked = true; break;
                                    case "Thursday": this.chkThursday.Checked = true; break;
                                    case "Friday": this.chkFriday.Checked = true; break;
                                    case "Saturday": this.chkSaturday.Checked = true; break;
                                    case "Sunday": this.chkSunday.Checked = true; break;
                                }
                            }
                        }
                        
                       

                        if (0 < lstvtime.Items.Count)
                            lstvtime.Items[0].Selected = true;
                        break;
                    }
                }
                 
            }
 
        }

        private void lstvtime_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection selCollection = lstvtime .SelectedIndices ;
            if (selCollection.Count == 1)
            {
                ListViewItem lstitem =this.lstvtime .Items[selCollection [0]];
                this.txtName.Text = lstitem.SubItems[1].Text ;
                this.txtName.Tag = lstitem.SubItems[4].Text;
                this.txttime.Text = lstitem.SubItems[2].Text;
                foreach (string week in lstitem.SubItems[3].Text.Split (','))
                {
                    switch (week.Trim())
                    {
                        case "星期一": this.chkMonday.Checked = true; break;
                        case "星期二": this.chkTuesday.Checked = true; break;
                        case "星期三": this.chkWednesday.Checked = true; break;
                        case "星期四": this.chkThursday.Checked = true; break;
                        case "星期五": this.chkFriday.Checked = true; break;
                        case "星期六": this.chkSaturday.Checked = true; break;
                        case "星期日": this.chkSunday.Checked = true; break;
                    }
                }
            }
        }

     

        private void txttime_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ('0' <= e.KeyChar && '9' >= e.KeyChar)
            {
                strt = this.txttime.Text;
            }
            else
            {
                if ('\b' == e.KeyChar)
                {
                    int position = this.txttime.SelectionStart;
                    if (3 == position)
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }

        }

        private void txttime_TextChanged(object sender, EventArgs e)
        {
            int position = this.txttime.SelectionStart;
            if (-1 == this.txttime.Text.IndexOf(":"))
            {
                string txt = this.txttime.Text;
                this.txttime.Text = txt.Substring(0, txttime.SelectionStart) + ":" + txt.Substring(this.txttime.SelectionStart);
            }
            else
            {
                string[] time = this.txttime.Text.Split(':');
                if (0 == time[0].Trim ().Length)
                    this.txttime.Text = " :" + time[1];
                else
                {
                    if (0 != time[0].Trim().Length && 24 <= int.Parse(time[0])) this.txttime.Text = strt;
                    if (0 != time[1].Trim().Length && 59 <= int.Parse(time[1])) this.txttime.Text = strt;
                }

            }
            this.txttime.SelectionStart = position ;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = this.txtName .Text ;
            string time = this.txttime.Text;
            string [] atime=time.Trim().Split (':');
            if ("" == atime[0]){ this.statuslblmsg.Text = "时间格式不正确！";return ;}
            if ("" == atime[1]) { this.statuslblmsg.Text = "时间格式不正确！"; return; }
            string week ="";
            if (this.chkMonday.Checked) week += "Monday,";
            if (this.chkTuesday.Checked) week += "Tuesday,";
            if (this.chkWednesday.Checked) week += "Wednesday,";
            if (this.chkThursday.Checked) week += "Thursday,";
            if (this.chkFriday.Checked) week += "Friday,";
            if (this.chkSaturday.Checked) week += "Saturday,";
            if (this.chkSunday.Checked) week += "Sunday,";
              string guid;
              if (null == txtName.Tag) guid = "";else  guid = this.txtName.Tag.ToString ();
              WriteData xml = new WriteData();
              xml.path = path;
              if (xml.EditClock(name, time, week, guid, "")) this.statuslblmsg.Text = "操作成功！"; else this.statuslblmsg.Text = "操作失败！";
                
          
        }

        private void chkall_CheckedChanged(object sender, EventArgs e)
        {
            if (chkall.Checked)
            {
                this.chkMonday.Checked = true; 
                this.chkTuesday.Checked = true;
                this.chkWednesday.Checked = true;
                this.chkThursday.Checked = true;
                this.chkFriday.Checked = true;
                this.chkSaturday.Checked = true; 
                this.chkSunday.Checked = true; 
            }
        }

        private void chkSunday_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox )sender;
            if (!chk.Checked) this.chkall.Checked = false;
        }

        private void chkTuesday_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (!chk.Checked) this.chkall.Checked = false;
        }

        private void chkWednesday_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (!chk.Checked) this.chkall.Checked = false;
        }

        private void chkThursday_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (!chk.Checked) this.chkall.Checked = false;
        }

        private void chkFriday_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (!chk.Checked) this.chkall.Checked = false;
        }

        private void chkSaturday_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (!chk.Checked) this.chkall.Checked = false;
        }

        private void chkMonday_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (!chk.Checked) this.chkall.Checked = false;
        }

        private void btntmpset_Click(object sender, EventArgs e)
        {
            string[] atime = this.txtTmpTime.Text.Trim().Split(':');
            if ("" == atime[0]) { this.statuslblmsg.Text = "时间格式不正确！"; return; }
            if ("" == atime[1]) { this.statuslblmsg.Text = "时间格式不正确！"; return; }
            this.shutdowntime = this.txtTmpTime.Text.Trim();
            this.statuslblmsg.Text = "操作成功！";
          
            this.loginout = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.loginout = false;
            this.shutdowntime ="";
        }

        private void timInit_Tick(object sender, EventArgs e)
        {

            if (0.4 > this.Opacity)
                this.Opacity += 0.1;
            else
            {
                if (0.5 > this.Opacity)
                    this.Opacity += 0.04;
                else
                    this.Opacity += 0.09;
            }
            if (100f <= this.Opacity) this.timInit.Enabled = false; 
        }
    }
}
