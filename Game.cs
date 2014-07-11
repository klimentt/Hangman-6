using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanSix
{
    public class Game
    {
        private Player Player { get; set; }
        public int NumberOfRevealed { get; set; }
        public CommandManager playerCommand { get; set; }

        public Game(Player player)
        {
            this.Player = player;
            this.NumberOfRevealed = 0;
            this.playerCommand = new CommandManager();
        }

        public void Start()
        {
            SecretWordManager wordsManager = new SecretWordManager();
            wordsManager.LoadAllSecretWords(@"../../Resources/secretWordsLibrary.txt");

            RandomUtils randomGenerator = new RandomUtils();
            IWord secretWord = new ProxyWord(randomGenerator.RandomizeWord(wordsManager.AllSecretWords));
            //string hideWord = new String('-', secretWord.Length);

            GamePlay(secretWord);
        }

        private void GamePlay(IWord word)
        {
            while (this.NumberOfRevealed < word.Content.Length && this.Player.Score > 0)
            {
                string playerChoise;
                char firstLetter;
                Console.WriteLine("The word to be guessed is:{0}", word.Print());
                while (true)
                {
                    Console.Write("Input a letter:");
                    playerChoise = Console.ReadLine().ToLower();
                    if (playerChoise != String.Empty)
                    {
                        firstLetter = playerChoise[0];
                        if (Char.IsLetter(firstLetter))
                        {
                            break;
                        }
                        Console.WriteLine("You've entered incorrect input!");
                    }
                }

                if (playerChoise == Command.Top.ToString().ToLower())
                {
                    this.playerCommand.PrintTopScores();
                    continue;
                }
                if (playerChoise == Command.Help.ToString().ToLower())
                {
                    word.PrintView = this.playerCommand.Help(word.PrintView, word.Content);
                    this.NumberOfRevealed++;
                    continue;
                }
                if (playerChoise == Command.Restart.ToString().ToLower())
                {
                    this.playerCommand.Restart();
                    continue;
                }
                if (playerChoise == Command.Exit.ToString().ToLower())
                {
                    this.playerCommand.Exit();
                    continue;
                }

                bool isMatch = false;

                char[] tempArr = word.PrintView.ToCharArray();
                for (int i = 0; i < word.Content.Length; i++)
                {
                    if (firstLetter == word.Content[i])
                    {
                        tempArr[i] = word.Content[i];
                        isMatch = true;
                        word.RevealedCharacters[i] = true;
                        this.NumberOfRevealed++;
                    }
                }

                word.PrintView = new string(tempArr);

                if (isMatch)
                {
                    Console.WriteLine("Good job! You revealed {0} of the letters and your remaining errors is:{1}", this.NumberOfRevealed, this.Player.Score);
                }
                else
                {
                    this.Player.Score--;
                    Console.WriteLine("Sorry there are no unrevealed letters \"{0}\"). Your player.Score is now {1}", firstLetter, this.Player.Score);
                }
            }

            if (this.Player.Score == 0)
            {
                Console.WriteLine("You lost the game. Try again.");
            }
            else
            {
                Console.WriteLine("You guessed the word \"{0}\" and you won. Congratulations!", word.Content);
                GameOver();
            }
        }

        public void GameOver()
        {
            ScoreBoard topScores = new ScoreBoard();
            topScores.Source = @"../../Resources/topScores.txt";
            topScores.Load();
            topScores.AddScore(this.Player);
            topScores.Save();
            this.playerCommand.Restart();
        }

    }
}
