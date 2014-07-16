using System.Collections.Generic;

namespace HangmanSix
{
    using System;

    public class UsedCommand : ICommand
    {
        private const int AllLetterSize = 26;

        public UsedCommand(HashSet<char> usedLetters)
        {
            this.UsedLetters = usedLetters;
            this.AllLetters = new List<Letter>();
        }

        public HashSet<char> UsedLetters { get; set; }

        public List<Letter> AllLetters { get; set; }

        public void Execute()
        {
            this.AddAllLetters();
            this.PrintAllLetters();
        }

        private void AddAllLetters()
        {
            this.AllLetters.Clear();
            for (int i = 0; i < AllLetterSize; i++)
            {
                Letter currentLetter = new Letter();
                currentLetter.Sign = Convert.ToChar(currentLetter.Sign + i);
                if (this.UsedLetters.Contains(currentLetter.Sign))
                {
                    currentLetter.Color = ConsoleColor.Red;
                }
                this.AllLetters.Add(currentLetter);
            }
        }

        private void PrintAllLetters()
        {
            for (int i = 0; i < this.AllLetters.Count; i++)
            {
                Console.ForegroundColor = this.AllLetters[i].Color;
                this.AllLetters[i].Print();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
    }
}
