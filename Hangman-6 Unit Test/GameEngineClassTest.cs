namespace HangmanSixTest
{
    using System;
    using HangmanSix;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    [TestClass]
    public class GameEngineClassTest
    {
        [TestMethod]
        public void CheckIfTheMainLogicReturnsCorrectDataTest()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                Player player = Player.Instance;
                player.Name = "Milena";
                player.AttemptsToGuess = 0;

                GameEngine gameEngine = new GameEngine(player, new FakeConsoleWrapper(true, false));
                gameEngine.PathToSecretWordsDirectory = @"../../Test Resources/secretWordsLibrary.txt";
                gameEngine.ChoiceStrategy = new ChoiceByIndex(3);
                
                gameEngine.InitializeData();

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "Welcome to \"Hangman\" game. Please try to guess my secret word.\r\nUse 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat, 'used' to see all used letters (in red) and 'exit' to quit the game.\r\nMaximum attempts to guess the word: 10\n\r\nThe secret word is:--------\r\nEnter your guess or command:Good job! You revealed 1 letters. Your mistakes are: 0\r\nThe secret word is:--b-----\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"c\"). Your mistakes are: 1\r\nThe secret word is:--b-----\r\nEnter your guess or command:Good job! You revealed 2 letters. Your mistakes are: 1\r\nThe secret word is:d-b-----\r\nEnter your guess or command:Good job! You revealed 4 letters. Your mistakes are: 1\r\nThe secret word is:deb---e-\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"f\"). Your mistakes are: 2\r\nThe secret word is:deb---e-\r\nEnter your guess or command:Good job! You revealed 6 letters. Your mistakes are: 2\r\nThe secret word is:deb-gge-\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"h\"). Your mistakes are: 3\r\nThe secret word is:deb-gge-\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"i\"). Your mistakes are: 4\r\nThe secret word is:deb-gge-\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"j\"). Your mistakes are: 5\r\nThe secret word is:deb-gge-\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"k\"). Your mistakes are: 6\r\nThe secret word is:deb-gge-\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"l\"). Your mistakes are: 7\r\nThe secret word is:deb-gge-\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"m\"). Your mistakes are: 8\r\nThe secret word is:deb-gge-\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"n\"). Your mistakes are: 9\r\nThe secret word is:deb-gge-\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"o\"). Your mistakes are: 10\r\nYou lost the game. Try again.\r\n";

                Assert.AreEqual(result, expected);
            }
        }
    }
}
