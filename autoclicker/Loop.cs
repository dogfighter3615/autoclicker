using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace autoclicker
{
    internal class Loop
    {
        public static bool cstop = new bool();
        private static int cprocid = new int();
        private static bool crandom = new bool();
        private static bool ccenter = new bool();
        private static int cx = new int();
        private static int cy = new int();
        private static int ctime = new int();
        private static int ctimemin = new int();
        private static int ctimemax = new int();

        public static void Clickyloop(bool stop, int procid,
        bool random, bool center,
        int x = 0, int y = 0,
        int time = 0, int timemin = 0,
        int timemax = 0)
        {
            cstop = stop;
            cprocid = procid;
            crandom = random;
            ccenter = center;
            cx = x;
            cy = y;
            ctime = time;
            ctimemin = timemin;
            ctimemax = timemax;

            Thread clickloop = new Thread(loop);
            clickloop.Start();

        }


        static void loop() { 
            while (!cstop)
            {
                Click.Clicks(cprocid, ccenter, cx, cy);
                System.Threading.Thread.Sleep(ctime*100);
            }
        }
    }
}
