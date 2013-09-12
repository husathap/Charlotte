using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Music
{
    /// <summary>
    /// Represent a path to a sound file and some other properties.
    /// </summary>
    public class Soundtrack
    {
        /// <summary>
        /// Get or set the path to the sound file.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Indicate whether the sound track will loop or not.
        /// </summary>
        public bool Looping { get; set; }

        /// <summary>
        /// Make SongPlayer s plays the soundtrack.
        /// </summary>
        /// <param name="s">The specific SongPlayer.</param>
        public void Play(SongPlayer s)
        {
            s.Close();
            s.Open(FilePath);
            s.Play(Looping);
        }

        /// <summary>
        /// Create a new soundtrack.
        /// </summary>
        /// <param name="FilePath">The path of the file to be played.</param>
        /// <param name="Looping">Indicate whether the soundtrack will loop or not.</param>
        public Soundtrack(string FilePath, bool Looping = true)
        {
            this.FilePath = FilePath;
            this.Looping = true;
        }
    }
}
