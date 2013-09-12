using Charlotte.Content;
using Charlotte.Music;
using Charlotte.Shooter.Players;
using Charlotte.State;
using Charlotte.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Threading;
using Charlotte.Shooter.Projectiles;
using Charlotte.Shooter.Projectiles.PlayerProjectiles;
using Charlotte.Shooter.Projectiles.EnemyProjectiles;
using Charlotte.Shooter.Effects;
using Charlotte.Slide;

namespace Charlotte.Shooter
{

    public abstract class Level : InitializingState
    {

        #region Intialization
        bool Initialized = false;

        /// <summary>
        /// Initialize the level.
        /// </summary>
        public void Initialize()
        {
            LoadFunc = () =>
            {
                if (Texture2DLoader != null)
                {
                    Texture2DLoader.Load();
                }

                if (SoundEffectLoader != null)
                {
                    SoundEffectLoader.Load();
                }

                PrepareLevel();
            };

            LoadThread = new Thread(LoadFunc);
            LoadThread.Start();

            Initialized = true;
        }

        public float TransitionAlpha = 1;

        protected abstract void PrepareLevel();

        int LoadingBarX = 0;
        #endregion

        #region Loading
        protected Texture2DLoader Texture2DLoader;
        protected SoundEffectLoader SoundEffectLoader;

        protected Thread LoadThread;
        protected ThreadStart LoadFunc;
        #endregion

        #region Wave Management
        public List<List<EnemyProjectile>> Waves;
        private int currentWaveNo = 0;

        public int CurrentWaveNo
        {
            get { return currentWaveNo; }
        }

        public int MaxWave = -1;

        /// <summary>
        /// Update the enemy projectiles.
        /// </summary>
        /// <param name="gt"></param>
        private void UpdateProjectiles(GameTime gt)
        {
            if (Waves != null)
            {
                int i = 0;

                while (i < Waves[currentWaveNo].Count && Waves[currentWaveNo].Count >0)
                {
                    Waves[currentWaveNo][i].Update(gt);

                    if (Waves[currentWaveNo][i].ToBeDeleted())
                    {
                        Waves[currentWaveNo].RemoveAt(i);
                        i--;
                    }
                    else
                    {

                        // Check for collision.

                        bool Collided = false;

                        if (Waves[currentWaveNo][i].CollisionSpheres != null)
                        {
                            foreach (BoundingSphere b in Waves[currentWaveNo][i].CollisionSpheres)
                            {
                                if (b.Intersects(Player.CollisionSphere))
                                {
                                    Collided = true;
                                    break;
                                }
                            }
                        }

                        if (Waves[currentWaveNo][i].CollisionBoxes != null)
                        {
                            foreach (BoundingBox b in Waves[currentWaveNo][i].CollisionBoxes)
                            {
                                if (b.Intersects(Player.CollisionSphere))
                                {
                                    Collided = true;
                                    break;
                                }
                            }
                        }

                        if (Collided)
                        {
                            // If the projectile has the power of > 0, then it will be removed after crashing against the player. (Attack)
                            // If the projectile has the power = 0, then it will not be removed after crashing against the player.
                            // If the projectile has the power of < 0, then it will be rmoved after crashing against the player. (Heal)
                            if (Waves[currentWaveNo][i].Power > 0)
                            {
                                if (!Recovering)
                                {
                                    // This means the player is hit!
                                    this.Player.HP -= Waves[currentWaveNo][i].Power;
                                    Effects.Add(new PlayerExplosion(Waves[currentWaveNo][i].Position, 2f));
                                    PersistentContent.GetSFX("PlayerHit").Play();
                                    Recovering = true;
                                    i--;
                                }
                            }
                            else if (Waves[currentWaveNo][i].Power < 0)
                            {
                                // This means the player receives a powerup.
                                // There is no powerup in this game; however!

                                this.Player.HP -= Waves[currentWaveNo][i].Power;

                                if (this.Player.HP > this.Player.MaxHP)
                                {
                                    this.Player.HP = this.Player.MaxHP;
                                }

                                Waves[currentWaveNo].RemoveAt(i);
                                i--;
                            }
                        }
                    }

                    i++;
                }
            }
        }
        #endregion

        #region Audio Management
        public Soundtrack BackgroundMusic;
        #endregion

        #region Additional Update Function
        public abstract void BackgroundUpdate();
        public abstract void BackgroundDraw(SpriteBatch sb);
        #endregion

        #region Player Management
        public Player Player;
        int RecoveryCounter = 0; //Indicate how long has the player been recovering.
        int RecoveryTime = 100;
        bool Recovering = false;

        public List<PlayerProjectile> PlayerProjectiles = new List<PlayerProjectile>();

        private void UpdatePlayer(KeyboardState ks, GameTime gt)
        {
            if (Player.HP < 0)
            {
                Main.ChangeCurrentState(new GameOver("The HP has reached 0. A big no-no for a shooter game."));
            }
            else
            {
                Player.PlayerUpdate(ks);

                if (Recovering)
                {
                    RecoveryCounter++;

                    if (RecoveryCounter > RecoveryTime)
                    {
                        RecoveryCounter = 0;
                        Recovering = false;
                    }
                }

                int i = 0;

                // Update player's bullet.
                while (i < PlayerProjectiles.Count)
                {
                    int j = 0;

                    PlayerProjectiles[i].Update(gt);

                    if (Waves != null)
                    {
                        while (j < Waves[currentWaveNo].Count)
                        {
                            // The player's bullet has hit the enemy.
                            if (PlayerProjectiles[i].CollidedWithEnemy(Waves[currentWaveNo][j]))
                            {
                                Waves[currentWaveNo][j].HP -= PlayerProjectiles[i].Power;
                                PlayerProjectiles[i].HP = 0;
                                PersistentContent.GetSFX("EnemyHit").Play();
                            }

                            j++;
                        }
                    }

                    i++;
                }

                i = 0;

                // Delete marked player's bullet.
                while (i < PlayerProjectiles.Count)
                {
                    if (PlayerProjectiles[i].ToBeDeleted() || PlayerProjectiles[i].HP <= 0)
                    {
                        PlayerProjectiles.RemoveAt(i);
                        i--;
                    }
                    i++;
                }

                // Delete enemies.
                if (Waves != null)
                {
                    i = 0;

                    while (i < Waves[currentWaveNo].Count)
                    {
                        if (Waves[currentWaveNo][i].ToBeDeleted())
                        {
                            Waves[currentWaveNo].RemoveAt(i);
                            i--;
                        }
                        else if (Waves[currentWaveNo][i].HP <= 0)
                        {
                            Effects.Add(new Explosion(Waves[currentWaveNo][i].Position, 2));
                            PersistentContent.GetSFX("EnemyDead").Play();
                            Waves[currentWaveNo].RemoveAt(i);
                            i--;
                        }
                        i++;
                    }
                }
            }
        }
        #endregion

        #region Input Managment
        KeyboardState oldks;
        #endregion

        #region Effect Management
        public List<Sprite.AnimatedSprite> Effects = new List<AnimatedSprite>();

        /// <summary>
        /// Update all the effects in the game.
        /// </summary>
        private void UpdateEffects()
        {
            int i = 0;

            while (i < Effects.Count)
            {
                Effects[i].Update();

                if (Effects[i].LoopTime > 0)
                {
                    Effects.RemoveAt(i);
                    i--;
                }

                i++;
            }
        }
        #endregion

        #region Paused
        bool Paused = false;

        private void UpdatePause(KeyboardState ks)
        {
            if (ks.IsKeyDown(Keys.Enter) || ks.IsKeyDown(Keys.Space))
                Paused = false;
            if (ks.IsKeyDown(Keys.Q))
                Main.ChangeCurrentState(new Title());
        }

        private void DrawPaused(SpriteBatch sb)
        {
            sb.Draw(PersistentContent.GetTexture("Blank"), Main.ScreenBound, new Color(Color.Black, 0.8f));
            sb.DrawString(PersistentContent.GetFont("Large"), "Paused", new Vector2(30, 0), Color.White);
            sb.DrawString(PersistentContent.GetFont("Normal"), "Press the shooting button to continue.", new Vector2(30, 100), Color.White);
            sb.DrawString(PersistentContent.GetFont("Normal"), "Press Q to forfeit the game and to return to Title.", new Vector2(30, 150), Color.White);
            sb.Draw(PersistentContent.GetTexture("Comic"), new Rectangle(112, 300, 800, 200), Color.White);
        }
        #endregion

        #region Testing
        public bool Endless = false;
        #endregion

        /// <summary>
        /// Initialize the level.
        /// </summary>
        /// <param name="gt"></param>
        /// <returns></returns>
        public override bool UpdateInitial(GameTime gt)
        {
            if (!Initialized)
                Initialize();
            else
            {
                LoadingBarX += 5;

                if (LoadingBarX > Main.SCREEN_WIDTH)
                {
                    LoadingBarX = -261;
                }

                if (LoadThread == null || LoadThread.ThreadState == ThreadState.Stopped)
                {
                    if (BackgroundMusic != null)
                        BackgroundMusic.Play(Main.SongPlayer);

                    return true;
                }
            }

            return false;
        }

        public override void DrawInitial(SpriteBatch sb)
        {
            sb.Draw(PersistentContent.GetTexture("LoadingScreen"), Main.ScreenBound, Color.White);
            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(LoadingBarX, 500,
                261, 10), Color.Red);
        }

        public override bool UpdateMiddle(GameTime gt)
        {
            KeyboardState ks = Keyboard.GetState();

            if (TransitionAlpha > 0)
            {
                TransitionAlpha -= 0.01f;
            }

            if (!Paused)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    Paused = true;
                }

                UpdatePlayer(ks, gt);
                UpdateProjectiles(gt);
                UpdateEffects();
                BackgroundUpdate();

                // Update the wave. If there is no wave left, then move on with the game.
                // If the Endless mode is on, then the level never ends.
                if (Waves != null && currentWaveNo < Waves.Count)
                {
                    if (Waves[currentWaveNo].Count == 0)
                    {
                        currentWaveNo++;

                        if (currentWaveNo == Waves.Count)
                        {
                            if (!Endless)
                            {
                                return true;
                            }
                            
                        }

                        //return currentWaveNo == Waves.Count && !Endless;
                    }
                }
            }
            else
            {
                UpdatePause(ks);
            }

            oldks = ks;

#if DEBUG
            // Developers may skip a level by pressing F1.
            if (ks.IsKeyDown(Keys.F1))
            {
                return true;
            }
#endif
            return false;
        }

        public override void DrawMiddle(SpriteBatch sb)
        {
            // Draw the background.
            BackgroundDraw(sb);

            // Draw the projectiles.
            if (Waves != null)
            {
                try
                {
                    foreach (Projectile p in Waves[currentWaveNo])
                    {
                        sb.Draw(p, new Color(p.Color.R, (int)(p.Color.G * p.HP / p.MaxHP),  (int)(p.Color.B * p.HP / p.MaxHP)));
                    }
                }
                catch { }
            }

            // Draw the player projectiles.
            foreach (Projectile p in PlayerProjectiles)
            {
                sb.Draw(p);
            }

            // Draw the player.
            if (!Recovering)
            {
                sb.Draw(Player);
            }
            else
            {
                sb.Draw(Player, new Color(Player.Color, 0.4f));
            }

            // Draw the effects.
            foreach (Sprite.AnimatedSprite a in Effects)
            {
                sb.Draw(a);
            }

            // Draw the HUD background:
            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0, 0, Main.SCREEN_WIDTH, 30),
                new Color(Color.Black, 0.5f));
            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0, Main.SCREEN_HEIGHT - 30, Main.SCREEN_WIDTH,
                30), new Color(Color.Black, 0.5f));

            // Draw HP Bar:
            sb.DrawString(PersistentContent.GetFont("Normal"), "HP", new Vector2(5, -5), Color.White);
            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(45, 12, 300, 10), Color.Gray);
            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(45, 12,
                (int)(300 * Player.HP / Player.MaxHP), 10), Color.LimeGreen);

            // Draw PP Bar:
            sb.DrawString(PersistentContent.GetFont("Normal"), "PP", new Vector2(400, -5), Color.White);
            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(440, 12, 300, 10), Color.Gray);
            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(440, 12,
                (int)(300 * Player.PP / Player.MaxPP), 10), Color.Yellow);

            // Draw Progress Bar:
            sb.DrawString(PersistentContent.GetFont("Normal"), "Waves", new Vector2(10, Main.SCREEN_HEIGHT -
                PersistentContent.GetFont("Normal").LineSpacing), Color.White);
            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(95, Main.SCREEN_HEIGHT - 20,
                Main.SCREEN_WIDTH - 400, 10), Color.Gray);
            if (!Endless)
            {
                if (currentWaveNo < Waves.Count)
                    sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(95, Main.SCREEN_HEIGHT - 20,
                        (int)((Main.SCREEN_WIDTH - 400) * currentWaveNo / (Waves.Count)), 10), Color.White);
                else
                    sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(95, Main.SCREEN_HEIGHT - 20,
                        Main.SCREEN_WIDTH - 400, 10), Color.White);
            }

            // Draw the quick tip:
            sb.DrawString(PersistentContent.GetFont("Normal"), "Esc: Pause + Comic", new Vector2(735, Main.SCREEN_HEIGHT -
                PersistentContent.GetFont("Normal").LineSpacing), Color.White);

            if (TransitionAlpha > 0)
            {
                sb.Draw(PersistentContent.GetTexture("Blank"), Main.ScreenBound, new Color(Color.Black, TransitionAlpha));
            }

            if (Paused)
            {
                DrawPaused(sb);
            }
        }

        public override void UpdateFinal(GameTime gt)
        {
            if (Effects.Count <= 0)
            {
                if (TransitionAlpha < 1)
                {
                    TransitionAlpha += 0.01f;
                }
                else
                {
                    NextState();
                }
            }
            else
            {
                UpdateEffects();
            }
        }

        public override void DrawFinal(SpriteBatch sb)
        {
            DrawMiddle(sb);
            sb.Draw(PersistentContent.GetTexture("Blank"), Main.ScreenBound, new Color(Color.Black, TransitionAlpha));

        }

        public Level(Soundtrack s)
        {

            BackgroundMusic = s;

            Waves = new List<List<EnemyProjectile>>();
        }

        /// <summary>
        /// Go to the next state.
        /// </summary>
        public abstract void NextState();
    }
}

