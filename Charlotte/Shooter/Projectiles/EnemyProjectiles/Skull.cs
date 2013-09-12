using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class Skull : EnemyProjectile
    {
        bool BorderFlag;

        public override bool ToBeDeleted()
        {
            if (!BorderFlag)
            {
                return this.X < -25 || this.X > Main.SCREEN_WIDTH + 25 || this.Y < -25 || this.Y > Main.SCREEN_HEIGHT + 25;
            }

            return false;
        }

        public override void Update(GameTime gt)
        {
            this.Position += this.Velocity;
            this.CollisionSpheres[0].Center += new Vector3(this.Velocity, 0);

            if (BorderFlag)
            {
                BorderFlag = !(this.X < -25 || this.X > Main.SCREEN_WIDTH + 25 || this.Y < -25 || this.Y > Main.SCREEN_HEIGHT + 25);
            }
        }

        Vector2 Velocity;

        public Skull(Level AssociatedLevel, Vector2 StartingPosition, Vector2 Velocity)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 5;
            this.MaxHP = 5;
            this.Texture = PersistentContent.GetTexture("Skull");
            this.Power = 2;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = StartingPosition;
            this.Velocity = Velocity;
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 25)};

            if (this.X < -25 || this.X > Main.SCREEN_WIDTH + 25 || this.Y < -25 || this.Y > Main.SCREEN_HEIGHT + 25)
            {
                BorderFlag = true;
            }
        }
    }
}
