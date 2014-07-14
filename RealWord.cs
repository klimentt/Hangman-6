using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanSix
{
    public class RealWord : Word
    {
        public RealWord(string word)
            : base(word)
        {
        }

        public override string PrintView
        {
            get
            {
                return this.Content;
            }
            set
            {
                
            }
        }
    }
}
