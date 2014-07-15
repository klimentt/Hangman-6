using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanSix
{
    public class ChoiceByNumber : ChoiceStrategy
    {
        public int Number { get; set; }

        public ChoiceByNumber(int number)
        {
            this.Number = number;
        }

        public override string Choice(List<string> allSecretWords)
        {
            return allSecretWords[this.Number];
        }
    }
}
