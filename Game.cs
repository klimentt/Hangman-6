using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanSix
{
    public class Game
    {
        public Game(Player player)
        {
            SecretWordManager words = new SecretWordManager();
            words.LoadAllSecretWords(@"../../Resources/secretWordsLibrary.txt");

            int numberOfRevealed = 0;

            RandomUtils randomGenerator = new RandomUtils();
            string word = randomGenerator.RandomizeWord(words.AllSecretWords);
            string dashWord = new String('-', word.Length);

            GamePlay(numberOfRevealed, player, word, dashWord);
        }

        private void GamePlay(int numberOfRevealed, Player player, string word, string dashWord)
        {
            Commands playerCommand = new Commands();

            while (numberOfRevealed < word.Length && player.Score > 0)
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
                        case CommandManager.Restart: playerCommand.Restart(player); break;
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

                        numberOfRevealed++;
                    }
                }

                dashWord = new string(tempArr);

                if (isMatch)
                {
                    Console.WriteLine("Good job! You revealed {0} of the letters and your remaining errors is:{1}", numberOfRevealed, player.Score);
                }
                else
                {
                    player.Score--;
                    Console.WriteLine("Sorry there are no unrevealed letters \"{0}\"). Your player.Score is now {1}", (char)letter, player.Score);
                }
            }

            if (player.Score == 0)
            {
                Console.WriteLine("You lost the game. Try again.");
            }
            else
            {
                Console.WriteLine("You guessed the word \"{0}\" and you won. Congratulations!", word);
                EndGame(player);
            }
        }

        private void EndGame(Player player)
        {
            ScoreBoard topScores = new ScoreBoard();

            topScores.Load();
            topScores.AddScore(player);
            topScores.Save();
        }
    }
}
