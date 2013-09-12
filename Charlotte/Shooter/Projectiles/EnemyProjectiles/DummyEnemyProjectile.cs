using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class DummyEnemyProjectile : EnemyProjectile
    {
        public override bool ToBeDeleted()
        {
            return this.X < -35/2;
        }

        public override void Update(GameTime gt)
        {
            this.Position += this.Velocity;

            this.CollisionSpheres[0].Center += new Vector3(this.Velocity, 0);
        }

        Vector2 Velocity;

        Vector2 origin = new Vector2(0.5f, 0.5f);

        public override Vector2 Origin
        {
            get { return origin; }
        }

        public DummyEnemyProjectile(Level AssociatedLevel, Vector2 StartingPosition, Vector2 Velocity)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 10;
            this.MaxHP = 10;
            this.Texture = PersistentContent.GetTexture("Blank");
            this.Power = 3;
            this.Scale = 35;
            this.Color = Color.Gray;
            this.Position = StartingPosition;
            this.Velocity = Velocity;
            this.CollisionSpheres = new BoundingSphere[] { new BoundingSphere(new Vector3(this.Position, 0), 35/2) };
        }
    }
}
