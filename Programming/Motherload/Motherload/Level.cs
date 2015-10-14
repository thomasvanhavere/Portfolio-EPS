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
    class Level 
    {
        public int[,] inttileArray = new int[25,100];
        public List<Dirt> dirtobject;
        public List<Leeg> leegObject;
        public List<Diamant> DiamantObj;
        public List<Finale> Finish;
        private int tellerX,tellerY;
        public Dirt SaveColDirt = new Dirt();
        private Point pos = new Point(0,0);
        private Rectangle rect;
        private Size groote = new Size(750, 375);
         Surface  bg = new Surface("bg.png");
        
        public Level()
        {
            dirtobject = new List<Dirt>();
            leegObject = new List<Leeg>();
            DiamantObj = new List<Diamant>();
            Finish = new List<Finale>();
            CreateWorld();
        }
        public void CreateWorld()
        {
            dirtobject = new List<Dirt>();
            leegObject = new List<Leeg>();
            DiamantObj = new List<Diamant>();
            Finish = new List<Finale>();
            for (int x = 0; x < 23; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    if (inttileArray[x, y] >= 1 && inttileArray[x, y] < 6)
                    {
                        Dirt g = new Dirt(((x) * 75) , ((y) * 75), inttileArray[x, y]);
                        dirtobject.Add(g);
                    }
                    else if (inttileArray[x, y] == 0 )
                    {
                        Leeg L = new Leeg(((x) * 75) , ((y)* 75) );
                        leegObject.Add(L);
                    }
                    else if (inttileArray[x, y] == 6)
                    {
                        Leeg L = new Leeg(((x) * 75), ((y) * 75));
                        leegObject.Add(L);

                        Diamant D = new Diamant((x * 75)+20, (y * 75)+30);
                        DiamantObj.Add(D);
                    }
                    else if(inttileArray[x, y] == 7 || inttileArray[x, y] == 8)
                    {
                        Finale F = new Finale(x*75, y*75, inttileArray[x, y]);
                        Finish.Add(F);
                    }
                }            
            }
        }
        public void Draw(Surface video)
        {
            pos = new Point((-tellerX), -tellerY);
            rect = new Rectangle(pos, groote);
            video.Blit(bg, new Point(0,0), rect);           
            foreach (Dirt g in dirtobject)
            {
                g.Draw(video);
            }
            foreach (Diamant D in DiamantObj)
            {
                D.Draw(video);
            }
            foreach (Finale f in Finish)
            {
                f.Draw(video);
            }
        }
        public void MoveLevel (Player speler)
        {
                if (speler.Position.X > 500  && speler.right == true && tellerX >-960) //rechts
                {
                    schuifWereldXMax(speler);
                }
                if (speler.Position.X < 100 &&speler.left == true && tellerX <0)   ///links
                {
                    schuifWereldXMin(speler);
                }
                if (speler.Position.Y > 250 ) //dalen
                {
                    schuifWereldYMax(speler);
                }
                if (speler.Position.Y < 150 && tellerY<0 )   //stijgen
                {
                    schuifWereldYMin(speler);
                }      
        }
        private void schuifWereldYMax(Player speler) // dalen
        {
          foreach(Dirt g in dirtobject)
          {
              g.Position.Y -=speler.Gravety;
              g.sy -= speler.Gravety;
          }
            speler.Position.Y-=speler.Gravety;
                    
            foreach(Leeg L in leegObject)
            {
                L.Position.Y -= speler.Gravety;
                L.sy -= speler.Gravety;
            }
            foreach(Diamant D in DiamantObj)
            {
                D.Position.Y -= speler.Gravety;
            }
            foreach (Finale f in Finish)
            {
                f.Position.Y -= speler.Gravety;
            }
            tellerY -= speler.Gravety;
        }
        private void schuifWereldXMax(Player speler)
        {
            foreach(Dirt g in dirtobject)
            {
                g.Position.X -= 5;
                g.sx -= 5;
            }
            speler.Position.X -= 5;
         
            foreach(Leeg L in leegObject)
            {
                L.Position.X -= 5;
                L.sx -= 5;
                
            }
            foreach (Diamant D in DiamantObj)
            {
                D.Position.X -= 5;
            }
            foreach (Finale f in Finish)
            {
                f.Position.X -= 5;
            }
            tellerX -= 5;
        
        }
        private void schuifWereldYMin(Player speler) // stijgen
        {
            foreach (Dirt g in dirtobject)
            {
                g.Position.Y += 5;
                g.sy += 5;
            }
           
            speler.Position.Y += 5;
            foreach (Leeg L in leegObject)
            {
                L.Position.Y += 5;
                L.sy += 5;
            }
            foreach (Diamant D in DiamantObj)
            {
                D.Position.Y += 5;
            }
            foreach (Finale f in Finish)
            {
                f.Position.Y += 5;
            }
            tellerY += 5;
           
        }
        private void schuifWereldXMin(Player speler)
        {
            foreach (Dirt g in dirtobject)
            {
                g.Position.X += 5;
                g.sx += 5;

            }
            speler.Position.X += 5;

           
            foreach (Leeg L in leegObject)
            {
                L.Position.X += 5;
                L.sx += 5;
            }
            foreach (Diamant D in DiamantObj)
            {
                D.Position.X += 5;
            }
            foreach (Finale f in Finish)
            {
                f.Position.X += 5;
            }
            tellerX+=5;
        }
    }
}
