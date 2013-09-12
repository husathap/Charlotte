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
    public class Boss2 : Level
    {

        public Boss2()
            : base(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/Irregularity.dat"))
        {
        }

        protected override void PrepareLevel()
        {
            this.Player = new BobPlayer();
            this.Player.AssociatedLevel = this;

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new KillerKlownPhish(this)
            });
        }

        public override void NextState()
        {
            Properties.Settings.Default.Temp = "Scene III";
            Main.ChangeCurrentState(new SaveLoadScreen(new Scene3(), true));
        }

        public override void BackgroundUpdate()
        {
        }

        public override void BackgroundDraw(SpriteBatch sb)
        {
            sb.Draw(PersistentContent.GetTexture("Boss2Background"), Main.ScreenBound, Color.White);
        }
    }
}
