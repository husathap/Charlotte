using Charlotte.Content;
using Charlotte.Shooter.Projectiles.PlayerProjectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Players
{

    /// <summary>
    /// A dummy player that nobody cares.
    /// </summary>
    public class BobPlayer : Player
    {
        int counter = 0;
        int counter2 = 50;
        int counter3 = 0;

        protected override void PlayerInputUpdate(KeyboardState ks)
        {
            if (ks.IsKeyDown(Keys.Up) || ks.IsKeyDown(Keys.W))
            {
                this.Y -= 5;

                if (this.Y < 0)
                {
                    this.Y = 0;
                }
            }

            if (ks.IsKeyDown(Keys.Down) || ks.IsKeyDown(Keys.S))
            {
                this.Y += 5;

                if (this.Y > Main.SCREEN_HEIGHT)
                {
                    this.Y = Main.SCREEN_HEIGHT;
                }
            }

            if (ks.IsKeyDown(Keys.Left) || ks.IsKeyDown(Keys.A))
            {
                this.X -= 5;

                if (this.X < 0)
                {
                    this.X = 0;
                }
            }

            if (ks.IsKeyDown(Keys.Right) || ks.IsKeyDown(Keys.D))
            {
                this.X += 5;

                if (this.X > Main.SCREEN_WIDTH)
                {
                    this.X = Main.SCREEN_WIDTH;
                }
            }

            if (ks.IsKeyDown(Keys.Space) || ks.IsKeyDown(Keys.Enter))
            {
                counter2 += 1;

                if (counter2 >= 10 && PP > 0)
                {
                    if (this.AssociatedLevel.Waves != null && this.AssociatedLevel.Waves[this.AssociatedLevel.CurrentWaveNo] != null
                        && this.AssociatedLevel.Waves[this.AssociatedLevel.CurrentWaveNo].Count > 0)
                    {
                        PP -= 1;
                        Shoot(new HomingBobPlayerProjectile(this.AssociatedLevel, this.Position));
                        counter2 = 0;
                    }
                }
            }
            else
            {

                // Yes! Shooting by default!
                counter++;

                if (counter > 10)
                {
                    Shoot(new BobPlayerProjectile(this.Position));
                    counter = 0;
                }

                if (ks.IsKeyUp(Keys.Space) && ks.IsKeyUp(Keys.Enter))
                {
                    counter2 = 50;
                }

                counter3 += 1;
            }

            if (counter3 >= 30)
            {
                PP += 1;
                if (PP >= MaxPP)
                    PP = MaxPP;
                counter3 = 0;
            }

        }

        public BobPlayer()
        {
            this.X = Main.SCREEN_WIDTH / 5;
            this.Y = Main.SCREEN_HEIGHT / 2;
            this.HP = 20;
            this.MaxHP = 20;
            this.PP = 70;
            this.MaxPP = 70;
            this.Texture = PersistentContent.GetTexture("BobPlayer");
            this.Color = Color.White;
            this.collisionSphere = new BoundingSphere(new Vector3(this.X, this.Y, 0), 35);
        }
    }
}
