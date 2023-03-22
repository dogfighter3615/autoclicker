using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoclicker
{
    internal class click
    {
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
        public void Click(int procid,
            bool random, bool center,
            int x = 0, int y = 0,
            int time = 0, int timemin = 0, 
            int timemax = 0)
        {
            ;
        }
    }
}
