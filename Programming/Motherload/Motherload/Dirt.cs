using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motherload
{
    class Dirt :GameObject
    {
      
        public Dirt()
        {

            
        }
        public Dirt(int x, int y, int Id) 
        {
            Sx = x;
            Sy = y;
            ID = Id;
            Afbeelding = new Surface("AllDirt.png");
            Position = new Point(Sx, Sy);
            if(ID == 1)//dirt
                 ToonDeelAfbeelding = new Rectangle(0, 0, 75, 75);
            else if(ID==2)//gold
                ToonDeelAfbeelding = new Rectangle(75, 0, 75, 75);
            else if(ID==3)//coper
                ToonDeelAfbeelding = new Rectangle(150, 0, 75, 75);
            else if(ID == 4)//metalerts
                ToonDeelAfbeelding = new Rectangle(225, 0, 75, 75);
            else if(ID == 5)//steen
                ToonDeelAfbeelding = new Rectangle(300, 0, 75, 75);

            else//onbekent maak grond
                ToonDeelAfbeelding = new Rectangle(0, 0, 75, 75);
           
            rect = new Rectangle(Sx, Sy, 75, 75);
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

        private Rectangle rect;
        public Rectangle Rect
        {
            get { return rect; }
        }
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
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
