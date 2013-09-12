using Charlotte.Content;
using Charlotte.Music;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Slide
{
    public class TestSlide : Slide
    {
        public TestSlide()
        {
            this.Texture2DLoader = new Texture2DLoader(Main.ContentManager.RootDirectory + "/TestTextures.zip", true);
        }

        public override void AddInstructions()
        {
            this.Add(new Soundtrack(Main.ContentManager.RootDirectory + "/Songs/IAmAFinalBoss.dat"));
            this.Add(TemporaryContent.GetTexture("1"));
            this.Add("???");
            this.Add("Do not pretend that you don't know.");
            this.Add(TemporaryContent.GetTexture("2"));
            this.AddRemStruct(typeof(Texture2D));
            this.Add(TemporaryContent.GetTexture("3"));
            this.Add("I like coffee with a lot of sugar!");
            this.Add(TemporaryContent.GetTexture("4"));
            this.Add(new Selection(0, 0, new string[] { "Pickle", "Yam", "Jam" }, Question: "Who do you like your flavour?"));

            Action a = () =>
            {
                switch (this.LastSelectionIndex)
                {
                    case 0:
                        this.InstructionIndex = 0;
                        break;
                    default:
                        break;
                }
            };
            this.Add(a);

            this.Add(TemporaryContent.GetTexture("5"));
            this.Add("I really do.");
            this.Add("Please do not take an offense to that.");
            this.Add("Because after all I win.");
        }

        
    }
}
