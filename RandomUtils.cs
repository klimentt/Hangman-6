namespace HangmanSix
{
    using System;
    /// <summary>
    /// Random tools to processing of database from words
    /// </summary>
    public class RandomUtils
    {
        public string RandomizeWord(string[] arr)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(0, arr.Length);
            return arr[randomNumber];
        }   
    }
}
