namespace HangmanSix
{
    /// <summary>
    /// Return exactly one instance using Singleton design pattern
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
        public int Score { get; set; }
    }
}