namespace HangmanSix
{
    using System;
    using System.Threading;

    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            const int PauseInMilliseconds = 1000;
            UIMessages.ExitMessage();
            Thread.Sleep(PauseInMilliseconds);
            Environment.Exit(0);
        }
    }
}
