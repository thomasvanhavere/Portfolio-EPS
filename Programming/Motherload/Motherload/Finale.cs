using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motherload
{
    class Finale : GameObject
    {
       public Finale()
        {

        }
        public Finale(int x,int y ,int ID)
       {
           id = ID;
           if (ID == 7)
           {
               Afbeelding = new Surface("Final.png");
              
           }           
           else if (ID == 8)
           {
               Afbeelding = new Surface("finish.png");
               
           }
           Position = new Point(x, y);
           ToonDeelAfbeelding = new Rectangle(0, 0, 75, 75);
           rect = new Rectangle(x, y, 75, 75);
       }
        private int id;
        public int iD
        {
            get { return id; }
        }
        public override void Draw(Surface video)
        {
            base.Draw(video);
        }
        private Rectangle rect;
        public Rectangle Rect
        {
            get { return rect; }
        }
        public override void Update()
        {
            rect.X = Position.X;
            rect.Y = Position.Y;
        }
    }
}
