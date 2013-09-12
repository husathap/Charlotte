using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class Anarfish : EnemyProjectile
    {
        int Counter = 0;
        Vector2 Velocity = new Vector2(0, 4);

        bool Initialized = false;

        public override bool ToBeDeleted()
        {
            return false;
        }

        public override void Update(GameTime gt)
        {
            if (!Initialized)
            {
                this.Y += 20;
                this.CollisionSpheres[0].Center.Y += 20;
                Initialized = this.Y >= Main.SCREEN_HEIGHT / 2;
            }
            else
            {
                this.Position += this.Velocity;


                if (this.Y <= 0 || this.Y >= Main.SCREEN_HEIGHT)
                {
                    this.Velocity *= -1;
                }

                if (Counter >= 20)
                {
                    Shoot(new HomingSmallBullet(this.AssociatedLevel, this.Position, 1));
                    Shoot(new SmallBullet(this.AssociatedLevel, this.Position, new Vector2(1, 0)));
                    Shoot(new SmallBullet(this.AssociatedLevel, this.Position, new Vector2(0, -1)));
                    Shoot(new SmallBullet(this.AssociatedLevel, this.Position, new Vector2(0, 1)));
                    Shoot(new SmallBullet(this.AssociatedLevel, this.Position, new Vector2(1, 1)));
                    Shoot(new SmallBullet(this.AssociatedLevel, this.Position, new Vector2(1, -1)));
                    Shoot(new SmallBullet(this.AssociatedLevel, this.Position, new Vector2(-1, 1)));
                    Shoot(new SmallBullet(this.AssociatedLevel, this.Position, new Vector2(-1, -1)));
                    Counter = 0;
                }
                Counter++;

                this.CollisionSpheres[0].Center = new Vector3(this.Position, 0);
            }
        }

        public Anarfish(Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 50;
            this.MaxHP = 50;
            this.Texture = PersistentContent.GetTexture("Anarfish");
            this.Power = 3;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = new Vector2(Main.SCREEN_WIDTH / 2, -50);
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 50)};
        }
    }
}
