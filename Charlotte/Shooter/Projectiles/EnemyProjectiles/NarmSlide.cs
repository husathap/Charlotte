using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class NarmSlide : EnemyProjectile
    {
        public override bool ToBeDeleted()
        {
            return this.X < -300;
        }

        public override void Update(GameTime gt)
        {
             this.X -= 1;

            this.CollisionBoxes = new BoundingBox[] { new BoundingBox(new Vector3(X - 300, 0, 0),
                new Vector3(X + 300, 600, 0))};
        }

        public NarmSlide(Level AssociatedLevel, int Index, int X)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 100;
            this.MaxHP = 100;
            this.Texture = PersistentContent.GetTexture("txt" + Index.ToString());
            this.Power = 10;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = new Vector2(X, 300);
            this.CollisionBoxes = new BoundingBox[] { new BoundingBox(new Vector3(X - 300, 0, 0),
                new Vector3(X + 300, 600, 0))};
        }
    }
}
