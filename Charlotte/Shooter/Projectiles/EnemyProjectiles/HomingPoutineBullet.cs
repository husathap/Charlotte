using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class HomingPoutineBullet : EnemyProjectile
    {

        float Speed;

        public override bool ToBeDeleted()
        {
            return this.X < -25 || this.X > Main.SCREEN_WIDTH + 25 || this.Y < -25 || this.Y > Main.SCREEN_HEIGHT + 25;
        }

        public override void Update(GameTime gt)
        {
            this.Position += (this.AssociatedLevel.Player.Position - this.Position) /
                (this.AssociatedLevel.Player.Position - this.Position).Length() * Speed;

            this.CollisionSpheres[0].Center = new Vector3(this.Position, 0);
        }

        public HomingPoutineBullet(Level AssociatedLevel, Vector2 StartingPosition, float Speed)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 1;
            this.MaxHP = 1;
            this.Texture = PersistentContent.GetTexture("HomingPoutineBullet");
            this.Power = 0.5f;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = StartingPosition;
            this.Speed = Speed;
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 7.5f)};
        }
    }
}
