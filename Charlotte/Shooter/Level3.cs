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
    public class Level3 : Level
    {
        Texture2D[] Backgrounds = new Texture2D[13];
        int BackgroundCounter = 0;
        float BackgroundAlpha = 1;
        int BackgroundIndex;
        Random BackgroundPicker = new Random();

        public Level3()
            : base(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/PassingBy.dat"))
        {
            Backgrounds[0] = PersistentContent.GetTexture("StJohns");
            Backgrounds[1] = PersistentContent.GetTexture("Iqaluit");
            Backgrounds[2] = PersistentContent.GetTexture("Yellowknife");
            Backgrounds[3] = PersistentContent.GetTexture("Whitehorse");
            Backgrounds[4] = PersistentContent.GetTexture("Victoria");
            Backgrounds[5] = PersistentContent.GetTexture("Edmonton");
            Backgrounds[6] = PersistentContent.GetTexture("Regina");
            Backgrounds[7] = PersistentContent.GetTexture("Winnipeg");
            Backgrounds[8] = PersistentContent.GetTexture("Toronto");
            Backgrounds[9] = PersistentContent.GetTexture("Quebec");
            Backgrounds[10] = PersistentContent.GetTexture("Fredericton");
            Backgrounds[11] = PersistentContent.GetTexture("Halifax");
            Backgrounds[12] = PersistentContent.GetTexture("Charlottetown");

            BackgroundIndex = BackgroundPicker.Next(0, 12);
        }

        protected override void PrepareLevel()
        {
            this.Player = new BobPlayer();
            this.Player.AssociatedLevel = this;

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new PPP(this)
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new PPP(this),
                new Assailant(this, new Vector2(900, 200)),
                new Assailant(this, new Vector2(900, 400))
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new PPP(this),
                new FocusedAssailant(this, new Vector2(900, 200)),
                new FocusedAssailant(this, new Vector2(900, 400))
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new PPP(this, 200),
                new PPP(this, 400),
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new FocusedAssailant(this, new Vector2(900, 100)),
                new Assailant(this, new Vector2(800, 200)),
                new Assailant(this, new Vector2(700, 300)),
                new PPP(this),
                new Assailant(this, new Vector2(800, 400)),
                new FocusedAssailant(this, new Vector2(900, 500))
            });
        }

        public override void NextState()
        {
            Properties.Settings.Default.Temp = "Scene III - Boss";
            Main.ChangeCurrentState(new SaveLoadScreen(new BossBanter3(), true));
        }

        public override void BackgroundUpdate()
        {
            if (BackgroundCounter >= 300)
            {
                if (BackgroundAlpha > 0)
                {
                    BackgroundAlpha -= 0.01f;
                }
                else
                {
                    int CurrentIndex = BackgroundIndex;

                    while (CurrentIndex == BackgroundIndex)
                    {
                        BackgroundIndex = BackgroundPicker.Next(0, 12);
                    }
                    BackgroundCounter = 0;
                    BackgroundAlpha = 1;
                }
            }

            BackgroundCounter++;
        }

        public override void BackgroundDraw(SpriteBatch sb)
        {
            sb.Draw(Backgrounds[BackgroundIndex], Main.ScreenBound, new Color(Color.White, BackgroundAlpha));
        }
    }
}
