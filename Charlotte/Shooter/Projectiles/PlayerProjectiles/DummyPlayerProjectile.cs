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
    public class DummyPlayerProjectile : PlayerProjectile
    {
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
            this.X += 10;
        }

        public DummyPlayerProjectile(Vector2 InitialPosition)
        {
            this.Position = InitialPosition;
            this.HP = 2;
            this.MaxHP = 2;
            this.Texture = PersistentContent.GetTexture("Blank");
            this.Power = 3;
            this.Scale = 20;
            this.Color = Color.Green;
            this.collisionSphere = new BoundingSphere(new Vector3(this.X, this.Y, 0), 10);
        }

        Vector2 origin = new Vector2(0.5f, 0.5f);

        public override Vector2 Origin
        {
            get { return origin; }
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

            return false;
        }
    }
}
