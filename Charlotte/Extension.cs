using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte
{
    /// <summary>
    /// A class that contains extensions for various API classes.
    /// </summary>
    public static class Extension
    {

        /// <summary>
        /// Draw a sprite.
        /// </summary>
        /// <param name="sb">The sprite batch.</param>
        /// <param name="s">The sprite to be drawn.</param>
        public static void Draw(this SpriteBatch sb, Sprite.Sprite s)
        {
            sb.Draw(s.Texture, s.Position, null, s.Color, s.Rotation, s.Origin, s.Scale, s.SpriteEffects, 1);
        }

        /// <summary>
        /// Draw a sprite with a specific color.
        /// </summary>
        /// <param name="sb">The sprite batch.</param>
        /// <param name="s">The sprite to be drawn.</param>
        /// <param name="c">The specific colour.</param>
        public static void Draw(this SpriteBatch sb, Sprite.Sprite s, Color c)
        {
            sb.Draw(s.Texture, s.Position, null, c, s.Rotation, s.Origin, s.Scale, s.SpriteEffects, 1);
        }

        /// <summary>
        /// Draw an animated sprite.
        /// </summary>
        /// <param name="sb">The sprite batch.</param>
        /// <param name="s">The sprite to be drawn.</param>
        public static void Draw(this SpriteBatch sb, Sprite.AnimatedSprite s)
        {
            sb.Draw(s.Texture, s.Position, s.CurrentFrame, s.Color, s.Rotation, s.Origin, s.Scale, s.SpriteEffects, 0);
        }

        /// <summary>
        /// Draw an animated sprite with a specific colour.
        /// </summary>
        /// <param name="sb">The sprite batch.</param>
        /// <param name="s">The sprite to be drawn.</param>
        /// /// <param name="c">The specific colour.</param>
        public static void Draw(this SpriteBatch sb, Sprite.AnimatedSprite s, Color c)
        {
            sb.Draw(s.Texture, s.Position, s.CurrentFrame, c, s.Rotation, s.Origin, s.Scale, s.SpriteEffects, 0);
        }
    }
}
