using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class BigBullet : EnemyProjectile
    {
        public override bool ToBeDeleted()
        {
            return this.X < -50 || this.X > Main.SCREEN_WIDTH + 50 || this.Y < -50 || this.Y > Main.SCREEN_HEIGHT + 50;
        }

        public override void Update(GameTime gt)
        {
            this.Position += this.Velocity;

            this.CollisionSpheres[0].Center += new Vector3(this.Velocity, 0);
        }

        Vector2 Velocity;

        public BigBullet(Level AssociatedLevel, Vector2 StartingPosition, Vector2 Velocity, float Power, Color Color)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 3;
            this.MaxHP = 3;
            this.Texture = PersistentContent.GetTexture("Bullet");
            this.Power = Power;
            this.Scale = 0.25f;
            this.Color = Color;
            this.Position = StartingPosition;
            this.Velocity = Velocity;
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 45)};
        }
    }
}
