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
    public class HomingBobPlayerProjectile : PlayerProjectile
    {
        static Random rand = new Random();

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

        Vector2 Velocity = Vector2.Zero;

        public override void Update(GameTime gt)
        {
            this.collisionSphere = new BoundingSphere(new Vector3(this.X, this.Y, 0), 10);

            Vector2 NearestEnemy = Vector2.Zero;

            if (AssociatedLevel.Waves != null && AssociatedLevel.Waves[AssociatedLevel.CurrentWaveNo] != null)
            {
                if (AssociatedLevel.Waves[AssociatedLevel.CurrentWaveNo].Count > 0)
                {
                    foreach (EnemyProjectile e in AssociatedLevel.Waves[AssociatedLevel.CurrentWaveNo])
                    {
                        if (NearestEnemy == Vector2.Zero)
                        {
                            NearestEnemy = e.Position - this.Position;
                        }
                        else
                        {
                            if ((e.Position - this.Position).Length() < NearestEnemy.Length())
                            {
                                NearestEnemy = e.Position - this.Position;
                            }
                        }
                    }

                    Velocity = NearestEnemy / NearestEnemy.Length() * 10;
                }
            }

            this.Position += Velocity;

        }

        public HomingBobPlayerProjectile(Level AssociatedLevel, Vector2 InitialPosition)
        {
            this.AssociatedLevel = AssociatedLevel;
            this.Position = InitialPosition;
            this.HP = 3;
            this.MaxHP = 3;
            this.Texture = PersistentContent.GetTexture("BobPlayerBullet");
            this.Power = 1;
            this.Scale = 1;

            this.Color = new Color(rand.Next(255), rand.Next(255), rand.Next(255));
            this.collisionSphere = new BoundingSphere(new Vector3(this.X, this.Y, 0), 10);
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
