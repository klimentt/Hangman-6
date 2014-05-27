namespace HangmanSix
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Random tools to processing of database from words
    /// </summary>
    public class RandomUtils
    {
        public string RandomizeWord(List<string> secretWords)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(0, (secretWords.Count - 1));
            return secretWords[randomNumber];
        }   
    }
}
