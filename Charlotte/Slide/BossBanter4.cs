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
    public class BossBanter4 : Slide
    {
        public BossBanter4()
        {
            this.Texture2DLoader = new Content.Texture2DLoader(Main.ContentManager.RootDirectory + "/Compressed/BossBanter4.zip",
                true);
        }

        public override void AddInstructions()
        {
            this.Add(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/NoClubbing.dat"));
            this.Add(TemporaryContent.GetTexture("AlmostThere"));
            this.Add("Bob: OK, that was obnoxious. I was supposed to feel emotional, but with images ripped from Wikipedia, it was hard to take those garbages seriously. Anyway, we should be out from the Canadian waterspace soon.");
            this.Add(TemporaryContent.GetTexture("OhNo"));
            this.Add("Mutant Baby Harp Seal: Hahaha! I like fish. I\'m going to eat you all!");
            this.Add("Bob: I taste like maple bacon jam. Come at me, bro!");
            this.Add(TemporaryContent.GetTexture("VS4"));

            this.Add(new Action(() => {
                this.NextState = new Boss4();
            }));
        }
    }
}
