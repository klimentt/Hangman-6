namespace HangmanSix
{
    using System.Collections.Generic;

    /// <summary>
    /// Class to implement random choice in Strategy design pattern
    /// </summary>
    public class ChoiceRandom : ChoiceStrategy
    {
        /// <summary>
        /// Concrete implementation of Choice method - random pick 
        /// </summary>
        /// <param name="allSecretWords"></param>
        /// <returns></returns>
        public override string Choice(List<string> allSecretWords)
        {
            RandomUtils randomGenerator = new RandomUtils();
            return randomGenerator.RandomizeWord(allSecretWords);
        }
    }
}
