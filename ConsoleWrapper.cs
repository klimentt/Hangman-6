namespace HangmanSix
{
    using System;

    /// <summary>
    /// Using the original console
    /// </summary>
    public class ConsoleWrapper : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
