using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman_6
{
    [TestClass]
    class ScoreBoard_Test
    {
        [TestMethod]
        public void Loading_File_Test()
        {
            string[] expected = File.ReadAllLines(@"../../Test Resources/ScoreBoardTest.txt");

            HangmanSix.ScoreBoard testboard = new HangmanSix.ScoreBoard();

            testboard.Load(@"../../Test Resources/ScoreBoardTest.txt");

            testboard.ToString();

            Assert.AreEqual(expected, testboard.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Loading_Files_Exception()
        {
            HangmanSix.ScoreBoard testboard = new HangmanSix.ScoreBoard();

            testboard.Load(@"../../Test Resources/ScoreBoardTST.txt");
        }
        

    }
}
