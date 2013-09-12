using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class SmallBullet : EnemyProjectile
    {
        public override bool ToBeDeleted()
        {
            return this.X < -25 || this.X > Main.SCREEN_WIDTH + 25 || this.Y < -25 || this.Y > Main.SCREEN_HEIGHT + 25;
        }

        public override void Update(GameTime gt)
        {
            this.Position += this.Velocity;

            this.CollisionSpheres[0].Center += new Vector3(this.Velocity, 0);
        }

        Vector2 Velocity;

        public SmallBullet(Level AssociatedLevel, Vector2 StartingPosition, Vector2 Velocity)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 1;
            this.MaxHP = 1;
            this.Texture = PersistentContent.GetTexture("SmallBullet");
            this.Power = 1;
            this.Scale = 0.5f;
            this.Color = Color.White;
            this.Position = StartingPosition;
            this.Velocity = Velocity;
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 12)};
        }
    }
}
