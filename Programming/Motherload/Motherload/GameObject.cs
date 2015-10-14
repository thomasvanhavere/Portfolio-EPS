using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motherload
{
    public abstract class GameObject
    {
        public Point Position;
        protected Surface Afbeelding;
        protected Rectangle ToonDeelAfbeelding;
        protected Rectangle DirtcolRect;
        public abstract void Update();
        public virtual void Draw(Surface video)
        {
            video.Blit(Afbeelding, Position, ToonDeelAfbeelding);
          
        }

    }
}
