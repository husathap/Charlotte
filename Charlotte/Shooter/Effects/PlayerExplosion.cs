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
    public class PlayerExplosion : AnimatedSprite
    {
        public PlayerExplosion(Vector2 Position, float Scale) :
            base(PersistentContent.GetTexture("exp09"), 128, 128, 2)
        {
            this.Position = Position;
            this.Scale = Scale;
        }

    }
}
