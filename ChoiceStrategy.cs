namespace HangmanSix
{
    using System.Collections.Generic;

    /// <summary>
    /// Abstract class to implement Strategy design pattern
    /// </summary>
    public abstract class ChoiceStrategy
    {
        /// <summary>
        /// Main abstract method Choice of Strategy design pattern
        /// </summary>
        /// <param name="allSecretWords"></param>
        /// <returns></returns>
        public abstract string Choice(List<string> allSecretWords);
    }
}
