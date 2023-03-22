using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace autoclicker
{
    internal class Windows
    {
        static Process[] processlist = Process.GetProcesses();
        public static List<String> Titles(){

            List<String> Return = new List<String>();

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
    }
}
