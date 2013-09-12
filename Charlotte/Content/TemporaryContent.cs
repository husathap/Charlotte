using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Charlotte.Music;


namespace Charlotte.Content
{
    /// <summary>
    /// This class holds content that only lasts one state of the game. The content added here
    /// will be removed if the state has changed.
    /// </summary>
    public static class TemporaryContent
    {
        static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();
        static Dictionary<string, SpriteFont> Fonts = new Dictionary<string, SpriteFont>();
        static Dictionary<string, SoundEffect> SoundEffects = new Dictionary<string, SoundEffect>();
        static Dictionary<string, Song> Songs = new Dictionary<string, Song>();
        static Dictionary<string, Video> Videos = new Dictionary<string, Video>();
        static Dictionary<string, Soundtrack> Soundtracks = new Dictionary<string, Soundtrack>();

        #region "Get methods"
        /// <summary>
        /// Get a Texture2D from Persistent Content.
        /// </summary>
        /// <param name="Name">The name of the texture</param>
        /// <returns></returns>
        public static Texture2D GetTexture(string Name)
        {
            return Textures[Name];
        }

        /// <summary>
        /// Get a SpriteFont from Persistent Content.
        /// </summary>
        /// <param name="Name">The name of the font.</param>
        /// <returns></returns>
        public static SpriteFont GetFont(string Name)
        {
            return Fonts[Name];
        }

        /// <summary>
        /// Get a SoundEffect from Persistent Content.
        /// </summary>
        /// <param name="Name">The name of the SoundEffect.</param>
        /// <returns></returns>
        public static SoundEffect GetSFX(string Name)
        {
            return SoundEffects[Name];
        }

        /// <summary>
        /// Get a Song from Persistent Content.
        /// </summary>
        /// <param name="Name">The name of the Song.</param>
        /// <returns></returns>
        public static Song GetSong(string Name)
        {
            return Songs[Name];
        }

        /// <summary>
        /// Get a Video from Persistent Content.
        /// </summary>
        /// <param name="Name">The name of the Video.</param>
        /// <returns></returns>
        public static Video GetVideo(string Name)
        {
            return Videos[Name];
        }

        /// <summary>
        /// Get a Soundtrack from Persistent Content.
        /// </summary>
        /// <param name="Name">The name of the Soundtrack.</param>
        /// <returns></returns>
        public static Soundtrack GetSoundtrack(string Name)
        {
            return Soundtracks[Name];
        }

        #endregion

        #region "Has methods"
        /// <summary>
        /// Check to see if a certain Texture2D exsits or not.
        /// </summary>
        /// <param name="Name">The name of the Texture2D</param>
        /// <returns>True if the Texture2D exists, otherwise, false.</returns>
        public static bool HasTexture(string Name)
        {
            return Textures.ContainsKey(Name);
        }

        /// <summary>
        /// Check to see if a certain SpriteFont exsits or not.
        /// </summary>
        /// <param name="Name">The name of the SpriteFont</param>
        /// <returns>True if the SpriteFont exists, otherwise, false.</returns>
        public static bool HasSpriteFont(string Name)
        {
            return Fonts.ContainsKey(Name);
        }

        /// <summary>
        /// Check to see if a certain SoundEffect exsits or not.
        /// </summary>
        /// <param name="Name">The name of the SoundEffect.</param>
        /// <returns>True if the SoundEffect exists, otherwise, false.</returns>
        public static bool HasSFX(string Name)
        {
            return SoundEffects.ContainsKey(Name);
        }

        /// <summary>
        /// Check to see if a certain Song exsits or not.
        /// </summary>
        /// <param name="Name">The name of the Song.</param>
        /// <returns>True if the Song exists, otherwise, false.</returns>
        public static bool HasSong(string Name)
        {
            return Songs.ContainsKey(Name);
        }

        /// <summary>
        /// Check to see if a certain Video exsits or not.
        /// </summary>
        /// <param name="Name">The name of the Video.</param>
        /// <returns>True if the Video exists, otherwise, false.</returns>
        public static bool HasVideo(string Name)
        {
            return Videos.ContainsKey(Name);
        }

        /// <summary>
        /// Check to see if a certain Soundtrack exsits or not.
        /// </summary>
        /// <param name="Name">The name of the Soundtrack.</param>
        /// <returns>True if the Soundtrack exists, otherwise, false.</returns>
        public static bool HasSoundtrack(string Name)
        {
            return Soundtracks.ContainsKey(Name);
        }

        #endregion

        #region "Add methods"

        /// <summary>
        /// Add a new Texture2D into Persistent Content.
        /// </summary>
        /// <param name="Name">The name of the Texture2D.</param>
        /// <param name="Texture">The Texture2D itself.</param>
        public static void AddTexture(string Name, Texture2D Texture)
        {
            Textures.Add(Name, Texture);
        }

        /// <summary>
        /// Add a new SpriteFont into Persistent Content.
        /// </summary>
        /// <param name="Name">The name of the SpriteFont.</param>
        /// <param name="Font">The SpriteFont itself.</param>
        public static void AddFont(string Name, SpriteFont Font)
        {
            Fonts.Add(Name, Font);
        }

        /// <summary>
        /// Add a new SoundEffect into Persistent Content.
        /// </summary>
        /// <param name="Name">The name of the SoundEffect.</param>
        /// <param name="SFX">The SoundEffect itself.</param>
        public static void AddSFX(string Name, SoundEffect SFX)
        {
            SoundEffects.Add(Name, SFX);
        }

        /// <summary>
        /// Add a new Song into Persistent Content.
        /// </summary>
        /// <param name="Name">The name of the Song.</param>
        /// <param name="Song">The Song itself.</param>
        public static void AddSong(string Name, Song Song)
        {
            Songs.Add(Name, Song);
        }

        /// <summary>
        /// Add a new Video into Persistent Content.
        /// </summary>
        /// <param name="Name">The name of the Video.</param>
        /// <param name="Video">The Video itself.</param>
        public static void AddVideo(string Name, Video SFX)
        {
            Videos.Add(Name, SFX);
        }

        /// <summary>
        /// Add a new Soundtrack into Persistent Content.
        /// </summary>
        /// <param name="Name">The name of the Video.</param>
        /// <param name="Soundtrack">The Soundtrack itself.</param>
        public static void AddSoundtrack(string Name, Soundtrack Soundtrack)
        {
            Soundtracks.Add(Name, Soundtrack);
        }

        #endregion

        /// <summary>
        /// Clear all contents.
        /// </summary>
        public static void Clear()
        {
            Textures.Clear();
            Fonts.Clear();
            SoundEffects.Clear();
            Songs.Clear();
            Videos.Clear();
        }
    }
}
