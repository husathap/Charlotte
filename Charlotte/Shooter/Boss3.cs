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
    public class Boss3 : Level
    {

        public Boss3()
            : base(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/FunnyShip.dat"))
        {
        }

        protected override void PrepareLevel()
        {
            this.Player = new BobPlayer();
            this.Player.AssociatedLevel = this;

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new ProjectPoutine(this)
            });
        }

        public override void NextState()
        {
            Properties.Settings.Default.Temp = "Scene IV";
            Main.ChangeCurrentState(new SaveLoadScreen(new Scene4(), true));
        }

        public override void BackgroundUpdate()
        {
        }

        public override void BackgroundDraw(SpriteBatch sb)
        {
            sb.Draw(PersistentContent.GetTexture("Boss3Background"), Main.ScreenBound, Color.White);
        }
    }
}
