using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class FocusedAssailant : EnemyProjectile
    {
        int Counter = 0;
        Vector2 FinalPosition;

        public override bool ToBeDeleted()
        {
            return false;
        }

        public override void Update(GameTime gt)
        {
            if (this.X < FinalPosition.X)
            {
                this.X += 5;
                this.CollisionSpheres[0].Center += new Vector3(5, 0, 0);
            }
            else if (this.X > FinalPosition.X)
            {
                this.X -= 5;
                this.CollisionSpheres[0].Center += new Vector3(-5, 0, 0);
            }


            if (this.AssociatedLevel.Player.HP / this.AssociatedLevel.Player.MaxHP >= 0.05f)
            {
                if (Counter >= 80)
                {
                    Shoot(new HomingPoutineBullet(this.AssociatedLevel, this.Position, 5));
                    Counter = 0;
                }
            }
            Counter++;
        }

        public FocusedAssailant(Level AssociatedLevel, Vector2 FinalPosition)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 30;
            this.MaxHP = 30;
            this.Texture = PersistentContent.GetTexture("FocusedAssailant");
            this.Power = 5;
            this.Scale = 1;
            this.Color = Color.White;
            this.FinalPosition = FinalPosition;
            this.Position = new Vector2(Main.SCREEN_WIDTH + 20, FinalPosition.Y);
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 20)};
        }
    }
}
