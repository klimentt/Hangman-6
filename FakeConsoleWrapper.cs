namespace HangmanSix
{
    using System;

    /// <summary>
    /// Fake Console which has unit testing purpose.
    /// </summary>
    public class FakeConsoleWrapper : IConsole
    {
        public FakeConsoleWrapper(bool hasCounter, bool emptyString)
        {
            this.EmptyString = emptyString;
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

            if (this.EmptyString)
            {
                return string.Empty;    
            }
            else
            {
                return ((char)('a' + this.Counter)).ToString();
            }
        }

        private bool EmptyString { get; set; }
        private bool HasCounter { get; set; }
        private int Counter { get; set; }
    }
}
