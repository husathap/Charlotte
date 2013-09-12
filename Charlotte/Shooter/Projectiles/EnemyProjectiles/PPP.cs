using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class PPP : EnemyProjectile
    {
        int Counter = 0;

        public override bool ToBeDeleted()
        {
            return false;
        }

        public override void Update(GameTime gt)
        {
            if (this.X > 900)
            {
                this.X -= 5;
                this.CollisionSpheres[0].Center = new Vector3(this.Position, 0);
            }

            Vector2 Drag = (this.Position - this.AssociatedLevel.Player.Position) /
                (this.Position - this.AssociatedLevel.Player.Position).Length() * 3;

            this.AssociatedLevel.Player.Position += Drag;

            if (Counter >= 250)
            {
                Shoot(new Sweeper(this.AssociatedLevel));
                Counter = 0;
            }

            Counter++;
        }

        public PPP(Level AssociatedLevel, float Y = Main.SCREEN_HEIGHT / 2)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 100;
            this.MaxHP = 100;
            this.Texture = PersistentContent.GetTexture("PPP1");
            this.Power = 4;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = new Vector2(Main.SCREEN_WIDTH + 30, Y);
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 20)};
        }
    }
}
