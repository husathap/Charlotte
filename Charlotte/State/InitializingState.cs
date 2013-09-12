using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charlotte.State
{

    /// <summary>
    /// A prototype of all states that have initialization and final phases. The state has 3 update methods:
    /// UpdateInitial, UpdateMiddle and UpdateFinal. UpdateInitial is for the preparation of the state. It
    /// returns True once it is done with its initializing logic. UpdateMiddle is for normal operation of the
    /// state and return True when the state is coming to an end. UpdateFinal is for clear up the current state
    /// and moving to the next one.
    /// </summary>
    public abstract class InitializingState : State
    {
        public enum Stage
        {
            Initial,
            Middle,
            Final
        }

        Stage currentStage = Stage.Initial;

        /// <summary>
        /// The current of stage of the state. The state will change once a resonspible function
        /// returns true.
        /// </summary>
        public Stage CurrentStage
        {
            get { return currentStage;}
        }

        public abstract bool UpdateInitial(GameTime gt);
        public abstract void DrawInitial(SpriteBatch sb);
        public abstract bool UpdateMiddle(GameTime gt);
        public abstract void DrawMiddle(SpriteBatch sb);
        public abstract void UpdateFinal(GameTime gt);
        public abstract void DrawFinal(SpriteBatch sb);

        /// <summary>
        /// Update the state.
        /// </summary>
        /// <param name="gt"></param>
        public void Update(GameTime gt)
        {
            switch (currentStage)
            {
                case Stage.Initial:
                    if (UpdateInitial(gt))
                        currentStage = Stage.Middle;
                    break;
                case Stage.Middle:
                    if (UpdateMiddle(gt))
                        currentStage = Stage.Final;
                    break;
                default:
                    UpdateFinal(gt);
                    break;
            }
        }

        /// <summary>
        /// Draw the state.
        /// </summary>
        /// <param name="sb"></param>
        public void Draw(SpriteBatch sb)
        {
            switch (currentStage)
            {
                case Stage.Initial:
                    DrawInitial(sb);
                    break;
                case Stage.Middle:
                    DrawMiddle(sb);
                    break;
                default:
                    DrawFinal(sb);
                    break;
            }
        }

    }
}
