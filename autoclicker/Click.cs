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
        public static extern IntPtr PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);


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
            IntPtr minecraftHandle = process.MainWindowHandle;
            Debug.WriteLine("_click_");

            PostMessage(minecraftHandle, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            PostMessage(minecraftHandle, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
        } 
    }
}
