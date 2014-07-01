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

        public Game(Player player)
        {
            this.Player = player;
            this.NumberOfRevealed = 0;
        }

        public void Start()
        {
            SecretWordManager wordsManager = new SecretWordManager();
            wordsManager.LoadAllSecretWords(@"../../Resources/secretWordsLibrary.txt");

            RandomUtils randomGenerator = new RandomUtils();
            string word = randomGenerator.RandomizeWord(wordsManager.AllSecretWords);
            string hideWord = new String('-', word.Length);

            GamePlay(word, hideWord);
        }

        private void GamePlay(string word, string hideWord)
        {
            Commands playerCommand = new Commands();

            while (this.NumberOfRevealed < word.Length && this.Player.Score > 0)
            {
                string playerChoise;
                char firstLetter;
                Console.WriteLine("The word to be guessed is:{0}", hideWord);
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

                if (playerChoise == CommandManager.Top.ToString().ToLower())
                {
                    playerCommand.PrintTopScores();
                    continue;
                }
                if (playerChoise == CommandManager.Help.ToString().ToLower())
                {
                    hideWord = playerCommand.Help(hideWord, word);
                    this.NumberOfRevealed++;
                    continue;
                }
                if (playerChoise == CommandManager.Restart.ToString().ToLower())
                {
                    playerCommand.Restart();
                    continue;
                }
                if (playerChoise == CommandManager.Exit.ToString().ToLower())
                {
                    playerCommand.Exit();
                    continue;
                }

                bool isMatch = false;

                char[] tempArr = hideWord.ToCharArray();
                for (int i = 0; i < word.Length; i++)
                {
                    if (firstLetter == word[i])
                    {
                        tempArr[i] = word[i];
                        isMatch = true;

                        this.NumberOfRevealed++;
                    }
                }

                hideWord = new string(tempArr);

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
                Console.WriteLine("You guessed the word \"{0}\" and you won. Congratulations!", word);
                playerCommand.Restart();
            }
        }

        private void EndGame()
        {
            ScoreBoard topScores = new ScoreBoard();
            topScores.Source = @"../../Resources/topScores.txt";
            topScores.Load();
            topScores.AddScore(this.Player);
            topScores.Save();
        }

    }
}
