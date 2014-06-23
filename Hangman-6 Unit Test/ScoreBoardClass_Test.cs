using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman_6
{
    [TestClass]
    public class ScoreBoard_Test
    {

        [TestMethod]
        public void Loading_File_Test()
        {
            HangmanSix.ScoreBoard expected = new HangmanSix.ScoreBoard();

            expected.AddScore(new HangmanSix.Player() { Name = "Milena", Score = 5 });
            expected.AddScore(new HangmanSix.Player() { Name = "Ivan", Score = 4 });
            expected.AddScore(new HangmanSix.Player() { Name = "Stancho", Score = 3 });
            expected.AddScore(new HangmanSix.Player() { Name = "Iva", Score = 2 });
            expected.AddScore(new HangmanSix.Player() { Name = "Mitko", Score = 1 });

            HangmanSix.ScoreBoard actual = new HangmanSix.ScoreBoard();

            actual.Source = "../../Test Resources/ScoreBoardTest.txt";
            actual.Load();


            Assert.AreEqual(expected.TopScores.ToString(), actual.TopScores.ToString());
        }

            [TestMethod]
            [ExpectedException(typeof(FileNotFoundException))]
            public void Loading_Files_Exception()
            {
                HangmanSix.ScoreBoard testboard = new HangmanSix.ScoreBoard();
                testboard.Source = @"../../Test Resources/ScoreBoardTST.txt";
                testboard.Load();
            }

            [TestMethod]
            [ExpectedException(typeof(FileNotFoundException))]
            public void Savong_File_Exception()
            {
                HangmanSix.ScoreBoard testboard = new HangmanSix.ScoreBoard();

                testboard.AddScore(new HangmanSix.Player() { Name = "Milena", Score = 5 });
                testboard.AddScore(new HangmanSix.Player() { Name = "Ivan", Score = 4 });
                testboard.AddScore(new HangmanSix.Player() { Name = "Stancho", Score = 3 });

                testboard.Save();
            }
        }
    }


