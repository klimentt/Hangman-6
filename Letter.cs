namespace HangmanSix
{
    using System;

    public class Letter : ICloneable
    {
        public const ConsoleColor DefaultLetterColor = ConsoleColor.Gray;
        private const char DefaultSign = 'a';

        public Letter()
        {
            this.Sign = DefaultSign;
            this.Color = DefaultLetterColor;
        }

        public char Sign { get; set; }

        public ConsoleColor Color { get; set; }

        public int Size { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone() as Letter;
        }

        public void Print()
        {
            Console.Write("{0} ", this.Sign);
        }
    }
}
