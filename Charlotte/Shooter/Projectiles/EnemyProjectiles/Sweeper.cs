using Charlotte.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter.Projectiles.EnemyProjectiles
{
    public class Sweeper : EnemyProjectile
    {
        public override bool ToBeDeleted()
        {
            return this.X < -25;
        }

        public override void Update(GameTime gt)
        {
            this.X -= 5;
            this.CollisionBoxes[0] = new BoundingBox(
                new Vector3(this.Position + new Vector2(-25, -300), 0),
                new Vector3(this.Position + new Vector2(25, 300), 0));
        }

        public Sweeper(Level AssociatedLevel)
        {
            this.AssociatedLevel = AssociatedLevel;

            this.HP = 10000000000;
            this.MaxHP = 10000000000;
            this.Texture = PersistentContent.GetTexture("Sweeper");
            this.Power = 0;
            this.Scale = 1;
            this.Color = Color.White;
            this.Position = new Vector2(Main.SCREEN_WIDTH + 50, Main.SCREEN_HEIGHT /2);
            this.CollisionBoxes = new BoundingBox[] {new BoundingBox(
                new Vector3(this.Position + new Vector2(-25, -300), 0),
                new Vector3(this.Position + new Vector2(25, 300), 0))};
        }
    }
}
