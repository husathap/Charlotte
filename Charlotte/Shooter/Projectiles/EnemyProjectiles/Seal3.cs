using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class Seal4 : EnemyProjectile
    {
        Vector2 Velocity = new Vector2(0, 5);
        float Counter = 0;

        public override bool ToBeDeleted()
        {
            return false;
        }

        public override void Update(GameTime gt)
        {

            if (Math.Cos(Counter) > 0)
            {
                Vector2 vec = (this.AssociatedLevel.Player.Position - this.Position) /
                    (this.AssociatedLevel.Player.Position - this.Position).Length() * 5;
                Shoot(new BigBullet(this.AssociatedLevel, this.Position, vec, 2, Color.Red));
            }

            if (this.HP < 100)
            {
                this.Position += Velocity;

                if (this.Y <= 0 || this.Y >= Main.SCREEN_HEIGHT)
                {
                    Velocity *= -1;
                }

                Counter += 0.05f;
            }
            else
            {
                Counter += 0.01f;
            }

            
            this.CollisionBoxes[0] = new BoundingBox(
                new Vector3(this.Position.X - 100, this.Position.Y - 100, 0),
                new Vector3(this.Position.X + 100, this.Position.Y + 100, 0));
        }

        public Seal4(Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 200;
            this.MaxHP = 200;
            this.Texture = PersistentContent.GetTexture("Seal3");
            this.Power = 2;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = new Vector2(Main.SCREEN_WIDTH / 2 - 100, Main.SCREEN_HEIGHT / 2 + 100);
            this.CollisionBoxes = new BoundingBox[] { new BoundingBox(
                new Vector3(this.Position.X - 100, this.Position.Y - 100, 0),
                new Vector3(this.Position.X + 100, this.Position.Y + 100, 0))};
        }
    }
}
