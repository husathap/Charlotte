using Charlotte.Content;
using Charlotte.Slide;
using Charlotte.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.IO
{
    public class SaveLoadScreen : InitializingState
    {
        Selection LogsSelection;

        State.State NextState;

        /// <summary>
        /// Indicate whether the game is saving or loading. True if the game is saving. Otherwise, the game is loading.
        /// </summary>
        bool SaveMode;

        float alpha = 0;

        public override bool UpdateInitial(GameTime gt)
        {
            if (alpha < 1)
            {
                alpha += 0.02f;
            }
            return alpha >= 1;
        }

        public override void DrawInitial(SpriteBatch sb)
        {
            sb.Draw(PersistentContent.GetTexture("SaveLoad"), Main.ScreenBound, Color.White);
            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0, (int)(Main.SCREEN_HEIGHT - LogsSelection.Height - 30),
                Main.SCREEN_WIDTH, (int)LogsSelection.Height), new Color(Color.Black, 0.8f * alpha));
            LogsSelection.Draw(sb, 0, (int)(Main.SCREEN_HEIGHT - LogsSelection.Height - 30));

            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0, 30, Main.SCREEN_WIDTH,
                PersistentContent.GetFont("Selection").LineSpacing), new Color(Color.Black, 0.8f * alpha));

            if (SaveMode)
            {
                sb.DrawString(PersistentContent.GetFont("Selection"), "Select a Log to Save to", new Vector2(10, 30),
                    new Color(Color.White, alpha));
            }
            else
            {
                sb.DrawString(PersistentContent.GetFont("Selection"), "Select a Log to Begin/Continue from", new Vector2(10, 30),
                    new Color(Color.White, alpha));
            }
        }

        public override bool UpdateMiddle(GameTime gt)
        {
            LogsSelection.Update();

            if (LogsSelection.Selected)
            {
                if (SaveMode)
                {
                    return true;
                }
                else
                {
                    if (LogsSelection.SelectedIndex >= 8 ||
                       Properties.Settings.Default.Logs[LogsSelection.SelectedIndex] != "0")
                    {
                        return true;
                    }
                    else
                    {
                        LogsSelection.Selected = false;
                    }
                }
            }

            return false;
        }

        public override void DrawMiddle(SpriteBatch sb)
        {
            sb.Draw(PersistentContent.GetTexture("SaveLoad"), Main.ScreenBound, Color.White);
            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0, (int)(Main.SCREEN_HEIGHT - LogsSelection.Height - 30),
                Main.SCREEN_WIDTH, (int)LogsSelection.Height), new Color(Color.Black, 0.8f));
            LogsSelection.Draw(sb, 0, (int)(Main.SCREEN_HEIGHT - LogsSelection.Height - 30));

            sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0, 30, Main.SCREEN_WIDTH, 
                PersistentContent.GetFont("Selection").LineSpacing), new Color(Color.Black, 0.8f));

            if (SaveMode)
            {
                sb.DrawString(PersistentContent.GetFont("Selection"), "Select a Log to Save to", new Vector2(10, 30), Color.White);

                if (LogsSelection.SelectedIndex < 8 &&
                    Properties.Settings.Default.Logs[LogsSelection.SelectedIndex] != "0")
                {
                    sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0, 30 + PersistentContent.GetFont("Selection").LineSpacing,
                        Main.SCREEN_WIDTH, PersistentContent.GetFont("Selection").LineSpacing), Color.White);
                    sb.DrawString(PersistentContent.GetFont("Selection"), "Warning: Overwriting will occur!",
                        new Vector2(10, 30 + PersistentContent.GetFont("Selection").LineSpacing), Color.Red);
                }
            }
            else
            {
                sb.DrawString(PersistentContent.GetFont("Selection"), "Select a Log to Begin/Continue from", new Vector2(10, 30), Color.White);

                if (LogsSelection.SelectedIndex == 8)
                {
                    sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0, 30 + PersistentContent.GetFont("Selection").LineSpacing,
                        Main.SCREEN_WIDTH, PersistentContent.GetFont("Selection").LineSpacing), Color.White);
                    sb.DrawString(PersistentContent.GetFont("Selection"), "Warning: Only for crash recovery!",
                        new Vector2(10, 30 + PersistentContent.GetFont("Selection").LineSpacing), Color.Red);
                }
                else if (LogsSelection.SelectedIndex < 8)
                {
                    if (Properties.Settings.Default.Logs[LogsSelection.SelectedIndex] == "0")
                    {
                        sb.Draw(PersistentContent.GetTexture("Blank"), new Rectangle(0, 30 + PersistentContent.GetFont("Selection").LineSpacing,
                        Main.SCREEN_WIDTH, PersistentContent.GetFont("Selection").LineSpacing), Color.White);
                        sb.DrawString(PersistentContent.GetFont("Selection"), "Warning: An empty log cannot be loaded.",
                            new Vector2(10, 30 + PersistentContent.GetFont("Selection").LineSpacing), Color.Red);
                    }
                }
            }
        }

        public override void UpdateFinal(GameTime gt)
        {
            if (SaveMode)
            {
                if (LogsSelection.SelectedIndex >= 0 && LogsSelection.SelectedIndex <= 7)
                {
                    Properties.Settings.Default.Logs[LogsSelection.SelectedIndex] =
                        Properties.Settings.Default.Temp;
                    Properties.Settings.Default.Save();
                }

                Main.ChangeCurrentState(this.NextState);
            }
            else
            {
                //TODO: Add navigational code here.
                if (LogsSelection.SelectedIndex >= 0 && LogsSelection.SelectedIndex <= 7)
                {
                    switch (Properties.Settings.Default.Logs[LogsSelection.SelectedIndex])
                    {
                        case "Scene II":
                            this.NextState = new Scene2();
                            break;
                        case "Scene II - Boss":
                            this.NextState = new BossBanter2();
                            break;
                        case "Scene III":
                            this.NextState = new Scene3();
                            break;
                        case "Scene III - Boss":
                            this.NextState = new BossBanter3();
                            break;
                        case "Scene IV":
                            this.NextState = new Scene4();
                            break;
                        case "Scene IV - Boss":
                            this.NextState = new BossBanter4();
                            break;
                    }
                }

                Main.ChangeCurrentState(this.NextState);
            }
        }

        public override void DrawFinal(SpriteBatch sb)
        {
        }

        /// <summary>
        /// Create a new Load/Save Screen.
        /// </summary>
        /// <param name="NextState">Depending whether the game is loading or saving.
        /// If the game is loading, then the it is the state the game will go to if the operation is cancelled.
        /// If the game is saving, this state will be reached regardless.</param>
        /// <param name="SaveMode">True for saving, false for loading.</param>
        public SaveLoadScreen(State.State NextState, bool SaveMode)
        {
            this.NextState = NextState;
            this.SaveMode = SaveMode;

            if (SaveMode)
            {
                LogsSelection = new Selection(50, 130, new string[] {
                    "1: ", "2: ", "3: ", "4: ", "5: ", "6: ", "7: ", "8: ", "Cancel"});
            }
            else
            {
                LogsSelection = new Selection(50, 130, new string[] {
                    "1: ", "2: ", "3: ", "4: ", "5: ", "6: ", "7: ", "8: ", "Autosave", "Cancel"});
            }

            for (int i = 0; i < 8; i++)
            {
                if (Properties.Settings.Default.Logs[i] == "0")
                {
                    LogsSelection.Choices[i] += "-";
                }
                else
                {
                    LogsSelection.Choices[i] += Properties.Settings.Default.Logs[i];
                }
            }
        }
    }
}
