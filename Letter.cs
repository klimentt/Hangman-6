namespace HangmanSix
{
    using System;

    public class Letter : ICloneable
    {
        private const ConsoleColor DefaultLetterColor = ConsoleColor.Gray;
        private const char DefaultSign = 'a';

        public Letter()
        {
            this.Sign = DefaultSign;
            this.Color = DefaultLetterColor;
        }

        public char Sign { get; set; }

        public ConsoleColor Color { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Print()
        {
            Console.Write("{0} ", this.Sign);
        }
    }
}
