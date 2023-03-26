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
        private static float ctime = new int();
        private static float ctimemin = new int();
        private static float ctimemax = new int();

        public static void Clickyloop(bool stop, int procid,
        bool random,
        float time = 0, float timemin = 0,
        float timemax = 0)
        {
            cstop = stop;
            cprocid = procid;
            crandom = random;
            ctime = time;
            ctimemin = timemin;
            ctimemax = timemax;

            Thread clickloop = new Thread(loop);
            clickloop.Start();

        }


        static void loop() { 
            Random rand = new Random();
            while (!cstop)
            { 
                if (crandom)
                {
                    float sample = (float)rand.NextDouble();
                    ctime = (sample * (ctimemax - ctimemin)) + ctimemin;
                }
                Click.Clicks(cprocid, ccenter, cx, cy);
                Thread.Sleep((int)ctime*1000);
            }
        }
    }
}
