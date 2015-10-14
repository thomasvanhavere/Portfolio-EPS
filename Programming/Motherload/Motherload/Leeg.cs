using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motherload
{
    class Leeg : GameObject
    {
        public Leeg ()
        {
            
        }
        public Leeg (int x ,int y)
        {
            Sx = x;
            Sy = y;
            Position = new Point(sx, sy);
            rect = new Rectangle(sx, sy, 75, 75);
        }
        private Rectangle rect;
        public Rectangle Rect
        {
            get { return rect; }
            set { rect = value; }
        }
        private int Sx;
        private int Sy;
        public int sx
        {
            get { return Sx; }
            set { Sx = value; }
        }
        public int sy
        {
            get { return Sy; }
            set { Sy = value; }
        }
        public override void Update()
        {
            rect.X = Position.X;
            rect.Y = Position.Y;
        }
        public override void Draw(Surface video)
        {
            base.Draw(video);
        }
    }

}
