using Charlotte.Content;
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
    public class Level1 : Level
    {
        float[] Rotations = new float[] { 0.1f, 0, 0.3f, 2, 1};

        public Level1()
            : base(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/Tutorial.dat"))
        {
        }

        protected override void PrepareLevel()
        {
            this.Player = new CharlottePlayer();
            this.Player.AssociatedLevel = this;

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Skull(this, new Vector2(Main.SCREEN_WIDTH + 30, Main.SCREEN_HEIGHT / 2), new Vector2(-3, 0))
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Skull(this, new Vector2(Main.SCREEN_WIDTH + 30, 100), new Vector2(-3, 0)),
                new Skull(this, new Vector2(Main.SCREEN_WIDTH + 60, 300), new Vector2(-3, 0)),
                new Skull(this, new Vector2(Main.SCREEN_WIDTH + 80, 500), new Vector2(-3, 0))
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Que(this, new Vector2(Main.SCREEN_WIDTH + 30, 100)),
                new Que(this, new Vector2(Main.SCREEN_WIDTH + 60, 300)),
                new Que(this, new Vector2(Main.SCREEN_WIDTH + 80, 500))
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 30, 100)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 60, 300)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 80, 500))
            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Que(this, new Vector2(Main.SCREEN_WIDTH + 30, 100)),
                new Que(this, new Vector2(Main.SCREEN_WIDTH + 60, 300)),
                new Que(this, new Vector2(Main.SCREEN_WIDTH + 80, 500)),
                new Que(this, new Vector2(Main.SCREEN_WIDTH + 80, 200)),
                new Que(this, new Vector2(Main.SCREEN_WIDTH + 60, 450)),
                new Que(this, new Vector2(Main.SCREEN_WIDTH + 30, 550)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 30, 200)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 60, 400)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 100, 200)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 300, 400)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 300, 200)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 300, 400)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 300, 200)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 300, 400))

            });

            Waves.Add(new List<Projectiles.EnemyProjectiles.EnemyProjectile>
            {
                new Skull(this, new Vector2(Main.SCREEN_WIDTH + 30, 100), new Vector2(-3, 0)),
                new Skull(this, new Vector2(Main.SCREEN_WIDTH + 60, 300), new Vector2(-3, 0)),
                new Skull(this, new Vector2(Main.SCREEN_WIDTH + 80, 500), new Vector2(-3, 0)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 30, 200)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 60, 400)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 100, 200)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 300, 400)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 300, 200)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 300, 400)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 300, 200)),
                new Plastic(this, new Vector2(Main.SCREEN_WIDTH + 300, 400)),
            });

            
        }

        public override void NextState()
        {
            Main.ChangeCurrentState(new BossBanter1());
        }

        public override void BackgroundUpdate()
        {
            int i = 0;

            while (i < 4)
            {
                Rotations[i] += 0.001f;
                i++;
            }
        }

        public override void BackgroundDraw(SpriteBatch sb)
        {
            sb.Draw(PersistentContent.GetTexture("Background"), Main.ScreenBound, Color.White);
            sb.Draw(PersistentContent.GetTexture("Decor"), new Vector2(100, 100), null, new Color(Color.DarkCyan, 0.9f), Rotations[0],
                Vector2.Zero, new Vector2(1, 1), SpriteEffects.None, 0);
            sb.Draw(PersistentContent.GetTexture("Decor"), new Vector2(300, 300), null, new Color(Color.DarkKhaki, 0.9f), Rotations[1],
                Vector2.Zero, new Vector2(1, 1), SpriteEffects.None, 0);
            sb.Draw(PersistentContent.GetTexture("Decor"), new Vector2(900, 400), null, new Color(Color.DarkGoldenrod, 0.9f), Rotations[2],
                Vector2.Zero, new Vector2(1, 1), SpriteEffects.None, 0);
            sb.Draw(PersistentContent.GetTexture("Decor"), new Vector2(700, 560), null, new Color(Color.DarkGreen, 0.9f), Rotations[3],
                Vector2.Zero, new Vector2(1, 1), SpriteEffects.None, 0);
            sb.Draw(PersistentContent.GetTexture("Decor"), new Vector2(1000, 200), null, new Color(Color.Gray, 0.9f), Rotations[3],
                Vector2.Zero, new Vector2(1, 1), SpriteEffects.None, 0);
        }
    }
}
