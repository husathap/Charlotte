using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Content
{
    public abstract class Loader
    {
        /// <summary>
        /// True if finished loading.
        /// </summary>
        protected bool finished;

        /// <summary>
        /// Indicate whether the compressed loader is done or not. This is useful for multithreading.
        /// </summary>
        public bool Finished
        {
            get { return finished; }
        }

        /// <summary>
        /// Indicate whether the compressed will load content into Persistent Content or Temporary Content.
        /// True to load to Temporary Content; otherwise, the content will go into Persistent Content.
        /// </summary>
        public bool Temporary { get; set; }

        /// <summary>
        /// The path of the compressed content file.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Load the compressed folder into either Persistent Content or Temporary Content depending on
        /// Temporary variable.
        /// </summary>
        public abstract void Load();
    }
}
