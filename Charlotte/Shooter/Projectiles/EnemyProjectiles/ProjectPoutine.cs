using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class ProjectPoutine : EnemyProjectile
    {
        float Counter = 0;
        int Counter2 = 0;
        int Counter3 = 600;
        int Counter4 = 0;

        Random r = new Random();

        public override bool ToBeDeleted()
        {
            return false;
        }

        public override void Update(GameTime gt)
        {
            this.Y = 200 + (float)Math.Sin(Counter) * 100;
            Counter += 0.01f;

            if (this.HP / this.MaxHP > 0.05f)
            {
                Vector2 Drag = (this.Position - this.AssociatedLevel.Player.Position) /
                    (this.Position - this.AssociatedLevel.Player.Position).Length() * 4f;
                this.AssociatedLevel.Player.Position += Drag;

                if (Counter2 >= 1500)
                {
                    Shoot(new FocusedAssailant(this.AssociatedLevel, new Vector2(500, r.Next(100, 500))));
                    Shoot(new FocusedAssailant(this.AssociatedLevel, new Vector2(500, r.Next(100, 500))));
                    Counter2 = 0;
                }
                Counter2++;

                if (Counter3 >= 600)
                {
                    Shoot(new Sweeper(this.AssociatedLevel));
                    Counter3 = 0;
                }
                Counter3++;

                if (Counter4 >= 50)
                {
                    for (float i = 0; i < MathHelper.TwoPi; i += MathHelper.TwoPi / 10)
                    {
                        Shoot(new PoutineBullet(this.AssociatedLevel, this.Position,
                            new Vector2((float)(Math.Sin(i) * 3), (float)(Math.Cos(i) * 3))));
                    }
                    Counter4 = 0;
                }
                Counter4++;
            }
            else
            {
                Shoot(new HomingSquareLaser(this.AssociatedLevel, this.Position + new Vector2(-25, -25), 5, Vector2.Zero));
            }

            this.CollisionSpheres[0].Center = new Vector3(this.Position, 0);
        }

        public ProjectPoutine(Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 500;
            this.MaxHP = 500;
            this.Texture = PersistentContent.GetTexture("ProjectPoutine");
            this.Power = 10;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = new Vector2(800, 200);
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 175)};
        }
    }
}
