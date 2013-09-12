#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Charlotte.Content;
using System.IO;
using System.Threading;
using Microsoft.Xna.Framework.Media;
using System.Runtime.InteropServices;
using System.Text;
using Charlotte.Music;
using Charlotte.IO;
using Charlotte.Shooter;
#endregion

namespace Charlotte
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Main : Game
    {   

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        /// <summary>
        /// The width of the game's screen.
        /// </summary>
        public const int SCREEN_WIDTH = 1024;

        /// <summary>
        /// The height of the game's screen.
        /// </summary>
        public const int SCREEN_HEIGHT = 600;


        static Rectangle screenBound = new Rectangle(0, 0, SCREEN_WIDTH, SCREEN_HEIGHT);

        /// <summary>
        /// The rectangle that represents the whole screen.
        /// </summary>
        public static Rectangle ScreenBound
        {
            get { return screenBound; }
        }

        /// <summary>
        /// The current state of the game.
        /// </summary>
        private static State.State CurrentState;

        /// <summary>
        /// Change the current state.
        /// </summary>
        /// <param name="NewState"></param>
        public static void ChangeCurrentState(State.State NewState)
        {
            Main.SongPlayer.Close();
            TemporaryContent.Clear();
            CurrentState = NewState;
        }

        public static ContentManager ContentManager;
        new public static GraphicsDevice GraphicsDevice;

        /// <summary>
        /// The main song player for the game.
        /// </summary>
        public static SongPlayer SongPlayer = new SongPlayer();

        /// <summary>
        /// Exit the game.
        /// </summary>
        public static void Quit()
        {
            CurrentState = null;
        }
        
        public Main()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ContentManager = this.Content;
            GraphicsDevice = graphics.GraphicsDevice;
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            SetPosition(this.Window, new Point(
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - SCREEN_WIDTH / 2,
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 - SCREEN_HEIGHT / 2));

            if (Directory.Exists("../../Temp/"))
                Directory.Delete("../../Temp/", true);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

           
            Selection.LoadSelectionContent(graphics.GraphicsDevice, Content);

            PersistentContent.AddFont("Selection",
                Content.Load<SpriteFont>("Fonts/Selection"));
            PersistentContent.AddFont("Slide",
                Content.Load<SpriteFont>("Fonts/Slide"));

            Texture2D Temp =  new Texture2D(Main.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            Temp.SetData(new[] { Color.White });

            PersistentContent.AddTexture("Blank", Temp);
            PersistentContent.AddTexture("LoadingScreen",
                Texture2D.FromStream(Main.GraphicsDevice, File.OpenRead(Main.ContentManager.RootDirectory +
                "/Textures/LoadingScreen.dat")));
            PersistentContent.AddTexture("SaveLoad",
                Texture2D.FromStream(Main.GraphicsDevice, File.OpenRead(Main.ContentManager.RootDirectory +
                "/Textures/SaveLoad.dat")));
            PersistentContent.AddTexture("Explosion",
                Texture2D.FromStream(Main.GraphicsDevice, File.OpenRead(Main.ContentManager.RootDirectory +
                "/Textures/Explosion.dat")));

            PersistentContent.AddFont("Small", Content.Load<SpriteFont>("Fonts/Small"));
            PersistentContent.AddFont("Normal", Content.Load<SpriteFont>("Fonts/Normal"));
            PersistentContent.AddFont("Large", Content.Load<SpriteFont>("Fonts/Large"));
            PersistentContent.AddFont("XLarge", Content.Load<SpriteFont>("Fonts/XLarge"));

            //CurrentState = new IO.SaveLoadScreen(null, false);
            //CurrentState = new Title();
            //CurrentState = new Slide.TestSlide();
            CurrentState = new Title();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (CurrentState != null)
            {
                if (this.IsActive)
                    CurrentState.Update(gameTime);
            }
            else
            {
                Properties.Settings.Default.Save();
                Exit();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if (CurrentState != null)
            {
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
                CurrentState.Draw(spriteBatch);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        // Containing code modified from: http://projectdrake.net/blog/?p=176.
        public static void SetPosition(GameWindow gameWindow, Point position)
        {
            OpenTK.GameWindow OTKWindow = GetForm(gameWindow);
            if (OTKWindow != null)
            {
                OTKWindow.X = position.X;
                OTKWindow.Y = position.Y;
            }
        }

        // Containing code modified from: http://projectdrake.net/blog/?p=176.
        public static OpenTK.GameWindow GetForm(GameWindow gameWindow)
        {
            Type type = typeof(OpenTKGameWindow);
            System.Reflection.FieldInfo field = type.GetField("window", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (field != null)
                return field.GetValue(gameWindow) as OpenTK.GameWindow;
            return null;
        }
    }
}
