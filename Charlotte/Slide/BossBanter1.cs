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
    public class BossBanter1 : Slide
    {
        public BossBanter1()
        {
            this.Texture2DLoader = new Content.Texture2DLoader(Main.ContentManager.RootDirectory + "/Compressed/BossBanter1.zip",
                true);
        }

        public override void AddInstructions()
        {
            this.Add(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/Bedsheet.dat"));
            this.Add(PersistentContent.GetTexture("Blank"));
            this.Add("???: To survive, you must face your worst nightmare!");
            this.Add(TemporaryContent.GetTexture("VS1"));

            this.Add(new Action(() => {
                this.NextState = new Boss1();
            }));
        }
    }
}
