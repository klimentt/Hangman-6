namespace HangmanSix
{
    using System.Collections.Generic;

    /// <summary>
    /// Class to implement choice by given index in Strategy design pattern
    /// </summary>
    public class ChoiceByIndex : ChoiceStrategy
    {
        public ChoiceByIndex(int number)
        {
            this.Index = number;
        }

        public int Index { get; set; }

        /// <summary>
        /// Concrete implementation of Choice method - pick by given index
        /// </summary>
        /// <param name="allSecretWords"></param>
        /// <returns></returns>
        public override string Choice(List<string> allSecretWords)
        {
            return allSecretWords[this.Index];
        }
    }
}
