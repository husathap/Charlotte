using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charlotte.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Charlotte.Content;
using Charlotte.IO;
using System.Threading;
using Charlotte.Slide;
using Charlotte.Shooter;

namespace Charlotte
{
    public class Title : State.InitializingState
    {

        static bool Loaded = false;

        Texture2D TitleScreenTexture;
        Selection TitleSelection = new Selection(250, 400, new string[] {"Play", "Continue", "Exit"});

        Texture2DLoader Texture2DLoader;
        SoundEffectLoader SoundEffectLoader;

        Thread LoadThread;
        ThreadStart LoadFunc;

        int LoadingBarX = 0;

        public override bool UpdateInitial(GameTime gt)
        {
            // Managing the loading bar.
            LoadingBarX += 5;

            if (LoadingBarX >= Main.SCREEN_WIDTH)
            {
                LoadingBarX = -261;
            }

            // Logic for managing the loader.
            if (LoadThread == null)
            {
                LoadFunc = () =>
                {
                    if (!Loaded)
                    {
                        try
                        {
                            if (this.Texture2DLoader != null)
                                this.Texture2DLoader.Load();

                            if (this.SoundEffectLoader != null)
                                this.SoundEffectLoader.Load();
                        }
                        catch
                        {
                            LoadThread.Abort();
                            Main.Quit();
                        }

                        Loaded = true;
                    }
                };

                LoadThread = new Thread(LoadFunc);
                LoadThread.Start();
                
            }
            else
            {
                if (LoadThread.ThreadState == ThreadState.Stopped)
                {
                    Main.SongPlayer.Open(Main.ContentManager.RootDirectory + "/Songs/GoFishingMotto.dat");
                    Main.SongPlayer.Play(true);
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
            TitleSelection.Update();
            return TitleSelection.Selected;
        }

        public override void DrawMiddle(SpriteBatch sb)
        {
            sb.Draw(TitleScreenTexture, Main.ScreenBound, Color.White);
            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0, TitleSelection.Y,
                Main.SCREEN_WIDTH, (int)TitleSelection.Height), new Color(Color.Black, 0.8f));
            TitleSelection.Draw(sb);
        }

        public override void UpdateFinal(GameTime gt)
        {
            switch (TitleSelection.SelectedIndex)
            {
                case 0:
                    Main.ChangeCurrentState(new Scene1());
                    break;
                case 1:
                    Main.ChangeCurrentState(new SaveLoadScreen(new Title(), false));
                    break;
                case 2:
                    Main.Quit();
                    break;
            }
        }

        public override void DrawFinal(SpriteBatch sb)
        {
            sb.Draw(TitleScreenTexture, Main.ScreenBound, Color.White);
            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0, TitleSelection.Y,
                Main.SCREEN_WIDTH, (int)TitleSelection.Height), new Color(Color.Black, 0.8f));
            TitleSelection.Draw(sb);
        }

        public Title()
        {
            this.Texture2DLoader = new Texture2DLoader(Main.ContentManager.RootDirectory + "/Compressed/ShooterTextures.zip", false);
            this.SoundEffectLoader = new Content.SoundEffectLoader(Main.ContentManager.RootDirectory +
                "/Compressed/ShooterSoundEffects.zip", false);

            LoadFunc = () =>
                {
                    TitleScreenTexture = Texture2D.FromStream(Main.GraphicsDevice,
                         File.OpenRead(Main.ContentManager.RootDirectory + "/Textures/TitleScreen.dat"));

                    if (Texture2DLoader != null)
                        Texture2DLoader.Load();
                    if (SoundEffectLoader != null)
                        SoundEffectLoader.Load();
                };

            LoadThread = new Thread(LoadFunc);
            LoadThread.Start();
        }
    }
}
