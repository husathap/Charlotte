using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class KillerKlownPhish : EnemyProjectile
    {
        float Counter = 0;
        int Counter2 = 0;

        bool Initialized = false;

        public override bool ToBeDeleted()
        {
            return false;
        }

        public override void Update(GameTime gt)
        {
            if (!Initialized)
            {
                this.Y += 10;
                Initialized = this.X >= Main.SCREEN_WIDTH - 300;
            }
            else
            {
                if (HP >= 10)
                {
                    if (this.X > -300)
                    {
                        this.Position += new Vector2(-10, 0);

                        if (this.Y < this.AssociatedLevel.Player.Y)
                        {
                            this.Position += new Vector2(0, 2);
                        }
                        else if (this.Y > this.AssociatedLevel.Player.Y)
                        {
                            this.Position += new Vector2(0, -2);
                        }

                        if (Math.Sin(Counter) > 0)
                        {
                            Shoot(new HomingSquareLaser(this.AssociatedLevel, this.Position + new Vector2(-25, -25), 2, Vector2.Zero));
                            Counter += 0.06f;
                        }
                        Counter += 0.01f;

                        if (Counter2 >= 80)
                        {
                            for (float a = 0; a < MathHelper.TwoPi; a += MathHelper.TwoPi / 5)
                            {
                                Shoot(new Skull(this.AssociatedLevel, this.Position, new Vector2(
                                    (float)(Math.Cos(a)), (float)(Math.Sin(a))) * 3));
                            }

                            Counter2 = 0;
                        }
                        Counter2++;
                    }
                    else
                    {
                        this.Position = new Vector2(Main.SCREEN_WIDTH + 300, this.Y);
                    }
                }
                else
                {

                    this.Power = 2; // Getting by a reversed fish is hard!

                    if (this.Position.X < Main.SCREEN_WIDTH + 300)
                    {
                        this.Position += new Vector2(8, 0);

                        if (this.Y < this.AssociatedLevel.Player.Y)
                        {
                            this.Position += new Vector2(0, 2);
                        }
                        else if (this.Y > this.AssociatedLevel.Player.Y)
                        {
                            this.Position += new Vector2(0, -2);
                        }

                        if (Math.Sin(Counter) > 0)
                        {
                            Shoot(new HomingSquareLaser(this.AssociatedLevel, this.Position + new Vector2(-30, -25), 4, Vector2.Zero));
                            Counter += 0.05f;
                        }
                        Counter += 0.01f;

                        if (Counter2 >= 60)
                        {
                            for (float a = 0; a < MathHelper.TwoPi; a += MathHelper.TwoPi / 6)
                            {
                                Shoot(new Skull(this.AssociatedLevel, this.Position, new Vector2(
                                    (float)(Math.Cos(a)), (float)(Math.Sin(a))) * 3));
                            }

                            Counter2 = 0;
                        }
                        Counter2++;
                    }
                    else
                    {
                        this.Position = new Vector2(-300, this.Y);
                    }
                }
            }

            this.CollisionSpheres[0].Center = new Vector3(this.Position, 0);
        }

        public KillerKlownPhish(Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 70;
            this.MaxHP = 70;
            this.Texture = PersistentContent.GetTexture("KillerKlownPhish");
            this.Power = 8;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = new Vector2(Main.SCREEN_WIDTH + 300, Main.SCREEN_HEIGHT / 2);
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 60)};
        }
    }
}
