﻿namespace HangmanSix
{
    using System;

    public abstract class Word : IWord //may be this class is unnecessary
    {
        private string content;
        public abstract string PrintView { get; set; }

        public string Content
        {
            get { return this.content; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("The word can not be null");
                }
                if (!IsLettersOnly(value)) //check for non-alphabetic symbols
                {
                    throw new ArgumentException("The word contains non-alphabetic symbols");
                }
                this.content = value;
            }
        }

        protected Word(string word)
        {
            this.Content = word;
        }

        public abstract string Print();

        private bool IsLettersOnly(string str)
        {
            foreach (char currentChar in str)
            {
                if (!Char.IsLetter(currentChar))
                    return false;
            }

            return true;
        }
    }
}
