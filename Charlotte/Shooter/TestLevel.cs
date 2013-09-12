using Charlotte.Shooter.Players;
using Charlotte.Shooter.Projectiles.EnemyProjectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter
{
    public class TestLevel : Level
    {
        public TestLevel()
            : base(null)
        {
            this.Player = new DummyPlayer();
            this.Player.AssociatedLevel = this;
        }

        protected override void PrepareLevel()
        {
            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new DummyEnemyProjectile(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 2), new Vector2(-3, 0))
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new DummyEnemyProjectile(this, new Vector2(Main.SCREEN_WIDTH + 30, 100), new Vector2(-3, 0)),
                new DummyEnemyProjectile(this, new Vector2(Main.SCREEN_WIDTH + 60, 300), new Vector2(-3, 0)),
                new DummyEnemyProjectile(this, new Vector2(Main.SCREEN_WIDTH + 80, 500), new Vector2(-3, 0))
            });
        }

        public override void NextState()
        {
            Main.ChangeCurrentState(new Title());
        }

        public override void BackgroundUpdate()
        {
        }

        public override void BackgroundDraw(SpriteBatch sb)
        {
        }
    }
}
