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
using System.Text;
using System.Runtime .InteropServices ;
using Microsoft.Win32;

namespace hotManager
{
    class HookKey
    {
        public enum IdHook
        {
            WH_KEYBOARD=2,//一旦有键盘敲打消息（键盘的按下、键盘的弹起），在这个消息被放在应用程序的消息队列前，WINDOWS将会调用你的钩子函数。钩子函数可以改变和丢弃键盘敲打消息。
            WH_KEYBOARD_LL=13 ,
        }

        private int hookKeyResult;

        //Hook结构 
        [StructLayout(LayoutKind.Sequential)]
        public class KeyClass
        {
            public int vkCode;//表达一个在1到254间的虚拟键盘码
            public int scanCode;//表示硬件扫描码
            public int flags;
            public int time;
            public int dwExtraInfo;
        }


        //捕获键盘后，要执行方法的委托
        public delegate int HOOKPROC(int nCode, int wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int SetWindowsHookEx(IdHook idHook, HOOKPROC lpfn, IntPtr hInstance, int threadId);

        //取消钩子 
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);

        //调用下一个钩子 
        [DllImport("user32.dll")]
        public  static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);

        //获取当前线程ID 
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();

        //Gets the main module for the associated process. 
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string name);

        public bool InstallHookKey(HOOKPROC prc)
        {
            IntPtr intPtr=GetModuleHandle (System.Diagnostics.Process.GetCurrentProcess().MainModule .ModuleName );
            hookKeyResult = SetWindowsHookEx(IdHook.WH_KEYBOARD_LL, prc, intPtr, 0);
            if (hookKeyResult == 0)
                return false;
            return true;
        }

        public bool UnInstalHookKey()
        {
            bool bl = true;
            if (hookKeyResult != 0)
            {
                bl = UnhookWindowsHookEx(hookKeyResult);

                hookKeyResult = 0;
            }
            return UnhookWindowsHookEx(hookKeyResult);
        }
    }
}
