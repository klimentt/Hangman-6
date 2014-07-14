namespace HangmanSix
{
    using System;
    using System.Linq;
    using System.Text;

    class ProxyWord : Word
    {
        private IWord RealWord { get; set; }
        public override string PrintView { get; set; }
        private const char UnrevealedLetterChar = '-';

        public ProxyWord(string word)
            : base(word)
        {
            this.RealWord = new RealWord(word);
            this.WordLength = this.Content.Length;
            this.RevealedCharacters = new bool[this.WordLength];
            this.PrintView = new String(UnrevealedLetterChar, this.WordLength);
        }

        public override string Print()
        {
            if (this.RevealedCharacters.Contains(false))
            {
                FormPrintView();
                return this.PrintView;
            }
            return this.RealWord.Print();
        }

        private void FormPrintView()
        {
            StringBuilder printView = new StringBuilder();
            for (int currentChar = 0; currentChar < this.WordLength; currentChar++)
            {
                if (this.RevealedCharacters[currentChar])
                {
                    printView.Append(this.Content[currentChar]);
                }
                else
                {
                    printView.Append(UnrevealedLetterChar);
                }
            }
            this.PrintView = printView.ToString();
        }
    }
}
