using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class HomingSquareLaser : EnemyProjectile
    {

        float Speed;
        Vector2 Bias;

        public override bool ToBeDeleted()
        {
            return this.X < -20 || this.X > Main.SCREEN_WIDTH + 20 || this.Y < -20 || this.Y > Main.SCREEN_HEIGHT + 20;
        }

        public override void Update(GameTime gt)
        {
            this.Position += (this.AssociatedLevel.Player.Position - this.Position) /
                (this.AssociatedLevel.Player.Position - this.Position).Length() * Speed + Bias;

            this.CollisionSpheres[0].Center = new Vector3(this.Position, 0);
        }

        public HomingSquareLaser(Level AssociatedLevel, Vector2 StartingPosition, float Speed, Vector2 Bias)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 1;
            this.MaxHP = 1;
            this.Texture = PersistentContent.GetTexture("SquareLaser");
            this.Power = 0.1f;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = StartingPosition;
            this.Speed = Speed;
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 12)};
            this.Bias = Bias;
        }
    }
}
