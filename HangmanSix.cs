namespace HangmanSix
{
    using System;
    /// <summary>
    /// Main engine class
    /// </summary>
    class HangmanSix
    {
        // hahaha, izpih edno kilo rakiya vcera i poznavam veche vsichki dumi4ki ot pyrvi puyt, muahahahahahahaaaaaaaa

        // test plmb123

        // test plmb123 .gitignore in project folder

        // test Dr4g0


        static void Main(string[] args)
        {
            InitializePlayerAndStartGame();

            //ScoreBoard scores = new ScoreBoard();
            //scores.Source = "../../Resources/topScores.txt";
            //scores.Load();
            //scores.Print();

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
            newGame.GameOver();
        }

    }
}
