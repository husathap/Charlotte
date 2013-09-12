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
    public class DummyPlayer : Player
    {
        int counter = 0;

        protected override void PlayerInputUpdate(KeyboardState ks)
        {
            if (ks.IsKeyDown(Keys.Up))
            {
                this.Y -= 5;

                if (this.Y < 0)
                {
                    this.Y = 0;
                }
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                this.Y += 5;

                if (this.Y > Main.SCREEN_HEIGHT)
                {
                    this.Y = Main.SCREEN_HEIGHT;
                }
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                this.X -= 5;

                if (this.X < 0)
                {
                    this.X = 0;
                }
            }

            if (ks.IsKeyDown(Keys.Right))
            {
                this.X += 5;

                if (this.X > Main.SCREEN_WIDTH)
                {
                    this.X = Main.SCREEN_WIDTH;
                }
            }

            if (ks.IsKeyDown(Keys.Enter) || ks.IsKeyDown(Keys.Space))
            {
                counter++;

                if (counter > 10)
                {
                    Shoot(new DummyPlayerProjectile(this.Position));
                    counter = 0;
                }
            }

        }

        Vector2 origin = new Vector2(0.5f, 0.5f);

        public override Vector2 Origin
        {
            get { return origin; }
        }

        public DummyPlayer()
        {
            this.X = Main.SCREEN_WIDTH / 5;
            this.Y = Main.SCREEN_HEIGHT / 2;
            this.HP = 40;
            this.MaxHP = 40;
            this.PP = 0;
            this.MaxPP = 0;
            this.Texture = PersistentContent.GetTexture("Blank");
            this.Scale = 40;
            this.Color = Color.Pink;
            this.collisionSphere = new BoundingSphere(new Vector3(this.X, this.Y, 0), 20);
        }
    }
}
