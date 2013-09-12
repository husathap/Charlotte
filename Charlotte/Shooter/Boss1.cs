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
    public class Boss1 : Level
    {

        public Boss1()
            : base(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/LastFightBeforeBattle.dat"))
        {
            this.Texture2DLoader = new Texture2DLoader(Main.ContentManager.RootDirectory + "/Compressed/ShooterTextures.zip", false);
        }

        protected override void PrepareLevel()
        {
            this.Player = new CharlottePlayer();
            this.Player.AssociatedLevel = this;

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Bedsheet(this)
            });
        }

        public override void NextState()
        {
            Properties.Settings.Default.Temp = "Scene II";
            Main.ChangeCurrentState(new SaveLoadScreen(new Scene2(), true));
        }

        public override void BackgroundUpdate()
        {
        }

        public override void BackgroundDraw(SpriteBatch sb)
        {
            sb.Draw(PersistentContent.GetTexture("BossBackground"), Main.ScreenBound, Color.White);
        }
    }
}
