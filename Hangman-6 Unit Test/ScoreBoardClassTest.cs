using System;
using System.IO;
using HangmanSix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanSixTest
{
    [TestClass]
    public class ScoreBoardTest
    {

        [TestMethod]
        public void Loading_File_Test()
        {
            ScoreBoard expected = new ScoreBoard();
            Player player = Player.Instance;
            player.Name = "Milena";
            player.AttemptsToGuess = 5;
            expected.AddScore(player);
            player.Name = "Ivan";
            player.AttemptsToGuess = 4;
            expected.AddScore(player);
            player.Name = "Stancho";
            player.AttemptsToGuess = 3;
            expected.AddScore(player);
            player.Name = "Iva";
            player.AttemptsToGuess = 2;
            expected.AddScore(player);
            player.Name = "Mitko";
            player.AttemptsToGuess = 1;
            expected.AddScore(player);

            ScoreBoard actual = new ScoreBoard();

            actual.Source = "../../Test Resources/ScoreBoardTest.txt";
            actual.Load();

            Assert.AreEqual(expected.TopScores.ToString(), actual.TopScores.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Loading_Files_Exception()
        {
            ScoreBoard testboard = new ScoreBoard();
            testboard.Source = @"../../Test Resources/ScoreBoardTST.txt";
            testboard.Load();
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Saving_File_Exception()
        {
            ScoreBoard testboard = new ScoreBoard();
            Player player = Player.Instance;
            player.Name = "Milena";
            player.AttemptsToGuess = 5;
            testboard.AddScore(player);
            player.Name = "Ivan";
            player.AttemptsToGuess = 4;
            testboard.AddScore(player);
            player.Name = "Stancho";
            player.AttemptsToGuess = 3;
            testboard.AddScore(player);

            testboard.Save();
        }

        [TestMethod]
        public void PrintMethodTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard();
            
            scoreBoard.Source = "../../Test Resources/ScoreBoardTest.txt";
            scoreBoard.Load();
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                scoreBoard.Print();

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "     ***** Top 5 Scores *****\r\n"
                    + "1.  Milena --> 5 mistakes\r\n"
                    + "2.  Ivan --> 4 mistakes\r\n"
                    + "3.  Stancho --> 3 mistakes\r\n"
                    + "4.  Iva --> 2 mistakes\r\n"
                    + "5.  Mitko --> 1 mistakes\r\n";
                Assert.AreEqual(expected, result);
            }
        }

    }
}


