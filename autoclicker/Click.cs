using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Printing;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;


namespace autoclicker
{
    internal class Click
    {
        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;   
            public int Bottom;
        }

        private const uint WM_LBUTTONDOWN = 0x0201;
        private const uint WM_LBUTTONUP = 0x0202;

        /// <summary>
        /// summoms a click to the given program at the given spot
        /// _click_ 
        /// </summary>
        /// <param name="procid">process id for the pragram to be clicked</param>
        /// <param name="random">is the timing random or constant</param>
        /// <param name="center">does the click happen in the center of the screen</param>
        /// <param name="x">x coord of the click (only if not on the center)</param>
        /// <param name="y">y coord of the click (only if not on the center)</param>
        /// <param name="time">time between each click (only if not set to random)</param>
        /// <param name="timemin">minimum time between each click (only if set to random)</param>
        /// <param name="timemax">maximum time between each click (only if set to random)</param>
        public static void Clicks(int procid,
            bool center,
            int x = 0, int y = 0
            )
        {

            Process process = Process.GetProcessById(procid);
            IntPtr hWnd = process.MainWindowHandle;
            RECT rect;

            if (center)
            {
                if (GetWindowRect(hWnd, out rect))
                {
                    x = (rect.Right - rect.Left)/2;
                    y = (rect.Bottom - rect.Top)/2;
                    
                }
            }
            Debug.WriteLine(x +","+ y + "hi");
            int lParam = x | (y << 16);

            PostMessage(hWnd, WM_LBUTTONDOWN, 1, lParam);
            PostMessage(hWnd, WM_LBUTTONUP, 0, lParam);

            
        }
    }
}
