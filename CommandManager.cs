namespace HangmanSix
{
    using System;
    using System.Text;
    using System.Threading;

    public class CommandManager
    {
        public bool HasHelpUsed { get; set; }

        public CommandManager()
        {
            this.HasHelpUsed = false;
        }

        public string Help(string dashword, string word)
        {
            string newWord = dashword;
            for (int characterIndex = 0; characterIndex < dashword.Length; characterIndex++)
            {
                if (!Char.IsLetter(newWord[characterIndex]))
                {
                    Console.WriteLine("OK, I reveal for you the next letter '{0}'", word[characterIndex]);
                    newWord = ReplaceLetter(newWord, word, characterIndex);
                    break;
                }
            }
            return newWord;
        }

        public void PrintTopScores()
        {
            ScoreBoard scores = new ScoreBoard();
            scores.Source = "../../Resources/topScores.txt";
            scores.Load();
            scores.Print();
        }

        public void Exit()
        {
            const int PauseInMilliseconds = 2000;
            Console.WriteLine("Goodbye \n Thank you for playing!");
            Thread.Sleep(PauseInMilliseconds);
            Environment.Exit(0);
        }

        public void Restart()
        {
            Console.Write("Do you want to play as another player (Y/N) ? ");
            string answer = Console.ReadLine();

            switch (answer.ToUpper())
            {
                case "Y":
                    HangmanSix.Main();
                    break;
                case "N": Exit();
                    return;
            }
        }

        private static string ReplaceLetter(string dashword, string word, int possitionToReplace)
        {
            int currentPossition = 0;

            StringBuilder newWord = new StringBuilder();

            while (currentPossition != dashword.Length)
            {
                if (currentPossition != possitionToReplace)
                {
                    newWord.Append(dashword[currentPossition]);
                }
                else if (currentPossition == possitionToReplace)
                {
                    newWord.Append(word[currentPossition]);
                }
                currentPossition++;
            }

            return newWord.ToString();
        }
    }
}
