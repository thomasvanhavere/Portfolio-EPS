using SdlDotNet.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Motherload
{
    class Jump
    {

        private DateTime Time;     
        private bool Jumping = true;
        public bool jumping
        {
            set { Jumping = value; }
        }
        private double addY;
        public double AddY
        {
            get { return addY; }
            set { addY = value; }
        }
        private Point Pos;
        public Jump(Point Position)
        {
            Pos = Position;
            Time = DateTime.Now;
        }
        public void Move()
        {
            if(Jumping)
            {
                TimeSpan vast = new TimeSpan(0, 0, 0, 0, 900);
                TimeSpan seconds = Time - DateTime.Now;
                TimeSpan jumptime = vast + seconds;
                if(jumptime.Milliseconds > 0)
                {
                    Jumping = false;
                }
                if(addY<14)
                addY = (double)9.8 * (Math.Pow(jumptime.TotalSeconds, 2));       
            }
            else if(Jumping ==false)
            {
                Time = DateTime.Now;
            }
           // Console.WriteLine("jump" + AddY);
          }

    }
}
