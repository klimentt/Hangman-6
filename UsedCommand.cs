

namespace HangmanSix
{
    using System;
    using System.Collections.Generic;

    public class UsedCommand : ICommand
    {
        private const int AllLetterSize = 26;
        private const ConsoleColor redColor = ConsoleColor.Red;
        private const ConsoleColor defaultColor = ConsoleColor.Gray;

        public UsedCommand(HashSet<char> usedLetters)
        {
            this.UsedLetters = usedLetters;
            this.AllLetters = AddAllLetters();
        }

        public HashSet<char> UsedLetters { get; set; }

        public void Execute()
        {
            this.SetColorToTheUsedLetters();
            this.PrintAllLetters();
        }

        private List<Letter> AllLetters { get; set; }

        /// <summary>
        /// Load the alphabet.
        /// </summary>
        /// <returns>Returns a list where every element is of class Letter.</returns>
        private List<Letter> AddAllLetters()
        {
            var allLetters = new List<Letter>();

            for (int i = 0; i < AllLetterSize; i++)
            {
                Letter currentLetter = new Letter();
                currentLetter.Sign = Convert.ToChar(currentLetter.Sign + i);
                allLetters.Add(currentLetter);
            }

            return allLetters;
        }

        /// <summary>
        /// Set red color to all used letters. 
        /// </summary>
        private void SetColorToTheUsedLetters()
        {
            for (int i = 0; i < AllLetterSize; i++)
            {
                var currentLetter = AllLetters[i];
                if (this.UsedLetters.Contains(currentLetter.Sign) && currentLetter.Color != redColor)
                {
                    AllLetters[i].Color = redColor;
                }
            }
        }

        /// <summary>
        /// Print all used letters in red and the rest in default color.
        /// </summary>
        private void PrintAllLetters()
        {
            for (int i = 0; i < this.AllLetters.Count; i++)
            {
                Console.ForegroundColor = this.AllLetters[i].Color;
                this.AllLetters[i].Print();
            }
            Console.ForegroundColor = defaultColor;
            Console.WriteLine();
        }
    }
}
