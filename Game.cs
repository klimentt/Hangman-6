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
            string dashWord = new String('-', word.Length);

            GamePlay(word, dashWord);
        }

        private void GamePlay(string word, string dashWord)
        {
            Commands playerCommand = new Commands();

            while (this.NumberOfRevealed < word.Length && this.Player.Score > 0)
            {
                string input = " ";
                bool correctInput = true;
                Console.WriteLine("The word to be guessed is:{0}", dashWord);
                int letter = 0;

                while ((letter < 'a' || letter > 'z') && (letter < 'A' || letter > 'Z'))
                {
                    if (!correctInput)
                    {
                        Console.WriteLine("You've entered incorrect input!");
                    }

                    Console.Write("Input a letter:");
                    input = Console.ReadLine();

                    switch (input.ToLower())
                    {
                        case CommandManager.Top: playerCommand.Top(); break;
                        case CommandManager.Help: dashWord = playerCommand.Help(dashWord, word);
                            Console.WriteLine("The word to be guessed is:{0}", dashWord);
                            break;
                        case CommandManager.Restart: playerCommand.Restart(this.Player); break;
                        case CommandManager.Exit: playerCommand.Exit(); break;
                        default:
                            letter = input[0];
                            if ((letter >= 'A' && letter <= 'Z') && letter != 0)
                            {
                                letter += 32;
                            }
                            correctInput = true;
                            break;
                    }

                }

                correctInput = false;
                bool isMatch = false;

                char[] tempArr = dashWord.ToCharArray();
                for (int i = 0; i < word.Length; i++)
                {
                    if (letter == word[i])
                    {
                        tempArr[i] = word[i];
                        isMatch = true;

                        this.NumberOfRevealed++;
                    }
                }

                dashWord = new string(tempArr);

                if (isMatch)
                {
                    Console.WriteLine("Good job! You revealed {0} of the letters and your remaining errors is:{1}", this.NumberOfRevealed, this.Player.Score);
                }
                else
                {
                    this.Player.Score--;
                    Console.WriteLine("Sorry there are no unrevealed letters \"{0}\"). Your player.Score is now {1}", (char)letter, this.Player.Score);
                }
            }

            if (this.Player.Score == 0)
            {
                Console.WriteLine("You lost the game. Try again.");
            }
            else
            {
                Console.WriteLine("You guessed the word \"{0}\" and you won. Congratulations!", word);
                EndGame();
            }
        }

        private void EndGame()
        {
            ScoreBoard topScores = new ScoreBoard();
            topScores.Source = @"D:\My Documents\C#\GitHub\Hangman-6\Resources\ScoreBoard.txt";
            topScores.Load();
            topScores.AddScore(this.Player);
            topScores.Save();
        }
    }
}
