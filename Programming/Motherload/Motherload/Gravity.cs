using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motherload
{
    class Gravity
    {
        private DateTime Time;
        private bool falling = true;
        public bool Falling
        {
            set { falling = value; }
        }
        private double addY;
        public double AddY
        {
            get { return addY; }
            set { addY = value; }
        }
        private Point pos;
        public Gravity(Point Position)
        {
            pos = Position;
            Time = DateTime.Now;
        }
      
        public void move()
        {
            if (falling)
            {
                TimeSpan seconds = Time - DateTime.Now;
               
                if(addY<25)
                addY = 2+(double)9.8 * (Math.Pow(seconds.TotalSeconds, 2));
                else
                { }

            }
            else if (falling == false)
                Time = DateTime.Now;

          //  Console.WriteLine("grav" + AddY);

        }
    }
}
