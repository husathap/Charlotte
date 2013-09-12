using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.State
{

    /// <summary>
    /// A prototype for all states in the game.
    /// </summary>
    public interface State
    {
        void Update(GameTime gt);
        void Draw(SpriteBatch sb);
    }
}
