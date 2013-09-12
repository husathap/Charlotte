using Charlotte.Content;
using Charlotte.IO;
using Charlotte.Music;
using Charlotte.Shooter.Players;
using Charlotte.Shooter.Projectiles.EnemyProjectiles;
using Charlotte.Slide;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Shooter
{
    public class Level4 : Level
    {

        public Level4()
            : base(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/PassingBy.dat"))
        {

        }

        protected override void PrepareLevel()
        {
            this.Player = new BobPlayer();
            this.Player.AssociatedLevel = this;

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new NarmSlide(this, 1, Main.SCREEN_WIDTH + 300),
                new NarmSlide(this, 2, Main.SCREEN_WIDTH + 300 + 600),
                new NarmSlide(this, 3, Main.SCREEN_WIDTH + 300 + 1200),
                new NarmSlide(this, 4, Main.SCREEN_WIDTH + 300 + 1800),
                new NarmSlide(this, 5, Main.SCREEN_WIDTH + 300 + 2400),
                new NarmSlide(this, 6, Main.SCREEN_WIDTH + 300 + 3000),
                new NarmSlide(this, 7, Main.SCREEN_WIDTH + 300 + 3600),
                new NarmSlide(this, 8, Main.SCREEN_WIDTH + 300 + 4200),
                new NarmSlide(this, 9, Main.SCREEN_WIDTH + 300 + 4800)
            });
        }

        public override void NextState()
        {
            Properties.Settings.Default.Temp = "Scene IV - Boss";
            Main.ChangeCurrentState(new SaveLoadScreen(new BossBanter4(), true));
        }

        public override void BackgroundUpdate()
        {
        }

        public override void BackgroundDraw(SpriteBatch sb)
        {
            sb.Draw(PersistentContent.GetTexture("GrayCloud"), Main.ScreenBound, Color.White);
        }
    }
}
