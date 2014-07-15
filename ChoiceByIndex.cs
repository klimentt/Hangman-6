namespace HangmanSix
{
    using System.Collections.Generic;

    public class ChoiceByIndex : ChoiceStrategy
    {
        public int Index { get; set; }

        public ChoiceByIndex(int number)
        {
            this.Index = number;
        }

        public override string Choice(List<string> allSecretWords)
        {
            return allSecretWords[this.Index];
        }
    }
}
