using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class Plastic : EnemyProjectile
    {
        public override bool ToBeDeleted()
        {
            return this.X < -40 || this.Y < -40 || this.Y > Main.SCREEN_HEIGHT + 40;
        }

        public override void Update(GameTime gt)
        {
            this.CollisionSpheres[0].Center += new Vector3(this.Velocity, 0);

            if (this.AssociatedLevel.Player.X < this.X)
            {
                this.Velocity = (this.AssociatedLevel.Player.Position - this.Position) / 
                    (this.AssociatedLevel.Player.Position - this.Position).Length() * 8;
            }

            this.Position += this.Velocity;
        }

        Vector2 Velocity;

        public Plastic(Level AssociatedLevel, Vector2 StartingPosition)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 5;
            this.MaxHP = 5;
            this.Texture = PersistentContent.GetTexture("Plastic");
            this.Power = 3;
            this.Scale = 0.3f;
            this.Color = Color.White;
            this.Position = StartingPosition;
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 25)};
        }
    }
}
