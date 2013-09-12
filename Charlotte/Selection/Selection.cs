using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte
{

    /// <summary>
    /// A class that represents the decision component in the game.
    /// </summary>
    public class Selection
    {

        string[] choices;

        /// <summary>
        /// The choices that the player can make.
        /// </summary>
        public string[] Choices
        {
            get
            {
                return choices;
            }
            set
            {
                choices = value;
                AdjustWidth();
            }
        }

        /// <summary>
        /// Adjust the width of the selection.
        /// </summary>
        private void AdjustWidth()
        {
            width = SelectionFont.MeasureString(Choices[0]).X;

            // Find the longest line
            if (Choices.Length > 1)
            {
                int i = 1;
                while (i < Choices.Length)
                {
                    float tempWidth = SelectionFont.MeasureString(Choices[i]).X;

                    if (tempWidth > width)
                    {
                        width = tempWidth;
                    }

                    i++;
                }
            }

            width += 30; // Padding
        }

        /// <summary>
        /// The X coordinate of the selection box.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The Y coordinate of the selection box.
        /// </summary>
        public int Y { get; set; }

        float width;
        float IndividualHeight;

        public Color Color1 { get; set; }
        public Color Color2 { get; set; }

        /// <summary>
        /// The topic/question of the selection.
        /// </summary>
        public string Question;

        /// <summary>
        /// The width of the selection box.
        /// </summary>
        public float Width
        {
            get { return width; }
        }

        /// <summary>
        /// The height of the selection box.
        /// </summary>
        public float Height
        {
            get { return IndividualHeight * Choices.Length; }
        }

        /// <summary>
        /// The name of the Selection. This is useful for a decision tree or a decision path data structure.
        /// </summary>
        public string Name { get; set; }

        bool selected;

        /// <summary>
        /// Indicate whether the player has already made a decision or not.
        /// </summary>
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        /// <summary>
        /// Get or set the data structure that is responsible for the path.
        /// </summary>
        public List<Tuple<string, int, string>> AssociatedPath;

        static Texture2D SelectionTexture;
        static SpriteFont SelectionFont;

        /// <summary>
        /// The index of the selection choice.
        /// </summary>
        public int SelectedIndex;

        KeyboardState oldks;
        int counter1 = 0;
        int counter2 = 0;
        int counter3 = 0;
        int counter4 = 0;

        /// <summary>
        /// Update the selection box.
        /// </summary>
        public void Update()
        {
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyUp(Keys.Up) && oldks.IsKeyDown(Keys.Up))
            {
                SelectedIndex--;

                if (SelectedIndex == -1)
                    SelectedIndex = Choices.Length - 1;
            }

            if (ks.IsKeyUp(Keys.Down) && oldks.IsKeyDown(Keys.Down))
            {
                SelectedIndex++;

                if (SelectedIndex == Choices.Length)
                {
                    SelectedIndex = 0;
                }
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                if (counter1 < 60)
                {
                    counter1++;
                }
                else
                {
                    if (counter2 < 5)
                    {
                        counter2++;
                    }
                    else
                    {
                        SelectedIndex--;

                        if (SelectedIndex == -1)
                            SelectedIndex = Choices.Length - 1;
                        counter2 = 0;
                    }
                }
            }
            if (ks.IsKeyUp(Keys.Up))
            {
                counter1 = 0;
                counter2 = 0;
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                if (counter3 < 60)
                {
                    counter3++;
                }
                else
                {
                    if (counter4 < 5)
                    {
                        counter4++;
                    }
                    else
                    {
                        SelectedIndex++;

                        if (SelectedIndex == Choices.Length)
                            SelectedIndex = 0;
                        counter4 = 0;
                    }
                }
            }
            if (ks.IsKeyUp(Keys.Down))
            {
                counter3 = 0;
                counter4 = 0;
            }

            if ((ks.IsKeyUp(Keys.Enter) && oldks.IsKeyDown(Keys.Enter)) ||
                (ks.IsKeyUp(Keys.Space) && oldks.IsKeyDown(Keys.Space)))
            {
                selected = true;
                if (AssociatedPath != null)
                    AssociatedPath.Add(new Tuple<string,int,string>(Name, SelectedIndex, Choices[SelectedIndex]));
            }

            oldks = ks;
        }

        /// <summary>
        /// Draw the selection box.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            AdjustWidth();

            int i = 0;
            while (i < Choices.Length)
            {
                if (SelectedIndex != i)
                    sb.DrawString(SelectionFont, Choices[i], new Vector2(X + 23, Y + IndividualHeight * i), Color1);
                else
                {
                    sb.Draw(SelectionTexture, new Rectangle(X, Y + (int)IndividualHeight * i, (int)width, (int)IndividualHeight), Color1);
                    sb.DrawString(SelectionFont, Choices[i], new Vector2(X + 8, Y + IndividualHeight * (i)), Color2);
                }
                i++;
            }
        }

        /// <summary>
        /// Draw the selection box with a new position.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb, int NewX, int NewY)
        {
            AdjustWidth();

            int i = 0;
            while (i < Choices.Length)
            {
                if (SelectedIndex != i)
                    sb.DrawString(SelectionFont, Choices[i], new Vector2(NewX + 23, NewY + IndividualHeight * i), Color1);
                else
                {
                    sb.Draw(SelectionTexture, new Rectangle(NewX, NewY + (int)IndividualHeight * i, (int)width, (int)IndividualHeight), Color1);
                    sb.DrawString(SelectionFont, Choices[i], new Vector2(NewX + 8, NewY + IndividualHeight * (i)), Color2);
                }
                i++;
            }
        }

        /// <summary>
        /// Load all contents to be used by all selections.
        /// </summary>
        public static void LoadSelectionContent(GraphicsDevice gd, ContentManager Content)
        {
            Selection.SelectionFont = Content.Load<SpriteFont>("Fonts/Selection");
            Selection.SelectionTexture = new Texture2D(gd, 1, 1, false, SurfaceFormat.Color);
            Selection.SelectionTexture.SetData(new[] { Color.White });
        }

        public Selection(int X, int Y, string[] Choices, string Name = "", string Question = "",  List<Tuple<string, int, string>> AssociatedPath = null)
        {
            this.X = X;
            this.Y = Y;
            this.Choices = Choices;
            this.SelectedIndex = 0;
            this.Name = Name;
            this.AssociatedPath = AssociatedPath;
            this.Question = Question;

            AdjustWidth();

            IndividualHeight = SelectionFont.LineSpacing;

            Color1 = Color.White;
            Color2 = Color.Black;
        }

        public Selection(int X, int Y, string[] Choices, Color Color1, Color Color2, string Name = "", string Question = "", List<Tuple<string, int, string>> AssociatedPath = null)
        {
            this.X = X;
            this.Y = Y;
            this.Choices = Choices;
            this.SelectedIndex = 0;
            this.Name = Name;
            this.AssociatedPath = AssociatedPath;
            this.Question = Question;

            AdjustWidth();

            IndividualHeight = SelectionFont.LineSpacing;

            this.Color1 = Color1;
            this.Color2 = Color2;
           
        }
    }
}
