using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motherload
{
    class Diamant : GameObject
    {
        private Rectangle rect;
        public Rectangle Rect
        {
            get { return rect; }
        }
        public Diamant()
        {

        }
        public Diamant(int x , int y)
        {
            Afbeelding = new Surface("diamant.png");
            Position = new Point(x, y);
            ToonDeelAfbeelding = new Rectangle(0, 0, 28, 22);
            rect = new Rectangle(x, y, 28, 22);
        }
        public override void Draw(Surface video)
        {
            base.Draw(video);
        }
        public override void Update()
        {
            rect.X = Position.X;
            rect.Y = Position.Y;
        }
    }
}
