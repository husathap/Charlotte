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
    public class BossBanter2 : Slide
    {
        public BossBanter2()
        {
            this.Texture2DLoader = new Content.Texture2DLoader(Main.ContentManager.RootDirectory + "/Compressed/BossBanter2.zip",
                true);
        }

        public override void AddInstructions()
        {
            this.Add(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/SpookyVision.dat"));
            this.Add(TemporaryContent.GetTexture("Boss2Banter"));
            this.Add("Killer Klown Phish: I am GOD! And I\'ve willed myself to be out from the prison! You must worship me! I require my offering in BLOOD!");
            this.Add("Bob: It looks more like someone has smashed your fish tank rather than the other way around.");
            this.Add("Killer Klown Phish: Die infidel! You don\'t belong in this world!");
            this.Add("Bob: You are going to kill me either way? Come at me, bro!");
            this.Add(TemporaryContent.GetTexture("VS2"));

            this.Add(new Action(() => {
                this.NextState = new Boss2();
            }));
        }
    }
}
