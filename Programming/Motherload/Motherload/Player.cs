using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motherload
{
    class Player : GameObject
    {
         public bool left, right,down;
         public bool up ;
         private bool space;
         private Point start = new Point(0, 80);
         public Size end = new Size(70, 50);
         private string Side = "Right";
         private int maxY = 530;
         private int maxX = 700;
         private int minY = 0;
         private int minX =0;
         private int speed = 5;
         private bool collision = false;
         private Gravity gravety = new Gravity(new Point(300,100));
         private Jump Sprong = new Jump(new Point(300, 100));
         private bool flyable = false;
         public bool FlayAble
         {
             set { flyable = value; }
         }
        public bool Collision
        {
            get { return collision; }
            set { collision = value; }
        }
        private int levens = 5;
        public int Levens
        {
            get { return levens; }
            set { levens = value; }
        }
        private int graf;
        public int Gravety
        {
            set { graf = value; }
            get { return graf; }
        }
        public int MaxY
        {
            get
            {
                return maxY;
            }
            set
            {
                maxY = value;
            }
        }
        public int MinY
        {
            get
            {
                return minY;
            }
            set
            {
                minY = value;
            }
        }
        public int MinX
        {
            get
            {
                return minX;
            }
            set
            {
                minX = value;
            }
        }
        public int MaxX
        {
            get
            {
                return maxX;
            }
            set
            {
                maxX = value;
            }
        }
        public Player()
        {
            Afbeelding = new Surface("Allevormen.png");
            Position = new Point(75, 325);
            ToonDeelAfbeelding = new Rectangle(start, end);
            gravety.AddY = 0;
            gravety.Falling = false;
            Events.KeyboardDown += Events_KeyboardDown;
            Events.KeyboardUp += Events_KeyboardUp;
        }
        void Events_KeyboardUp(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            if (e.Key == SdlDotNet.Input.Key.LeftArrow)
            {
                left = false;
            }
            if (e.Key == SdlDotNet.Input.Key.RightArrow)
            { 
                right = false;            
            }  
            if(e.Key==SdlDotNet.Input.Key.UpArrow)
            {
                up = false;
                gravety = new Gravity(Position);
            }
            if(e.Key==SdlDotNet.Input.Key.DownArrow)
            {
                down = false;
            }
            if(e.Key==SdlDotNet.Input.Key.Space)
            {
                space = false;
            }
        }
        void Events_KeyboardDown(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            if (e.Key == SdlDotNet.Input.Key.LeftArrow)
                left = true;

            if (e.Key == SdlDotNet.Input.Key.RightArrow)
            {
                right = true; 
            }
            if (e.Key == SdlDotNet.Input.Key.UpArrow)
            {
                up = true;
                down = false;
            }
            if (e.Key == SdlDotNet.Input.Key.DownArrow)
            {
                down = true;
            }
            if (e.Key == SdlDotNet.Input.Key.Space)
            {
                Sprong = new Jump(Position);
             
                space = true;
            }
         }
        public override void Update()
        { 
            if (left)
            {
                if(MinX != 0)
                {

                }
                else
                 Position.X -= speed;
            }
            if (right)
            {
                if(MaxX !=750)
                {

                }
                else
                    Position.X += speed;
            }
            if (up && flyable)
            {
                if (Position.Y != MinY)
                    Position.Y -= speed;
            }
            if (down)
            {
                if(Position.Y<MaxY)
                    Position.Y += speed;
            }
            if ( flyable ==false || up == false)
            {
                if (collision == false)
                {
                    gravety.Falling = true;
                    Position.Y += (int)gravety.AddY;
                    graf = (int)gravety.AddY;
                }

                else if (collision == true)
                {
                    gravety.AddY = 0;
                    gravety.Falling = false;
                }
             }

                if (space)
                {
                  Position.Y -= (int)Sprong.AddY;
                  Sprong.Move();
                  }
                
            gravety.move();
        }   
        public Rectangle getDeelAfbeeling(Point start)
        {
            end = new Size(70, 60);
            ToonDeelAfbeelding = new Rectangle(start, end);
            return ToonDeelAfbeelding;
        }   
        public override void Draw(Surface video)
            {
              movement(video);
        	 base.Draw(video);
             
            
            }
        private Point pointControl()
       {
           Point punt;
           if (Position.Y> MaxY)
           {
               punt = new Point(Position.X , MaxY);
               return punt;
           }
            if(Position.Y < MinY)
           {
               punt = new Point(Position.X, MinY);
               return punt;
           }
            if (Position.X >MaxX)
           {
               punt = new Point(MaxX, Position.Y);
               return punt;
           }
            if (Position.X < MinX)
            {
                punt = new Point(MinX, Position.Y);
                return punt;
            }
            else
                return Position;     
       }
        void movement(Surface video)
            {
                Position = pointControl();

                if (up == true && right == true)
                {
                    Side = "Right";
                    start = new Point(10, 10);
                    video.Blit(Afbeelding, Position, getDeelAfbeeling(start));
                }
                else if (up && left)
                {
                    Side = "Left";
                    start = new Point(80, 10);
                    video.Blit(Afbeelding, Position, getDeelAfbeeling(start));
                }
                else if (down && left)
                {
                    Side = "Left";
                    start = new Point(111, 144);
                    video.Blit(Afbeelding, Position, getDeelAfbeeling(start));
                }
                else if (down && right)
                {
                    Side = "Right";
                    start = new Point(10, 144);
                    video.Blit(Afbeelding, Position, getDeelAfbeeling(start));
                }
                else
                {
                    if (up)
                    {
                        start = new Point(10, 10);
                        video.Blit(Afbeelding, Position, getDeelAfbeeling(start));
                    }
                     if (down)
                    {
                        start = new Point(10, 144);
                        video.Blit(Afbeelding, Position, getDeelAfbeeling(start));
                    }
                     if (left)
                    {
                        Side = "Left";
                        start = new Point(90, 80);
                        video.Blit(Afbeelding, Position, getDeelAfbeeling(start));
                    }
                     if (right)
                    {
                        Side = "Right";
                        start = new Point(0, 80);
                        video.Blit(Afbeelding, Position, getDeelAfbeeling(start));
                    }
                }
                if (up == false && down == false && left == false && right == false)
                {
                    if (Side == "Right")
                    {
                        start = new Point(0, 80);
                    }
                    else if (Side == "Left")
                    {
                        start = new Point(90, 80);
                    }
                    video.Blit(Afbeelding, Position, getDeelAfbeeling(start));
                    
                 }
            }
        }
    }

