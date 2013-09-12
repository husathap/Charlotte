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
    public class Scene2 : Slide
    {

        public Scene2()
        {
            this.Texture2DLoader = new Content.Texture2DLoader(Main.ContentManager.RootDirectory + "/Compressed/Scene2.zip",
                true);
        }

        public override void AddInstructions()
        {
            this.Add(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/GoFishing.dat"));
            this.Add(TemporaryContent.GetTexture("Scene2Header"));
            this.Add(TemporaryContent.GetTexture("Confrontation"));
            this.Add("Bob: Wow! The sea is empty. No fish during my way to Canada. Ah! Finally, some fish appear!");
            this.Add("Punk Fish: Finally, I\'ve been freed from the fish jail thank to a ship! Now, I am angry and evil; I am going to take you down!");
            this.Add("Bob: Chill bro!");

            this.Add(new Action(() => {this.NextState = new Level2();}));
        }
    }
}
