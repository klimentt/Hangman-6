namespace HangmanSix
{
    /// <summary>
    /// Return exactly one instance of current player using Singleton design pattern
    /// </summary>
    public sealed class Player
    {
        private Player()
        {
        }

        public static readonly Player instance = new Player();

        public static Player Instance
        {
            get
            {
                return instance;
            }
        }

        public string Name { get; set; }
        public int AttemptsToGuess { get; set; }
    }
}