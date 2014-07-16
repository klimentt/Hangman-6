namespace HangmanSix
{
    /// <summary>
    /// Managed all commands given by player
    /// </summary>
    public class CommandManager
    {
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
