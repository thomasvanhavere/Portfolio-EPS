using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motherload
{
    class RemoveDirt : GameObject
    {
        private Leeg saveLeeg;
        public RemoveDirt()
        {
            
        }
        public void Removedirt( Player speler,Level level)
        {
         Rectangle onder = new Rectangle(speler.Position.X+10, speler.Position.Y + 50, 45, 4);
         Rectangle left = new Rectangle(speler.Position.X, speler.Position.Y + 10, 4, 35);
         if (speler.down == true && onder.IntersectsWith(level.SaveColDirt.Rect))
            {
             if(level.SaveColDirt.ID!=5)
             {
                 level.dirtobject.Remove(level.SaveColDirt);
                 saveLeeg = copyEigenschappen(level.SaveColDirt);
                 level.leegObject.Add(saveLeeg);
                 speler.MaxY = 600;
                 speler.MaxX = 750;
                 speler.MinX = 0;
                 score += level.SaveColDirt.ID * 10;
                 foreach (Dirt g in level.dirtobject)
                 {
                     g.Update();
                 }
                 foreach(Leeg L in level.leegObject)
                 {
                     L.Update();
                 }
                 level.SaveColDirt = new Dirt();
             }
               
            }
            
        }
        private Leeg copyEigenschappen(Dirt D)
        {
            saveLeeg=new Leeg();
            saveLeeg.Rect = D.Rect;
            saveLeeg.sx = D.sx;
            saveLeeg.sy = D.sy;
            return saveLeeg;
        }
       private int score;
       public int Score
       {
        get {return score;}
       }
       public override void Update()
        {
            throw new NotImplementedException();
        }
       public override void Draw(Surface video)
        {
            base.Draw(video);
        }

   
    }
}
