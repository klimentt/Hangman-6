﻿namespace HangmanSix
{
    using System;
    using System.Text;
    using System.Threading;

    public class CommandManager
    {
        public CommandManager()
        {
            this.HasHelpUsed = false;
        }

        public bool HasHelpUsed { get; set; }

        public string Help(IWord word)
        {
            string newWord = word.PrintView;
            for (int characterIndex = 0; characterIndex < newWord.Length; characterIndex++)
            {
                if (!char.IsLetter(newWord[characterIndex]))
                {
                    UIMessages.RevealingNextLetterMessage(word.Content[characterIndex]);
                    newWord = ReplaceLetter(newWord, word.Content, characterIndex);
                    word.RevealedCharacters[characterIndex] = true;
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
            const int PauseInMilliseconds = 1000;
            UIMessages.ExitMessage();
            Thread.Sleep(PauseInMilliseconds);
            Environment.Exit(0);
        }

        public void Restart()
        {
            HangmanSix.Main();
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
