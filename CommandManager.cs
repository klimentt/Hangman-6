namespace HangmanSix
{
    /// <summary>
    /// Managed all commands given by player
    /// </summary>
    public class CommandManager
    {
        /// <summary>
        /// Initialize a new instance of the HangmanSix.CommandManager class
        /// </summary>
        public CommandManager()
        {
            //this.HasHelpUsed = false;
        }

        //public bool HasHelpUsed { get; set; }

        /// <summary>
        /// Execute a specific command
        /// </summary>
        /// <param name="command"></param>
        public void Proceed(ICommand command)
        {
            command.Execute();
        }
    }
}
