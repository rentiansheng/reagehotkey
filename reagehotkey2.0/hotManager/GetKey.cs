//======================================================================
//
//        Copyright (C) 2007-2013 三月软件工作室    
//        All rights reserved
//
//        filename :Class
//        description :
//
//        created by任天胜 at  06/07/2011 18:41:28
//        qq:625246906
//        blog: http://www.rhttp.com
//======================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows .Forms;

namespace hotManager
{
    class GetKey
    {
        public string GetKeyText(Keys  key )
        {
            if (key >= Keys.A && key <=Keys.Z)
            {
                return key.ToString();
            }
            if (key >= Keys.NumPad0 && key <= Keys.NumPad9)
            {
               
                return (key -(int) Keys.NumPad0).ToString ();
            }
            if (key == Keys.Escape)
            {
                return "ESC";
            }
            if (key >=Keys.F1 && key <= Keys.F24)
            {
                return key.ToString();
            }
            if (key >= Keys.PageUp && key<=Keys.Home )
            {
                if (key ==Keys.PageDown)
                {
                    return "PageDown";
                }
                return key.ToString();
            }
            if (key ==Keys.RControlKey || key == Keys.LControlKey)
            {
                return "Ctrl";
            }
            if (key == Keys.LShiftKey  || key == Keys.RShiftKey )
            {
                return "Shift";
            }
            if (key == Keys.Alt || key == Keys.LMenu || key==Keys.RMenu )
            {
                return "Alt";
            }
            switch(key)
            {
                case Keys.Add :
                    return "+";
                    break;
                case Keys .Subtract :
                    return "-";
                    break;
                case Keys .Divide :
                    return "/";
                    break;
                case Keys.Multiply :
                    return "*";
                    break;
                case Keys.Insert :
                    return "Insert";
                    break;
                case Keys.Delete :
                    return "Delete";
                    break;
                case Keys .Capital :
                    return "Caps lock";
                case Keys.Oemtilde :
                    return "~";
                    break;
                case Keys.Oemplus :
                    return "+";
                    break;
                case Keys.OemMinus :
                     return "-";
                    break;
                case Keys .OemPeriod :
                     return ".";
                    break;
                case Keys.Oemcomma:
                    return ",";
                    break;
                case Keys.OemQuestion:
                    return "?";
                    break;
                case Keys.Up:
                    return ((char)24).ToString ();
                    break;
                case Keys.Down :
                    return ((char)25).ToString();
                    break;
                case Keys.Left :
                    return ((char)27).ToString();
                    break;
                case Keys.Right :
                    return ((char)26).ToString();
                    break;
                  
            }
            if (key >= Keys.D0 && key <= Keys.D9)
            {
                return (key-Keys.D0 ).ToString();
            }
            return "";
           
        }
    }
}
