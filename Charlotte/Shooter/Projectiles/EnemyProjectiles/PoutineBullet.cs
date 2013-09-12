using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class PoutineBullet : EnemyProjectile
    {
        public override bool ToBeDeleted()
        {
            return this.X < -7.5f || this.X > Main.SCREEN_WIDTH + 7.5f || this.Y < -7.5f || this.Y > Main.SCREEN_HEIGHT + 7.5f;
        }

        public override void Update(GameTime gt)
        {
            this.Position += this.Velocity;

            this.CollisionSpheres[0].Center += new Vector3(this.Velocity, 0);

            if (this.AssociatedLevel.Player.HP / this.AssociatedLevel.Player.MaxHP < 0.05f)
            {
                this.HP = 0;
            }
        }

        Vector2 Velocity;

        public PoutineBullet(Level AssociatedLevel, Vector2 StartingPosition, Vector2 Velocity)
        {
            this.AssociatedLevel = AssociatedLevel;

            Random r = new Random();

            this.HP = 1;
            this.MaxHP = 1;
            this.Texture = PersistentContent.GetTexture("PoutineBullet");
            this.Power = 1;
            this.Scale = 1;
            this.Color = new Color(255, r.Next(255), r.Next(255));
            this.Position = StartingPosition;
            this.Velocity = Velocity;
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 7.5f)};
        }
    }
}
