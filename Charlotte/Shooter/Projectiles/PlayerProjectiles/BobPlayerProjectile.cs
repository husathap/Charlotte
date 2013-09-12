using Charlotte.Content;
using Charlotte.Shooter.Projectiles.EnemyProjectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.PlayerProjectiles
{
    public class BobPlayerProjectile : PlayerProjectile
    {
        public static float SinPos = 0;

        public Vector2 Velocity = new Vector2(10, 0);

        public override bool ToBeDeleted()
        {
            if (this.X < -10)
                return true;
            if (this.X > Main.SCREEN_WIDTH + 10)
                return true;
            if (this.Y < -10)
                return true;
            if (this.Y > Main.SCREEN_HEIGHT + 10)
                return true;

            return false;
        }

        public override void Update(GameTime gt)
        {
            this.collisionSphere = new BoundingSphere(new Vector3(this.X, this.Y, 0), 10);
            this.Position += this.Velocity;
        }

        public BobPlayerProjectile(Vector2 InitialPosition)
        {
            this.Position = InitialPosition;
            this.HP = 2;
            this.MaxHP = 2;
            this.Texture = PersistentContent.GetTexture("BobPlayerBullet");
            this.Power = 3;

            Random r = new Random();
            this.Color = new Color(r.Next(255), r.Next(255), r.Next(255));

            this.collisionSphere = new BoundingSphere(new Vector3(this.X, this.Y, 0), 12);
        }

        public BobPlayerProjectile(Vector2 InitialPosition, Vector2 Velocity)
        {
            this.Position = InitialPosition;
            this.HP = 2;
            this.MaxHP = 2;
            this.Texture = PersistentContent.GetTexture("BobPlayerBullet");
            this.Power = 1;
            this.Velocity = Velocity;

            Random r = new Random();
            this.Color = new Color(r.Next(255), r.Next(255), r.Next(255));

            this.collisionSphere = new BoundingSphere(new Vector3(this.X, this.Y, 0), 12);
        }

        BoundingSphere collisionSphere { get; set; }

        public override bool CollidedWithEnemy(EnemyProjectile p)
        {
            if (p.CollisionSpheres != null)
            {
                foreach (BoundingSphere b in p.CollisionSpheres)
                {
                    if (b.Intersects(this.collisionSphere))
                    {
                        return true;
                    }
                }
            }

            if (p.CollisionBoxes != null)
            {
                foreach (BoundingBox b in p.CollisionBoxes)
                {
                    if (b.Intersects(this.collisionSphere))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
