using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class Seal3 : EnemyProjectile
    {
        Vector2 Velocity = new Vector2(5, 0);
        float Counter = 0;

        public override bool ToBeDeleted()
        {
            return false;
        }

        public override void Update(GameTime gt)
        {
            if (HP < 100)
            {
                this.Position += Velocity;

                if (this.Position.X <= 0 || this.Position.X >= Main.SCREEN_WIDTH)
                {
                    Velocity *= -1;
                }

                if (Math.Cos(Counter) > 0)
                {
                    for (float i = 0; i < MathHelper.TwoPi; i += MathHelper.TwoPi / 5)
                    {
                        Shoot(new BigBullet(this.AssociatedLevel, this.Position, (new Vector2(
                            (float)Math.Cos(i), (float)Math.Sin(i))) * 3, 1, Color.Green));
                    }
                }
                Counter += 0.05f;
            }

            this.CollisionBoxes[0] = new BoundingBox(
                new Vector3(this.Position.X - 100, this.Position.Y - 100, 0),
                new Vector3(this.Position.X + 100, this.Position.Y + 100, 0));
        }

        public Seal3(Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 300;
            this.MaxHP = 300;
            this.Texture = PersistentContent.GetTexture("Seal4");
            this.Power = 2;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = new Vector2(Main.SCREEN_WIDTH / 2 + 100, Main.SCREEN_HEIGHT / 2 + 100);
            this.CollisionBoxes = new BoundingBox[] { new BoundingBox(
                new Vector3(this.Position.X - 100, this.Position.Y - 100, 0),
                new Vector3(this.Position.X + 100, this.Position.Y + 100, 0))};
        }
    }
}
