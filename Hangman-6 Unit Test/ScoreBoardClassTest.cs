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
            player.Score = 5;
            expected.AddScore(player);
            player.Name = "Ivan";
            player.Score = 4;
            expected.AddScore(player);
            player.Name = "Stancho";
            player.Score = 3;
            expected.AddScore(player);
            player.Name = "Iva";
            player.Score = 2;
            expected.AddScore(player);
            player.Name = "Mitko";
            player.Score = 1;
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
            player.Score = 5;
            testboard.AddScore(player);
            player.Name = "Ivan";
            player.Score = 4;
            testboard.AddScore(player);
            player.Name = "Stancho";
            player.Score = 3;
            testboard.AddScore(player);

            testboard.Save();
        }
    }
}


