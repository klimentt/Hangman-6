using System.Linq;

namespace HangmanSix
{
    using System;

    public class Word : IWord
    {
        private string content;

        protected Word(string word)
        {
            this.Content = word;
        }

        public virtual string PrintView { get; set; }

        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("The word can not be null");
                }

                if (!this.IsLettersOnly(value))
                {
                    throw new ArgumentException("The word contains non-alphabetic symbols");
                }

                this.content = value;
            }
        }

        public bool[] RevealedCharacters { get; set; }

        public int NumberOfRevealedLetters
        {
            get
            {
                return this.RevealedCharacters.Where(x => x).Count();
            }

            set
            {
                
            }
        }

        public int WordLength { get; set; }

        public virtual string Print()
        {
            return this.Content;
        }

        private bool IsLettersOnly(string str)
        {
            foreach (char currentChar in str)
            {
                if (!char.IsLetter(currentChar))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
