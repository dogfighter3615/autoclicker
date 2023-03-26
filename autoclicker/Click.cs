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

        private const uint WM_LBUTTONDOWN = 0x0201;
        private const uint WM_LBUTTONUP = 0x0202;

        /// <summary>
        /// summoms a click to the given program at the given spot
        /// _click_ 
        /// </summary>
        /// <param name="procid">process id for the pragram to be clicked</param>
        public static void Clicks(int procid)
        {
            Process process = Process.GetProcessById(procid);
            IntPtr minecraftHandle = process.MainWindowHandle;
            Debug.WriteLine("_click_");

            PostMessage(minecraftHandle, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            PostMessage(minecraftHandle, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
        } 
    }
}
