namespace HangmanSix
{
    using System;
    /// <summary>
    /// Main engine class
    /// </summary>
    class HangmanSix
    {
        static void Main(string[] args)
        {
            InitializePlayerAndStartGame();
        }

        public static void InitializePlayerAndStartGame()
        {
            const int InitialPlayerScore = 5;
            Player newPlayer = Player.Instance;

            while (true)
            {
                Console.Clear();
                Console.Write("Please enter you name: ");
                newPlayer.Name = Console.ReadLine();
                if (newPlayer.Name != String.Empty)
                {
                    break;
                }
            }

            newPlayer.Score = InitialPlayerScore;

            Game newGame = new Game(newPlayer);
            newGame.Start();
        }
    }
}
