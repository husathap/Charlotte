using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Charlotte.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Charlotte.Content;
using System.Threading;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.ComponentModel;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Charlotte.Music;

namespace Charlotte.Slide
{

    /// <summary>
    /// A class that represent a slide in the game.
    /// </summary>
    public abstract class Slide : State.InitializingState
    {

        /// <summary>
        /// The loader of all textures used in the slides.
        /// </summary>
        public Texture2DLoader Texture2DLoader;

        /// <summary>
        /// The loader of all sounds used in the slides.
        /// </summary>
        public SoundEffectLoader SoundEffectLoader;

        /// <summary>
        /// The last index made by the player.
        /// </summary>
        [DefaultValue(-1)]
        public int LastSelectionIndex { get; set; }

        protected Texture2D CurrentBackground;
        protected string CurrentText = "";
        protected Selection CurrentSelection;
        protected SoundEffectInstance CurrentBackgroundMusic;

        float AlphaCounter = 1;
        float AlphaCounter2 = 0;
        float AlphaCounter3 = 0;

        /// <summary>
        /// Indicating whether the user is pressing the input key when the states
        /// are changing or not.
        /// </summary>
        bool FirstTimeInput;

        KeyboardState oldks;

        /// <summary>
        /// Get or set the next state that occurs after the slide. The default is
        /// null; which means if the slide is over, the game is over.
        /// </summary>
        [DefaultValue(null)]
        public State.State NextState { get; set; }

        /// <summary>
        /// The instructions of the slides.
        /// </summary>
        List<object> Instructions = new List<object>();

        /// <summary>
        /// The index of the instruction.
        /// </summary>
        public int InstructionIndex = 0;

        /// <summary>
        /// Add new slide instruction into the slide.
        /// </summary>
        /// <param name="Instruction">The instruction pertaining to the slide. The
        /// type of Instruction object will determine what will happen. For each supported
        /// type: 
        ///     Texture2D - Change backgroud; 
        ///     SoundEffect - Change background music;
        ///     String - Show a text; 
        ///     Selection - Ask a question; 
        ///     State - Change state;
        ///     Action - Execute a function; 
        ///     Tuple (null, T): clear something (ie, if T is Texture2D, then the texture is eliminated.)</param>
        /// <remarks>This function is equivalent to this.Instructions.Add(object).</remarks>
        public void Add(object Instruction)
        {
            Instructions.Add(Instruction);
        }

        /// <summary>
        /// A shortcut for having to put a tuple into the instructions. Equivalent to 
        /// this.Add(new Tuple<object, Type>(null, Type));
        /// </summary>
        /// <param name="Type"></param>
        public void AddRemStruct(Type Type)
        {
            Instructions.Add(new Tuple<object, Type>(null, Type));
        }

        /// <summary>
        /// The loading procedure for the slide.
        /// </summary>
        ThreadStart ResourceLoad;
        Thread LoadThread;

        /// <summary>
        /// The background texture that is being shown at the time.
        /// </summary>
        public static Texture2D BackgroundTexture;

        /// <summary>
        /// A procedure that is called after the content loading is finished. Override this to add
        /// instructions into the slide.
        /// </summary>
        public abstract void AddInstructions();

        int LoadingBarX = 0;

        /// <summary>
        /// Handle the loading section of the slide.
        /// </summary>
        /// <param name="gt"></param>
        /// <returns>True if finished loading. Otherwise, false.</returns>
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
                ResourceLoad = () =>
                {
                    try
                    {
                        if (this.Texture2DLoader != null)
                        {
                            this.Texture2DLoader.Load();
                        }

                        if (this.SoundEffectLoader != null)
                        {
                            this.SoundEffectLoader.Load();
                        }

                        AddInstructions();
                    }
                    catch
                    {
                        LoadThread.Abort();
                        Main.Quit();
                    }
                };

                LoadThread = new Thread(ResourceLoad);
                LoadThread.Start();
                return false;
            }
            else
            {
                if (LoadThread.ThreadState == ThreadState.Stopped)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Draw the loading screen.
        /// </summary>
        /// <param name="sb"></param>
        public override void DrawInitial(SpriteBatch sb)
        {
            sb.Draw(PersistentContent.GetTexture("LoadingScreen"), Main.ScreenBound, Color.White);
            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(LoadingBarX, 500,
                261, 10), Color.Red);
        }

        /// <summary>
        /// Update the slide.
        /// </summary>
        /// <param name="gt"></param>
        /// <returns></returns>
        public override bool UpdateMiddle(GameTime gt)
        {
            if (InstructionIndex >= Instructions.Count)
            {
                InstructionIndex--;
                return true;
            }
            else
            {
                if (Instructions[InstructionIndex] is Action)
                {
                    Action a = (Action)Instructions[InstructionIndex];
                    InstructionIndex++;
                    a.Invoke();
                }
                else if (Instructions[InstructionIndex] is State.State)
                {
                    Main.ChangeCurrentState((State.State)Instructions[InstructionIndex]);
                }
                else if (Instructions[InstructionIndex] is Texture2D)
                {
                    if (AlphaCounter > 0)
                    {
                        AlphaCounter -= 0.05f;
                        CurrentBackground = (Texture2D)Instructions[InstructionIndex];
                    }
                    else
                    {
                        if (UpdateWithInput())
                        {
                            AlphaCounter = 1;
                        }
                    }
                }
                else if (Instructions[InstructionIndex] is String)
                {
                    if (AlphaCounter2 < 1)
                    {
                        AlphaCounter2 += 0.1f;
                        CurrentText = WrapText(PersistentContent.GetFont("Slide"), (string)Instructions[InstructionIndex],
                            900);
                    }
                    else
                    {
                        if (UpdateWithInput())
                        {
                            CurrentText = "";
                            AlphaCounter2 = 0;
                        }
                    }
                }
                else if (Instructions[InstructionIndex] is Selection)
                {
                    if (CurrentSelection == null)
                    {
                        CurrentSelection = (Selection)Instructions[InstructionIndex];
                        if (CurrentSelection.Question != null)
                            CurrentSelection.Question = WrapText(PersistentContent.GetFont("Normal"),
                                CurrentSelection.Question, 900);
                        CurrentText = "";
                    }
                    else
                    {
                        if (AlphaCounter2 < 1)
                        {
                            AlphaCounter2 += 0.1f;
                        }
                        else
                        {
                            CurrentSelection.Update();
                            LastSelectionIndex = CurrentSelection.SelectedIndex;
                            if (UpdateWithInput())
                            {
                                CurrentSelection = null;
                                AlphaCounter2 = 0;
                            }
                        }
                    }
                }
                else if (Instructions[InstructionIndex] is SoundEffect)
                {
                    CurrentBackgroundMusic = new SoundEffectInstance(
                        (SoundEffect)Instructions[InstructionIndex]);
                    CurrentBackgroundMusic.IsLooped = false;
                    CurrentBackgroundMusic.Play();
                    InstructionIndex++;
                }
                else if (Instructions[InstructionIndex] is Soundtrack)
                {
                    Soundtrack s = (Soundtrack)Instructions[InstructionIndex];
                    s.Play(Main.SongPlayer);
                    InstructionIndex++;
                }
                else if (Instructions[InstructionIndex] is Tuple<object, Type>)
                {
                    Tuple<object, Type> t = (Tuple<object, Type>)Instructions[InstructionIndex];
                    if (t.Item1 == null)
                    {
                        if (t.Item2 == typeof(SoundEffect))
                        {
                            CurrentBackgroundMusic.Stop();
                            InstructionIndex++;
                        }
                        else if (t.Item2 == typeof(Texture2D))
                        {
                            CurrentBackground = null;
                            if (UpdateWithInput())
                            {
                                AlphaCounter = 1;
                            }
                        }
                    }
                    else
                    {
                        throw new SlideException("The slide instruction type is not supported!");
                    }
                }
                else
                {
                    throw new SlideException("The slide instruction type is not supported!");
                }
                return false;
            }
        }

        /// <summary>
        /// Update the slide when it reaches a point where an accept button is required.
        /// </summary>
        /// <returns>Returns true if the instruction index has been moved. Otherwise, returns false.</returns>
        bool UpdateWithInput()
        {
            KeyboardState ks = Keyboard.GetState();

            if (FirstTimeInput)
            {
                if (ks.IsKeyUp(Keys.Enter) && ks.IsKeyUp(Keys.Space))
                {
                    FirstTimeInput = false;
                }
            }
            else
            {
                if ((ks.IsKeyUp(Keys.Enter) && oldks.IsKeyDown(Keys.Enter)) ||
                    (ks.IsKeyUp(Keys.Space) && oldks.IsKeyDown(Keys.Space)))
                {
                    InstructionIndex++;
                    FirstTimeInput = true;

                    return true;
                }
            }

            oldks = ks;
            return false;
        }

        /// <summary>
        /// Draw whatever that the slide wants.
        /// </summary>
        /// <param name="sb"></param>
        public override void DrawMiddle(SpriteBatch sb)
        {
            if (Instructions.Count > 0)
            {
                if (CurrentBackground != null)
                {
                    sb.Draw(CurrentBackground, Main.ScreenBound, Color.White);

                    if (InstructionIndex < Instructions.Count && Instructions[InstructionIndex] is Texture2D)
                        sb.Draw(PersistentContent.GetTexture("Blank"), Main.ScreenBound, new Color(Color.Black, AlphaCounter));
                }
                else
                {
                    sb.Draw(PersistentContent.GetTexture("Blank"), Main.ScreenBound, Color.Black);
                }

                if (CurrentText != "")
                {
                    sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0,
                        (int)((Main.SCREEN_HEIGHT - PersistentContent.GetFont("Slide").MeasureString(CurrentText).Y) / 2),
                        Main.SCREEN_WIDTH, (int)PersistentContent.GetFont("Slide").MeasureString(CurrentText).Y),
                        new Color(Color.Black, 0.8f * AlphaCounter2));

                    sb.DrawString(PersistentContent.GetFont("Slide"), CurrentText,
                        new Vector2((Main.SCREEN_WIDTH - PersistentContent.GetFont("Slide").MeasureString(CurrentText).X) / 2,
                        (Main.SCREEN_HEIGHT - PersistentContent.GetFont("Slide").MeasureString(CurrentText).Y) / 2),
                        new Color(Color.White, AlphaCounter2));
                }

                if (CurrentSelection != null)
                {
                    if (CurrentSelection.Question != null || CurrentSelection.Question != "")
                    {
                        sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0, 50,
                            Main.SCREEN_WIDTH, (int)PersistentContent.GetFont("Selection").MeasureString(CurrentSelection.Question).Y),
                            new Color(Color.Black, 0.8f * AlphaCounter2));

                        sb.DrawString(PersistentContent.GetFont("Selection"), CurrentSelection.Question,
                            new Vector2((Main.SCREEN_WIDTH - PersistentContent.GetFont("Selection").MeasureString(CurrentSelection.Question).X) / 2, 50),
                            Color.White * AlphaCounter2);
                    }

                    sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0, Main.SCREEN_HEIGHT - (int)CurrentSelection.Height - 50,
                            Main.SCREEN_WIDTH, (int)CurrentSelection.Height),
                            new Color(Color.Black, 0.8f * AlphaCounter2));

                    CurrentSelection.Draw(sb, (Main.SCREEN_WIDTH - (int)CurrentSelection.Width) / 2,
                        Main.SCREEN_HEIGHT - (int)CurrentSelection.Height - 50);
                }

            }
        }

        /// <summary>
        /// Transition out from this slide to the next state.
        /// </summary>
        /// <param name="gt"></param>
        public override void UpdateFinal(GameTime gt)
        {
            if (AlphaCounter3 < 1)
            {
                AlphaCounter3 += 0.05f;
            }
            else
            {
                if (CurrentBackgroundMusic != null)
                    CurrentBackgroundMusic.Stop();
                Main.SongPlayer.Close();
                Main.ChangeCurrentState(NextState);
            }
        }

        /// <summary>
        /// Draw the transition effect.
        /// </summary>
        /// <param name="sb"></param>
        public override void DrawFinal(SpriteBatch sb)
        {
            // Continue to draw the old stuffs.
            DrawMiddle(sb);

            // Then put a cover on top of it.
            sb.Draw(PersistentContent.GetTexture("Blank"), Main.ScreenBound, Color.Black * AlphaCounter3);
        }

        // Code from: http://www.xnawiki.com/index.php/Basic_Word_Wrapping
        public string WrapText(SpriteFont spriteFont, string text, float maxLineWidth)
        {
            string[] words = text.Split(' ');
            StringBuilder sb = new StringBuilder();
            float lineWidth = 0f;
            float spaceWidth = spriteFont.MeasureString(" ").X;

            foreach (string word in words)
            {
                Vector2 size = spriteFont.MeasureString(word);

                if (lineWidth + size.X < maxLineWidth)
                {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    sb.Append("\n" + word + " ");
                    lineWidth = size.X + spaceWidth;
                }
            }

            return sb.ToString();
        }
    }
}
