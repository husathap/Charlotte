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
    public class Scene1 : Slide
    {

        public Scene1()
        {
            this.Texture2DLoader = new Content.Texture2DLoader(Main.ContentManager.RootDirectory + "/Compressed/Scene1.zip",
                true);
        }

        public override void AddInstructions()
        {
            this.Add(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/GoFishing.dat"));
            this.Add(TemporaryContent.GetTexture("Scene1Header"));
            this.Add(TemporaryContent.GetTexture("Peace"));
            this.Add("After the event of the first game, the Sea of Japan is saved from any fishing activity. Mutant fish in the sea are now living in peace. However, in many parts of the world, fish are still suffering. One human girl wants to save the fish and so she has sent a message throughout the sea.");
            this.Add("The message says:");
            this.Add(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/Troublesome.dat"));
            this.Add(TemporaryContent.GetTexture("Transmission"));
            this.Add("Girl: And here is the definite proof of Project Poutine, the world\'s most fearsome fish harvesting equipment. I am relaying this to the Canadian Navy and for everyone on Earth to hear.");
            this.Add("Man: An intruder, eh?");
            this.Add("Girl: Oh no! I\'ve been caught.");
            this.Add("Man: Well well well! I\'m sorry that it has to come to this. Patrick, prepare the Kitty Gun!");
            this.Add("Patrick: Yes, boss. I won\'t screw up again this time!");
            this.Add("Girl: What am I becoming?");
            this.Add("Patrick: I\'m sorry. You are about to become a kitten. Every ship needs a kitten, you see. Do you like them cats, eh?");
            this.Add("Man: This is not a cat! Your gun has created another lame mutated cat thing!");
            this.Add("Patrick: Eh? I\'m sorry.");
            this.Add("Man: Throw this one overboard too, fella. I\'m sorry, kitty!");
            this.Add("Patrick: Sorry.");
            this.Add("Man: OK. With that gone, we now plan to invade Sea of Japan with our Project Poutine Peripherals! Tomorrow, we will capture 99% of the fish there!");
            this.Add(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/GoFishing.dat"));
            this.Add(TemporaryContent.GetTexture("BellaExplain"));
            this.Add("Bella, Bob\'s girlfriend used to be a human so she understands the message\'s meaning. According to the excessive uses of \'eh\' and \'sorry\' and a mentioning of poutine, she suspects that this message originates from Canada. Bella begs Bob, the world\'s most fearsome fish in the ocean to go to Canada to do something. But Bob refuses.");
            this.Add("Then all fish in the Sea of Japan are kidnapped except Bob. Now, Bob must go to Canada for real.");
            this.Add(TemporaryContent.GetTexture("Logo"));
            this.Add(TemporaryContent.GetTexture("Tutorial"));
            this.Add("The goal of the game is to get rid of the enemies on the screen. Use the ASWD keys (for left-handed people) or the direction keys (for right-handed people) to move around.");
            this.Add("Unlike in the previous game, the player will be firing on default. However, press Enter (for left-handed people) or Space (for right-handed people) to make bullets home to the nearest enemy.");
            this.Add("Enemies and bullets are now the same thing! So try to avoid touching the enemies as well as their bullets. On the other hand, you can also now shoot and destroy those pesky bullets!");
            this.Add("Beware that there will be no power ups in this game. In Canada, people tend to be conservative about the power ups.");
            this.Add("OK, let's try this out a little bit.");

            Action a = () => {
                this.NextState = new Level1();
            };

            this.Add(a);
        }
    }
}
