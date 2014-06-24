using System;
using System.Text;
using System.Threading;

namespace HangmanSix
{
    class Commands
    {
        public string Help(string dashword, string word)
        {
            for (int characterIndex = 0; characterIndex < dashword.Length; characterIndex++)
            {
                if (dashword[characterIndex] != '-')
                {
                    continue;
                }
                else
                {
                    dashword = ReplaceLetter(dashword, word, characterIndex);
                    break;
                }
            }
            return dashword;
        }

        public void Top()
        {
            ScoreBoard scores = new ScoreBoard();
            scores.Source = "../../Resources/topScores.txt";
            scores.Load();
            scores.Print();
        }

        public void Exit()
        {
            Console.WriteLine("Goodbye \n Thank you for playing?");
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            Environment.Exit(0);
        }

        public void Restart(Player currentPlayer)
        {
            Console.Write("Do you want to play as another player (Y/N) ? ");
            string answer = Console.ReadLine();

            switch (answer)
            { 
                case "Y":   Player newPlayer = new Player();
                            Console.Write("Please enter you name: ");
                            newPlayer.Name = Console.ReadLine();
                            newPlayer.Score = 5;
                            Game newGame = new Game(newPlayer);
                    break;
                case "N": Game game = new Game(currentPlayer);
                    break;
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
