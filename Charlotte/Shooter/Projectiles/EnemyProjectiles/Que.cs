using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class Que : EnemyProjectile
    {
        Random rand = new Random();

        public override bool ToBeDeleted()
        {
            return this.X < -25;
        }

        public override void Update(GameTime gt)
        {
            this.X -= 5;

            if (rand.NextDouble() < 0.5f)
            {
                this.Y += (float)(rand.NextDouble() * 10f);
            }
            else
            {
                this.Y -= (float)(rand.NextDouble() * 10f);
            }

            this.CollisionSpheres[0].Center = new Vector3(this.Position, 0);
        }

        public Que(Level AssociatedLevel, Vector2 StartingPosition)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 10;
            this.MaxHP = 10;
            this.Texture = PersistentContent.GetTexture("Que");
            this.Power = 3;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = StartingPosition;
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 30)};
        }
    }
}
