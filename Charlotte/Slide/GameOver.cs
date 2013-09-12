using Charlotte.Content;
using Charlotte.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Slide
{
    public class GameOver : Slide
    {
        string Reason;

        public GameOver(string Reason)
        {
            this.Reason = Reason;
        }

        public override void AddInstructions()
        {
            this.Add(PersistentContent.GetTexture("GameOver"));
            this.Add(Reason);

            this.Add(new Action(() =>
                {
                    this.NextState = new Title();
                }));
        }
    }
}
