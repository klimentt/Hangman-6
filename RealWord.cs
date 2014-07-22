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
        }
    }
}
