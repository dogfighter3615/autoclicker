using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace autoclicker
{
    internal class Windows
    {
        static Process[] processlist = Process.GetProcesses();
        public static List<String> Titles(){

            List<String> Return = new List<String>();
            processlist = Process.GetProcesses();

            foreach (Process process in processlist){
                if (process.MainWindowTitle != "")
                {
                    Return.Add(process.MainWindowTitle);
                }
             }

            return Return;
        }

        public static List<int> procids()
        {
            List<int> Return = new List<int>();

            foreach (Process process in processlist)
            {
                if (process.MainWindowTitle != "")
                {
                    Return.Add(process.Id);
                }
            }

            return Return;
        }

        public static Process Processbyname(String procname)
        {
            Process Return = new Process();
            foreach (Process process in processlist)
            {
                if (process.MainWindowTitle == procname)
                {
                    Return = process;
                }
            }
            return Return;
        }

        public static Process FindMinecraft()
        {
            Process Return = new Process();
            int minecraftcount = 0;
            List<Process> minecraftlist = new List<Process>();
            MainWindow mainWindow = new MainWindow();

            Debug.WriteLine("searching minecraft windows");

            foreach (Process process in processlist)
            {
                if ((bool)process.MainWindowTitle.ToLower().Contains("minecraft") &&
                    !(bool)process.MainWindowTitle.ToLower().Contains("launcher"))
                {

                    minecraftcount++;
                    minecraftlist.Add(process);

                }
            }
            if (minecraftcount == 1)
            {
                Return = minecraftlist[0];
            }
            else if (minecraftcount > 1)
            {
                mainWindow.logbox.Items.Add(
                    "more than one window detected, please select your window");

                WindowSelector windowSelector = new WindowSelector();
                windowSelector.Show();

            }
            else
            {
                mainWindow.logbox.Items.Add(
                    "no minecraft windows detected, please select a window");
                Debug.WriteLine("hi"); 
            }
            return Return;
        }
    }
}
