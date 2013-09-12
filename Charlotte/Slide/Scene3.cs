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
    public class Scene3 : Slide
    {

        public Scene3()
        {
            this.Texture2DLoader = new Content.Texture2DLoader(Main.ContentManager.RootDirectory + "/Compressed/Scene3.zip",
                true);
        }

        public override void AddInstructions()
        {
            this.Add(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/GoFishing.dat"));
            this.Add(TemporaryContent.GetTexture("Scene3Header"));
            this.Add(TemporaryContent.GetTexture("AntagonistFound"));
            this.Add("Bob: Look at that nice boat!");
            this.Add("???: I am Project Poutine. I am more than a boat. I am the ultimate fish harvesting machine. Not only that, I am equipped with the state-of-the-art SONAR, high resolution GPS and the ISO-inspired management systems. I am also prepped to pleasure as well as for serious duty with 24/7 Internet, movie theaters and Turkish baths...");
            this.Add("Bob: Shut up! So you\'re that thingie that I have to break to rescue everyone.");
            this.Add("Project Poutine: Yes, but it won\'t be easy! Project Poutine Peripheries, go take down that stubborn fish!");

            this.Add(new Action(() => {
                this.NextState = new Level3();
            }));
        }
    }
}
