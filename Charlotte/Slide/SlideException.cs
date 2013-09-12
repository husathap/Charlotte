using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Slide
{
    /// <summary>
    /// An exception thrown when there is something wrong in the slide processing.
    /// </summary>
    public class SlideException : Exception
    {
        /// <summary>
        /// Create a new SlideException.
        /// </summary>
        /// <param name="Message">The message of the exception.</param>
        public SlideException(string Message)
            : base(Message)
        {
        }
    }
}
