using Charlotte.Content;
using Charlotte.IO;
using Charlotte.Music;
using Charlotte.Shooter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Slide
{
    public class Ending : Slide
    {

        public Ending()
        {
            this.Texture2DLoader = new Content.Texture2DLoader(Main.ContentManager.RootDirectory + "/Compressed/Ending.zip",
                true);
        }

        public override void AddInstructions()
        {
            this.Add(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/GoFishing.dat"));
            this.Add(TemporaryContent.GetTexture("GoodToGo"));
            this.Add("Bella: No more hindrance?");
            this.Add("Bob: Don't jinx it!");
            this.Add("Finally, the exodus of fish can leave the Canadian water. And they should be living more happily ever after since now, the mankind is suffering the polar shift. But a question remains:");
            this.Add(TemporaryContent.GetTexture("WhoIsThis"));
            this.Add("Who is that character in the tutorial section?");
            this.Add("Bob: I don\'t care. I\'m more irked by the fact that the final boss is a sprite from Wikipedia!");
            this.Add(TemporaryContent.GetTexture("Credits"));

            this.Add(new Action(() => {
                this.NextState = new Title();
            }));
        }
    }
}
