namespace HangmanSix
{
    using System;

    public abstract class Word
    {
        private string content;

        public string Content
        {
            get { return this.content; }
            set 
            {
                if (value==null)
                {
                    throw new ArgumentException("The word can not be null");
                }
                if (true) //check for digits
                {
                    
                }
                this.content = value; 
            }
        }
        
        public Word(string word)
        {
            this.Content = word;
        }
    }
}
