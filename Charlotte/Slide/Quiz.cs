using Charlotte.Content;
using Charlotte.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlotte.Slide
{
    public class Quiz : Slide
    {
        /// <summary>
        /// The answer key for the quiz.
        /// </summary>
        List<int> AnswerKey = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// The data structure that would collect the answers.
        /// </summary>
        List<Tuple<string, int, string>> CollectedAnswers = new List<Tuple<string, int, string>>();

        public Quiz()
        {
            this.Texture2DLoader = new Content.Texture2DLoader(Main.ContentManager.RootDirectory + "/Compressed/Quiz.zip",
                true);
        }

        public override void AddInstructions()
        {
           
            this.Add(TemporaryContent.GetTexture("Exam"));
            this.Add("The Rentforth Maid And Servant Entry Exam:");
            this.Add("Test and assess the applicant in the areas of general knowledge. The test is graded on Pass/Fail basis. To get a pass, at least 50% must be obtained on the test.");
            this.Add(TemporaryContent.GetTexture("ExamQuiz"));

            this.Add(new Selection(0, 0, AssociatedPath: CollectedAnswers,
                Question: "[Pop. Culture] Who was the voice actress for Navi in the Legend of Zelda: The Ocarina of Time?",
                Choices: new string[] {"1. Kaori Mizuhashi",
                    "2. Aya Hirano",
                    "3. Emiri Katou",
                    "4. Rina Satou"}));

            this.Add(new Selection(0, 0, AssociatedPath: CollectedAnswers,
                Question: "[Math.] What is the symbol for addition operation?",
                Choices: new string[] {"1. +",
                    "2. -",
                    "3. *",
                    "4. %"}));

            this.Add(new Selection(0, 0, AssociatedPath: CollectedAnswers,
                Question: "[Sinology] What is the first dynasty in China?",
                Choices: new string[] {"1. Xia",
                    "2. Ming",
                    "3. Qing",
                    "4. Yuan"}));

            this.Add(new Selection(0, 0, AssociatedPath: CollectedAnswers,
                Question: "[IT] Which of these programs protect computer against virus?",
                Choices: new string[] {"1. Antivirus",
                    "2. Word Processor",
                    "3. Graphic Suite",
                    "4. Task Manager"}));

            this.Add(new Selection(0, 0, AssociatedPath: CollectedAnswers,
                Question: "Which of these phoneme group are made of nasal sounds?",
                Choices: new string[] {"1. \\m n\\",
                    "2. \\t d s\\",
                    "3. \\h\\",
                    "4. \\p b f\\"}));

            this.Add(new Selection(0, 0, AssociatedPath: CollectedAnswers,
                Question: "[Eng.] Which of the symbols signifies a question?",
                Choices: new string[] {"1. ?",
                    "2. !",
                    "3. $",
                    "4. #"}));

            this.Add(new Selection(0, 0, AssociatedPath: CollectedAnswers,
                Question: "[Pol. Sci.] Which Japanese prime minister never resigned?",
                Choices: new string[] {"1. Kosai Uchida",
                    "2. Junichiro Koizumi",
                    "3. Naoto Kan",
                    "4. Yoshihiko Noda"}));

            this.Add(new Selection(0, 0, AssociatedPath: CollectedAnswers,
                Question: "[Meteo.] What is a form of water?",
                Choices: new string[] {"1. Cloud",
                    "2. Wind",
                    "3. Jetstream",
                    "4. Humidex"}));

            this.Add(new Selection(0, 0, AssociatedPath: CollectedAnswers,
                Question: "[Eng. Hist.] Which of the English kings have the title the great?",
                Choices: new string[] {"1. Alfred",
                    "2. George I",
                    "3. Edward II",
                    "4. Boudica"}));

            this.Add(new Selection(0, 0, AssociatedPath: CollectedAnswers,
                Question: "[Cullinary] Which of the food recipe requires no heat?",
                Choices: new string[] {"1. Shaved Ice",
                    "2. Hamburger",
                    "3. Steak",
                    "4. Chowder"}));

            this.Add("The test is now over and Charlotte's score will be assessed.");

            this.Add(new Action(() =>
                {
                    int score = 0;
                    int i = 0;

                    while (i < 10)
                    {
                        if (CollectedAnswers[i].Item2 == AnswerKey[i])
                        {
                            score++;
                        }
                        i++;
                    }

                    if (score < 5)
                    {
                        Main.ChangeCurrentState(new GameOver("Charlotte has failed the test and hence not qualified to work as a maid. The plot as it is can no longer continue."));
                    }
                }
            ));

            this.Add("Congrats! Charlotte has passed the test and may work as a Rentforth maid.");

            this.Add(new Action(() => {
                Properties.Settings.Default.Temp = "2";
                this.NextState = new SaveLoadScreen(new Scene3(), true);
            }));
        }
    }
}
