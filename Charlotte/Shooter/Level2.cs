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
    public class Level2 : Level
    {
        public Level2()
            : base(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/PassingBy.dat"))
        {
            
        }

        protected override void PrepareLevel()
        {
            this.Player = new BobPlayer();
            this.Player.AssociatedLevel = this;

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Punkfish(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 2), new Vector2(-3, 0))
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Punkfish2(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 2), new Vector2(-3, 0)),
                new Punkfish2(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 2 - 200), new Vector2(-3, 0)),
                new Punkfish2(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 2 + 200), new Vector2(-3, 0))
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 2), new Vector2(-3, 0)),
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 2 - 200), new Vector2(-3, 0)),
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 2 + 200), new Vector2(-3, 0))
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 2), new Vector2(-3, 0)),
                new Punkfish2(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 2 - 200), new Vector2(-3, 0)),
                new Punkfish2(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 2 + 200), new Vector2(-3, 0)),
                new Punkfish(this, new Vector2(Main.SCREEN_WIDTH + 230, Main.SCREEN_HEIGHT / 2), new Vector2(-3, 0)),
            });

            //Oh Noes! The miniboss!
            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Anarfish(this)
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 2), new Vector2(-3, 0)),
                new Punkfish(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 2), new Vector2(-3, 0)),
                new Punkfish(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 2 - 200), new Vector2(-3, 0)),
                new Punkfish(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 2 + 200), new Vector2(-3, 0)),
                new Punkfish(this, new Vector2(Main.SCREEN_WIDTH + 230, Main.SCREEN_HEIGHT / 2), new Vector2(-3, 0)),
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 2), new Vector2(-3, 0))
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 7 * 2), new Vector2(-5, 0)),
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 7 * 3), new Vector2(-5, 0)),
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 7 * 4), new Vector2(-5, 0)),
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 7 * 5), new Vector2(-5, 0)),
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 7 * 6), new Vector2(-5, 0)),

                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 7 * 1), new Vector2(-5, 0)),
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 7 * 2), new Vector2(-5, 0)),
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 7 * 3), new Vector2(-5, 0)),
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 7 * 4), new Vector2(-5, 0)),
                new Punkfish3(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 7 * 5), new Vector2(-5, 0)),
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Punkfish2(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 2), new Vector2(-3, 0))
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Skull(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 5), new Vector2(-10, 0)),
                new Skull(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 5 * 2), new Vector2(-10, 0)),
                new Skull(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 5 * 3), new Vector2(-10, 0)),
                new Que(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 5))
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 10)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 10 * 2)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 10 * 5)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 10 * 6)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 10 * 7)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 10 * 9)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 10)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 10 * 3)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 10 * 4)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 10 * 5)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 10 * 8)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 130, Main.SCREEN_HEIGHT / 10 * 9)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 230, Main.SCREEN_HEIGHT / 10)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 230, Main.SCREEN_HEIGHT / 10 * 1)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 230, Main.SCREEN_HEIGHT / 10 * 2)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 230, Main.SCREEN_HEIGHT / 10 * 4)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 230, Main.SCREEN_HEIGHT / 10 * 6)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 230, Main.SCREEN_HEIGHT / 10 * 8)),
            });

            for (int i = 0; i < 10; i++)
            {
                Maples.Add(new Maple());
            }
        }

        public override void NextState()
        {
            Properties.Settings.Default.Temp = "Scene II - Boss";
            Main.ChangeCurrentState(new SaveLoadScreen(new BossBanter2(), true));
        }

        List<Maple> Maples = new List<Maple>();
        Random r = new Random();

        public override void BackgroundUpdate()
        {
            for (int i = 0; i < 10; i++)
            {
                Maples[i].X -= Maples[i].Speed;

                if (Maples[i].X < -100)
                {
                    Maples[i].Speed = r.Next(1, 6);
                    Maples[i].X = Main.SCREEN_WIDTH + r.Next(100, 300);
                }
            }
        }

        public override void BackgroundDraw(SpriteBatch sb)
        {
            sb.Draw(PersistentContent.GetTexture("Background2"), Main.ScreenBound, Color.White);

            foreach (Maple m in Maples)
            {
                sb.Draw(m);
            }
        }

        /// <summary>
        /// The class for the decorative maple sprites. How Canadian!
        /// </summary>
        class Maple : Sprite.Sprite
        {
            static Random r = new Random();
            public int Speed;

            public Maple()
            {
                this.Texture = PersistentContent.GetTexture("Maple");
                this.Scale = 1;
                this.Color = new Color(Color.White, 0.4f);
                this.Position = new Vector2(Main.SCREEN_WIDTH + r.Next(100, 300), r.Next((int)Main.SCREEN_HEIGHT));
                this.Speed = r.Next(1, 6);
            }
        }
    }
}
