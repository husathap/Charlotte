using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class Punkfish3 : EnemyProjectile
    {
        int Counter = 0;

        public override bool ToBeDeleted()
        {
            return this.X < -100;
        }

        public override void Update(GameTime gt)
        {
            this.Position += this.Velocity;

            this.CollisionSpheres[0].Center += new Vector3(this.Velocity, 0);

            if (Counter >= 50)
            {
                Shoot(new HomingSmallBullet(this.AssociatedLevel, this.Position, 10));
                Counter = 0;
            }
            Counter++;
        }

        Vector2 Velocity;

        public Punkfish3(Level AssociatedLevel, Vector2 StartingPosition, Vector2 Velocity)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 8;
            this.MaxHP = 8;
            this.Texture = PersistentContent.GetTexture("Punkfish3");
            this.Power = 3;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = StartingPosition;
            this.Velocity = Velocity;
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 20)};
        }
    }
}
