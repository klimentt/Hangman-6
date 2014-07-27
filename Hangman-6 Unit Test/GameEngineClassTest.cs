using System;
using HangmanSix;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace HangmanSixTest
{
    [TestClass]
    
    public class GameEngineClassTest
    {
        //[TestMethod]
        //public void IsTheCommandCorrectTest()
        //{
        //    using (var writer = new StringWriter())
        //    {
        //        Console.SetOut(writer);
        //        Player player = Player.Instance;
        //        player.Name = "Milena";
        //        player.AttemptsToGuess = 0;

        //        GameEngine gameEngine = new GameEngine(player);
        //        gameEngine.ChoiceStrategy = new ChoiceByIndex(3);
        //        gameEngine.InitializeData();

        //        writer.Flush();

        //        string result = writer.GetStringBuilder().ToString();
        //        Console.WriteLine(result);
        //        string expected = "Welcome to \"Hangman\" game. Please try to guess my secret word.\r\nUse 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat, 'used' to see all used letters (in red) and 'exit' to quit the game.\r\nMaximum attempts to guess the word: 10\n\r\nThe secret word is:--------\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"a\"). Your mistakes are: 1\r\nThe secret word is:--------\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"a\"). Your mistakes are: 2\r\nThe secret word is:--------\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"a\"). Your mistakes are: 3\r\nThe secret word is:--------\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"a\"). Your mistakes are: 4\r\nThe secret word is:--------\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"a\"). Your mistakes are: 5\r\nThe secret word is:--------\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"a\"). Your mistakes are: 6\r\nThe secret word is:--------\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"a\"). Your mistakes are: 7\r\nThe secret word is:--------\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"a\"). Your mistakes are: 8\r\nThe secret word is:--------\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"a\"). Your mistakes are: 9\r\nThe secret word is:--------\r\nEnter your guess or command:Sorry! There are no unrevealed letters \"a\"). Your mistakes are: 10\r\nYou lost the game. Try again.\r\n";

        //        Assert.AreEqual(result, "st");
        //    }
        //}
    }
}
