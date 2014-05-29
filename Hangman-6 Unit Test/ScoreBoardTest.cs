using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman_6Test
{
    [TestClass]
    class ScoreBoardTest
    {
        [TestMethod]
        public void Loading_File_Test()
        {
            string[] expected = File.ReadAllLines("../../Test Resources/ScoreBoardTest.txt");

            HangmanSix.ScoreBoard testboard = new HangmanSix.ScoreBoard();

            testboard.Load("../../Test Resources/ScoreBoardTest.txt");

            testboard.ToString();

            Assert.AreEqual(expected, testboard.ToString());
        }
    }
}
