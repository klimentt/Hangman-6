namespace HangmanSix
{
    using System;

    /// <summary>
    /// Fake Console which has unit testing purpose.
    /// </summary>
    public class FakeConsoleWrapper : IConsole
    {
        public FakeConsoleWrapper(bool hasCounter)
        {
            this.HasCounter = hasCounter;
            this.Counter = 0;
        }
        public string ReadLine()
        {
            if (this.HasCounter)
            {
                this.Counter++;

                if (this.Counter == 26)
                {
                    this.Counter = 0;
                }
            }

            return ((char)('a' + this.Counter)).ToString();
        }

        private bool HasCounter { get; set; }
        private int Counter { get; set; }
    }
}
