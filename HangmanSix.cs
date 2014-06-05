namespace HangmanSix
{
    using System;
    using System.Collections.Generic;
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
            Player newPlayer = new Player();
            Console.Write("Please enter you name: ");
            newPlayer.Name = Console.ReadLine();
            newPlayer.Score = 5;

            Game newGame = new Game(newPlayer);

            ScoreBoard scores = new ScoreBoard();
            scores.Load();
            scores.Print();

        }

        
    }
}
