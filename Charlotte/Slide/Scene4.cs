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
    public class Scene4 : Slide
    {

        public Scene4()
        {
            this.Texture2DLoader = new Content.Texture2DLoader(Main.ContentManager.RootDirectory + "/Compressed/Scene4.zip",
                true);
        }

        public override void AddInstructions()
        {
            this.Add(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/GoFishing.dat"));
            this.Add(TemporaryContent.GetTexture("Scene4Header"));
            this.Add(TemporaryContent.GetTexture("GreatJob"));
            this.Add("Bob: Now, I\'ve rescued everyone.");
            this.Add("Everyone: Let\'s go home!");
            this.Add(TemporaryContent.GetTexture("PoleSwitched"));
            this.Add("Unbeknownst to all fish, destroying Project Poutine has a huge ramification for Earth. The destruction of Project Poutine has caused an unfathomable amount of damage on the Earth\'s magnetic poles causing the North pole and the South pole to switch rapidly.");
            this.Add("Many humans have died from the disasters following the magnetic pole shift and many supernatural, and simply weird phenomena happen. However, for most fish, things are looking good. With less human to hunt them down, the fishkind will thrive.");
            this.Add("However, for Bob the Fish and his fish parade will still need to face an oddity caused by the sudden pole shift before they can leave Canada.");
            this.Add(TemporaryContent.GetTexture("ThisIsMyStory"));
            this.Add("The exodus of fish are stopped by some weird texts. Only Bella understands the text because she used to be a human.");
            this.Add("Bob: What are these?");
            this.Add("Bella: These are English words. They describe the life of a person... And they are depressing... I feel so bad for the person...");
            this.Add("Bob: Who cares! Look! This game is supposed to be light-hearted. There\'s a ship called Project Poutine for crying out loud! This is not some depressing, pseudo-philosophical game.");
            this.Add("Bella: Please don\'t destroy the text at least! This message may mean something to other people.");
            this.Add(TemporaryContent.GetTexture("MyStoryHurts"));
            this.Add("Bella: Ouch! These texts actually hurt. I lost 10 HP for touching it! And my HP is not that high! And they are blocking our ways. How obnoxious!");
            this.Add("Bob: We are on the same page then!");

            this.Add(new Action(() => {
                this.NextState = new Level4();
            }));
        }
    }
}
