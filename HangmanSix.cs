namespace HangmanSix
{
    /// <summary>
    /// Main engine class
    /// </summary>
    public static class HangmanSix
    {
        public static void Main()
        {
            Player newPlayer = Player.Instance;
            GameEngine newGame = new GameEngine(newPlayer);
            newGame.Initialize();
        }
    }
}
