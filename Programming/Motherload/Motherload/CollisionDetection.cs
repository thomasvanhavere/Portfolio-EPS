using SdlDotNet.Audio;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Motherload
{
    class CollisionDetection
    {
        Audio muziek = new Audio();
        Rectangle[] multrec = new Rectangle[4];
        Box[] multdrawrec = new Box[4];
        Point tempPoint = new Point();
        Diamant SaveD = new Diamant();
            
        private int ELeven;
        private bool extraleven;
        public bool ExtraLeven
        {
            get { return extraleven; }
            set { extraleven = value; }
        }
        private int score=0;
        public int Score
        {
            get { return score; }
            set { score = value; }
          
        }
        private bool gameEnd = false;
        public bool GameEnd
        {
            get { return gameEnd; }
            set { gameEnd = value; }
        }
        private void CheckDirtCol(Rectangle[] multrec , Level level , Player speler)
        {
          
            foreach (Dirt g in level.dirtobject)
            {
                
                if (CheckRectangleCollision(multrec[3], g.Rect) == true) //colision op onderste col rect met collision rect van elementen dirt
                {
                   

                    level.SaveColDirt = g;
                    tempPoint = g.Position;
                    speler.MaxY = speler.Position.Y;
                    if (speler.Gravety > 12 && speler.Gravety < 17)
                    {

                        muziek.PlayMetalClash(60);
                        speler.Levens -= 1;
                        speler.Gravety = 0;
                    }
                    else if (speler.Gravety > 17 && speler.Gravety < 21)
                    {
                        muziek.PlayMetalClash(80);

                        speler.Levens -= 2;
                        speler.Gravety = 0;
                    }
                    else if (speler.Gravety > 21)
                    {
                       muziek.PlayMetalClash(100);
                        speler.Levens -= 3;
                        speler.Gravety = 0;
                    }
                    speler.Collision = true;
                }
                if (CheckRectangleCollision(multrec[0], g.Rect) == true)//col voor boven rect
                {
                    level.SaveColDirt = g;
                    speler.MinY = speler.Position.Y;
                }
                if (CheckRectangleCollision(multrec[2], g.Rect) == true)//col voor rechtse rect
                {

                    level.SaveColDirt = g;
                    speler.MaxX = speler.Position.X;

                }
                if (CheckRectangleCollision(multrec[1], g.Rect) == true)// col voor linkse rect
                {
                    level.SaveColDirt = g;
                    speler.MinX = speler.Position.X;
                }
            }
           
        }
        private void CheckVoidCol(Rectangle[] multrec, Level level, Player speler)
        {
            foreach (Leeg L in level.leegObject)
            {

                if ((CheckRectangleCollision(multrec[3], L.Rect) == true) && (CheckRectangleCollision(multrec[3], level.SaveColDirt.Rect) == false))
                {
                    speler.MaxY = 600;
                    speler.Collision = false;

                }
                if (CheckRectangleCollision(multrec[0], L.Rect) == true && CheckRectangleCollision(multrec[0], level.SaveColDirt.Rect) == false)
                {
                    speler.MinY = 0;

                }
                if (CheckRectangleCollision(multrec[2], L.Rect) == true && CheckRectangleCollision(multrec[2], level.SaveColDirt.Rect) == false)
                {
                    speler.MaxX = 750;

                }
                if (CheckRectangleCollision(multrec[1], L.Rect) == true && CheckRectangleCollision(multrec[1], level.SaveColDirt.Rect) == false)
                {
                    speler.MinX = 0;
                }
            }
        }
        private void CheckDiamondCol(Rectangle[] multrec, Level level, Player speler)
        {
            foreach (Diamant D in level.DiamantObj)
            {
                if (CheckRectangleCollision(multrec[3], D.Rect) == true || CheckRectangleCollision(multrec[0], D.Rect) == true ||CheckRectangleCollision(multrec[2], D.Rect) == true||CheckRectangleCollision(multrec[1], D.Rect) == true) //colision op onderste col rect met collision rect van elementen dirt
                {
                    SaveD = D;
                    score++;
                    ELeven++;
                    if(ELeven ==10)
                    {
                        extraleven = true;
                        ELeven = 0;
                    }
                    

                }
               
            }
            level.DiamantObj.Remove(SaveD);
            SaveD = new Diamant();
        }
        private void CheckEnd(Rectangle[] multrec, Level level, Player speler)
        {
            foreach (Finale f in level.Finish)
            {
                if ((CheckRectangleCollision(multrec[3], f.Rect) == true) || (CheckRectangleCollision(multrec[1], f.Rect) == true) || (CheckRectangleCollision(multrec[2], f.Rect) == true))
                {
                    speler.MaxY = speler.Position.Y;
                    if(f.iD ==8)
                    gameEnd = true;
                   
                }
            }
        }
        public void Collisiondetection(Player speler, Level level)
        {

            multrec[0] = new Rectangle(speler.Position.X + 10, speler.Position.Y, 45, 4);
            multrec[1] = new Rectangle(speler.Position.X, speler.Position.Y + 10, 4, 35);
            multrec[2] = new Rectangle(speler.Position.X + 60, speler.Position.Y + 10, 4, 30);
            multrec[3] = new Rectangle(speler.Position.X + 10, speler.Position.Y + 50, 45, 4);

            CheckDirtCol(multrec, level, speler);

          if(speler.Position.Y> tempPoint.Y-50 && speler.Collision == true)
          {
              speler.MaxY = (tempPoint.Y - 50);    
          }
          CheckVoidCol(multrec, level, speler);
          CheckDiamondCol(multrec, level, speler);
          CheckEnd(multrec, level, speler);    
       }
        private bool CheckRectangleCollision(Rectangle rect,Rectangle rect2)
       {
           if (rect.IntersectsWith(rect2))
           {
               return true;
           }
           else
               return false;
       }
        
    }
}
