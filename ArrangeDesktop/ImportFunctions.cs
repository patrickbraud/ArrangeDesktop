﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArrangeDesktop
{
    class ImportFunctions
    {
        /// <summary>
        /// Change a windows size and position
        /// </summary>
        /// <param name="hWnd">Handle of window to move</param>
        /// <param name="X">New X position</param>
        /// <param name="Y">New Y position</param>
        /// <param name="nWidth">New width</param>
        /// <param name="nHeight">New height</param>
        /// <param name="bRepaint">Bool to be repainted</param>
        /// <returns>if successful?</returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        /// <summary>
        /// Gets rectangle representing the window
        /// </summary>
        /// <param name="hwnd">Handle of window to target</param>
        /// <param name="rectangle">rectangle that will represent the window</param>
        /// <returns>true if successful</returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        // ----------------- TEST FUNCTIONS ----------------

        public delegate bool WindowEnumCallback(int hwnd, int lparam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumWindows(WindowEnumCallback lpEnumFunc, int lParam);

        [DllImport("user32.dll")]
        public static extern void GetWindowText(int h, StringBuilder s, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(int h);

        public static List<string> Windows = new List<string>();
        public static bool AddWnd(int hwnd, int lparam)
        {
            if (IsWindowVisible(hwnd))
            {
                StringBuilder sb = new StringBuilder(255);
                GetWindowText(hwnd, sb, sb.Capacity);
                if (sb.Length > 0)
                {
                    Windows.Add(sb.ToString());
                }
            }
            return true;
        }

        public static List<string> GetWindows()
        {
            EnumWindows(new WindowEnumCallback(AddWnd), 0);
            return Windows;
        }
    }
}
