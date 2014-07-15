using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanSix;

namespace HangmanSixTest
{
    [TestClass]
    public class CommandsClassTest
    {
        [TestMethod]
        public void HelpCommand_Test_FirstCharacter()
        {
            CommandManager testCommands = new CommandManager();

            IWord word = new ProxyWord("wordtest");
            word.PrintView = "--------";

            string expectedResult = "w-------";
            string result = testCommands.Help(word);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void HelpCommand_Test_MiddleCharacter()
        {
            CommandManager testCommands = new CommandManager();

            IWord word = new ProxyWord("wordtest");
            word.PrintView = "wor-----";
            string expectedResult = "word----";
            string result = testCommands.Help(word);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void HelpCommand_Test_LastCharacter()
        {
            CommandManager testCommands = new CommandManager();

            IWord word = new ProxyWord("wordtest");
            word.PrintView = "wordtes-";

            string expectedResult = "wordtest";
            string result = testCommands.Help(word);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
