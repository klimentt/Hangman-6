using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanSix
{
    public abstract class ChoiceStrategy
    {
        public abstract string Choice(List<string> allSecretWords);
    }
}
