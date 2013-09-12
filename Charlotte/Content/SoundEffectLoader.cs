using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using Microsoft.Xna.Framework.Audio;

namespace Charlotte.Content
{
    /// <summary>
    /// A class that loads soundtrack files that have been compressed.
    /// It decompresses a zip package, loads up a content and wipe any decompressed file off.
    /// The loaded soundtracks are stored in its own cache; however, they can be shared through
    /// Pool.
    /// </summary>
    public class SoundEffectLoader : Loader
    {
        /// <summary>
        /// Load a compressed content file into either Persistent Content or Temporary Content.
        /// </summary>
        /// <param name="Temporary">If true, then load the files into Temporary Content. Otherwise,
        /// load the content into Persistent Content</param>
        public override void Load()
        {
            string TempPath = "../../Temp/" + Path.GetFileNameWithoutExtension(FilePath);
            ZipFile.ExtractToDirectory(FilePath, TempPath);

            DirectoryInfo di = new DirectoryInfo(TempPath);
            FileInfo[] fi = di.GetFiles();

            foreach (FileInfo f in fi)
            {
                string Name = Path.GetFileNameWithoutExtension(f.FullName);
                FileStream fs = File.OpenRead(TempPath + "/" + f.Name);

                if (Temporary)
                {
                    if (!TemporaryContent.HasSFX(Name))
                    {
                        TemporaryContent.AddSFX(Name, SoundEffect.FromStream(fs));
                    }
                }
                else
                {
                    if (!PersistentContent.HasSFX(Name))
                    {
                        PersistentContent.AddSFX(Name, SoundEffect.FromStream(fs));
                    }
                }
                fs.Close();

            }

            Directory.Delete("../../Temp/", true);
            finished = true;
        }

        /// <summary>
        /// Create a new Loader.
        /// </summary>
        /// <param name="Path">The path of the compressed content file.</param>
        public SoundEffectLoader(string Path, bool Temporary)
        {
            this.FilePath = Path;
            this.Temporary = Temporary;
        }
    }
}
