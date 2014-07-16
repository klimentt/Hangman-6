namespace HangmanSix
{
    public class CommandManager
    {
        public CommandManager()
        {
            this.HasHelpUsed = false;
        }

        public bool HasHelpUsed { get; set; }

        public void Proceed(ICommand command)
        {
            command.Execute();
        }
    }
}
