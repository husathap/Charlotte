using Charlotte.Content;
using Charlotte.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte 
{
    public class Test : State.State
    {
        Selection test;
        AnimatedSprite AS;

        List<Tuple<string, int, string>> testTuple = new List<Tuple<string, int, string>>();

        public void Update(GameTime gt)
        {
            test.Update();
            AS.Update();
        }

        public void Draw(SpriteBatch sb)
        {
            test.Draw(sb);
            sb.Draw(AS);
        }

        public Test(GraphicsDevice gd)
        {
            test = new Selection(0, 0, new string[] { "Duck", "Fillet", "I just want to get out of here!", "LALA"},
            "Testington");
            Texture2DLoader tl = new Texture2DLoader(Main.ContentManager.RootDirectory + "/test.zip", true);
            tl.Load();
            AS = new AnimatedSprite(TemporaryContent.GetTexture("dragon"), 40, 40, 100);

            AS.Position = new Vector2(300, 300);
        }
    }
}
