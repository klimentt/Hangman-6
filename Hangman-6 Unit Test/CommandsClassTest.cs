using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanSix;

namespace Hangman_6Test
{
    [TestClass]
    public class CommandsClassTest
    {
        [TestMethod]
        public void HelpCommand_Test_FirstCharacter()
        {
            Commands testCommands = new Commands();

            string word = "wordtest";
            string dashWord = "--------";

            string expectedResult = "w-------";
            string result = testCommands.Help(dashWord, word);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void HelpCommand_Test_MiddleCharacter()
        {
            Commands testCommands = new Commands();

            string word = "wordtest";
            string dashWord = "wor-----";

            string expectedResult = "word----";
            string result = testCommands.Help(dashWord, word);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void HelpCommand_Test_LastCharacter()
        {
            Commands testCommands = new Commands();

            string word = "wordtest";
            string dashWord = "wordtes-";

            string expectedResult = "wordtest";
            string result = testCommands.Help(dashWord, word);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
