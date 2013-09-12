using Charlotte.Content;
using Charlotte.Sprite;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Effects
{
    public class Explosion : AnimatedSprite
    {
        public Explosion(Vector2 Position, float Scale) :
            base(PersistentContent.GetTexture("Explosion"), 128, 128, 2)
        {
            this.Position = Position;
            this.Scale = Scale;
        }

    }
}
