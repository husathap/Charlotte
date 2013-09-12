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
    public class Boss4 : Level
    {

        public Boss4()
            : base(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/Aurora.dat"))
        {
        }

        protected override void PrepareLevel()
        {
            this.Player = new BobPlayer();
            this.Player.AssociatedLevel = this;

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Seal1(this),
                new Seal2(this),
                new Seal3(this),
                new Seal4(this)
            });
        }

        public override void NextState()
        {
            Main.ChangeCurrentState(new Ending());
        }

        public override void BackgroundUpdate()
        {
        }

        public override void BackgroundDraw(SpriteBatch sb)
        {
            sb.Draw(PersistentContent.GetTexture("Boss4Background"), Main.ScreenBound, Color.White);
        }
    }
}
