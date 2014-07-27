namespace HangmanSix
{
    /// <summary>
    /// Main engine class in the application holding Main() method
    /// </summary>
    public static class HangmanSix
    {
        public static void Main()
        {
            //Player player = Player.Instance;
            //player.Name = "Milena";
            //player.AttemptsToGuess = 0;

            //var checkManager = new CheckManager(player);
            //IWord word = new ProxyWord("test");
            //checkManager.CheckCommand("Help", word);

            Player newPlayer = Player.Instance;
            GameEngine newGame = new GameEngine(newPlayer);
            newGame.InitializeData();
        }
    }
}
