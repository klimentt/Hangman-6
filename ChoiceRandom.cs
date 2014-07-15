using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanSix
{
    public class ChoiceRandom : ChoiceStrategy
    {
        public override string Choice(List<string> allSecretWords)
        {
            RandomUtils randomGenerator = new RandomUtils();
            return randomGenerator.RandomizeWord(allSecretWords);
        }
    }
}
