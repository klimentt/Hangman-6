using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanSix
{
    public interface IWord
    {
        string Content { get; set; }
        bool[] RevealedCharacters { get; set; }
        int WordLength { get; set; }
        string PrintView { get; set; }
        string Print();

    }
}
