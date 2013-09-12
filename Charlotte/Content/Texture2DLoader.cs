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
    /// A class that loads image files or soundtrack files that have been compressed.
    /// It decompresses a zip package, loads up a content and wipe any decompressed file.
    /// The content is then stored in a temporary cache. However, they can be pooled.
    /// </summary>
    public class Texture2DLoader : Loader
    {
        /// <summary>
        /// Load a compressed content file.
        /// </summary>
        /// <param name="Temporary">If true, then load the files into Temporary Content. Otherwise,
        /// load the content into Persistent Content</param>
        public override void Load()
        {
            lock (this)
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
                        if (!TemporaryContent.HasTexture(Name))
                        {
                            TemporaryContent.AddTexture(Name, Texture2D.FromStream(Main.GraphicsDevice, fs));
                        }
                    }
                    else
                    {
                        if (!PersistentContent.HasTexture(Name))
                        {
                            PersistentContent.AddTexture(Name, Texture2D.FromStream(Main.GraphicsDevice, fs));
                        }
                    }

         
                    fs.Close();
                }

                Directory.Delete("../../Temp/", true);
                finished = true;
            }
        }

        /// <summary>
        /// Create a new Loader.
        /// </summary>
        /// <param name="Path">The path of the compressed content file.</param>
        public Texture2DLoader(string Path, bool Temporary)
        {
            this.FilePath = Path;
            this.Temporary = Temporary;
        }

    }
}
