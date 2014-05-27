namespace HangmanSix
{
    using System;

    /// <summary>
    /// Keeps current player's word 
    /// </summary>
    public class PlayerWord : Word //doesn't need inheritance ?
    {
        public PlayerWord(string word) : base(word)
        {
        }
    }
}
