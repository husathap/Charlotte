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
    public class BossBanter3 : Slide
    {
        public BossBanter3()
        {
            this.Texture2DLoader = new Content.Texture2DLoader(Main.ContentManager.RootDirectory + "/Compressed/BossBanter3.zip",
                true);
        }

        public override void AddInstructions()
        {
            this.Add(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/CheeseCurd.dat"));
            this.Add(TemporaryContent.GetTexture("AntagonistEngaged"));
            this.Add("Project Poutine: What? Impossible!");
            this.Add("Bob: Wow! You look smaller than I thought you\'d be!");
            this.Add("Project Poutine: I have the Special Physical Space Modification System which allows me to appear small. This is to avoid the Canadian Navy.");
            this.Add("Bob: So your plan is to be stealthy, huh? Then how come a random girl managed to get on board and send a broadcast?");
            this.Add("Project Poutine: Shut up! I have enough of you! I\'ll turn you into a frozen fish fillet!");
            this.Add(TemporaryContent.GetTexture("VS3"));

            this.Add(new Action(() => {
                this.NextState = new Boss3();
            }));
        }
    }
}
