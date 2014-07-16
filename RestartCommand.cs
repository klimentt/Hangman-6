namespace HangmanSix
{
    public class RestartCommand : ICommand
    {
        public void Execute()
        {
            HangmanSix.Main();
        }
    }
}
