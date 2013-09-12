using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class Bedsheet : EnemyProjectile
    {

        public override bool ToBeDeleted()
        {
            return false;
        }

        int counter = 0;

        public override void Update(GameTime gt)
        {
            this.CollisionSpheres[0].Center = new Vector3(this.Position, 0);

            if (this.X > 800)
            {
                this.X -= 10;
            }

            this.Y = this.AssociatedLevel.Player.Y;

            if (this.HP > 15)
            {
                if (counter >= 90)
                {
                    Shoot(new Plastic(this.AssociatedLevel, new Vector2(this.Position.X, this.Position.Y - 100)));
                    Shoot(new Plastic(this.AssociatedLevel, this.Position));
                    Shoot(new Plastic(this.AssociatedLevel, new Vector2(this.Position.X, this.Position.Y + 100)));
                    counter = 0;
                }

                counter++;
            }
            else
            {
                if (counter >= 90)
                {
                    Shoot(new Plastic(this.AssociatedLevel, new Vector2(this.Position.X, this.Position.Y - 100)));
                    Shoot(new Plastic(this.AssociatedLevel, this.Position));
                    Shoot(new Plastic(this.AssociatedLevel, new Vector2(this.Position.X, this.Position.Y + 100)));

                    Shoot(new Que(this.AssociatedLevel, new Vector2(Main.SCREEN_WIDTH + 100, this.Position.Y - 100)));
                    Shoot(new Que(this.AssociatedLevel, new Vector2(Main.SCREEN_WIDTH + 100, this.Position.Y + 100)));
                    counter = 0;
                }

                counter++;
            }
        }

        public Bedsheet(Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 50;
            this.MaxHP = 180;
            this.Texture = PersistentContent.GetTexture("Bedsheet");
            this.Power = 3;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = new Vector2(Main.SCREEN_WIDTH + 100, Main.SCREEN_HEIGHT / 2);
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 40)};
        }
    }
}
