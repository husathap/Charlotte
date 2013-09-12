using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Sprite
{
    /// <summary>
    /// A class thate represents all sprite in the game.
    /// </summary>
    public class AnimatedSprite : Sprite
    {
        int FrameWidth;
        int FrameHeight;

        int row;
        int col;

        Rectangle[] frameRects;

        /// <summary>
        /// Get or set the frame index.
        /// </summary>
        [DefaultValue(0)]
        public int CurrentFrameIndex { get; set; }

        /// <summary>
        /// Get the current frame.
        /// </summary>
        public Rectangle CurrentFrame
        {
            get
            {
                return frameRects[CurrentFrameIndex];
            }
        }

        /// <summary>
        /// Get or set the wait time before the frame will be changed.
        /// </summary>
        public int WaitTime { get; set; }

        
        int loopTime = 0;
        /// <summary>
        /// Tell how many times to animation has looped.
        /// </summary>
        public int LoopTime
        {
            get
            {
                return loopTime;
            }
        }

        GameTime oldgt = new GameTime();

        int counter = 0;

        /// <summary>
        /// Update the sprite.
        /// </summary>
        public void Update()
        {
            if (counter  >= WaitTime)
            {
                CurrentFrameIndex++;

                if (CurrentFrameIndex == row * col)
                {
                    CurrentFrameIndex = 0;
                    loopTime++;
                }
                counter = 0;
            }

            counter++;
        }

        /// <summary>
        /// The origin of the sprite.
        /// </summary>
        public override Vector2 Origin
        {
            get
            {
                return new Vector2(FrameWidth / 2, FrameHeight / 2);
            }
        }

        /// <summary>
        /// A minimal intializer for the AnimatedSprite class.
        /// </summary>
        public AnimatedSprite(Texture2D Texture, int FrameWidth, int FrameHeight, int WaitTime)
        {
            this.row = Texture.Height / FrameHeight;
            this.col = Texture.Width / FrameWidth;
            this.Texture = Texture;

            this.FrameWidth = FrameWidth;
            this.FrameHeight = FrameHeight;

            frameRects = new Rectangle[row * col];

            int i = 0;
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    frameRects[i] = new Rectangle(c * FrameWidth, r * FrameHeight, FrameWidth, FrameHeight);
                    i++;
                }
            }

            this.WaitTime = WaitTime;
        }
    }
}
