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
            ICommand helpCommand = new HelpCommand(word);
            word.PrintView = "--------";

            string expectedResult = "w-------";
            testCommands.Proceed(helpCommand);

            Assert.AreEqual(expectedResult, word.PrintView);
        }

        [TestMethod]
        public void HelpCommand_Test_MiddleCharacter()
        {
            CommandManager testCommands = new CommandManager();

            IWord word = new ProxyWord("wordtest");
            ICommand helpCommand = new HelpCommand(word);
            word.PrintView = "wor-----";

            string expectedResult = "word----";
            testCommands.Proceed(helpCommand);

            Assert.AreEqual(expectedResult, word.PrintView);
        }

        [TestMethod]
        public void HelpCommand_Test_LastCharacter()
        {
            CommandManager testCommands = new CommandManager();

            IWord word = new ProxyWord("wordtest");
            ICommand helpCommand = new HelpCommand(word);
            word.PrintView = "wordtes-";

            string expectedResult = "wordtest";
            testCommands.Proceed(helpCommand);

            Assert.AreEqual(expectedResult, word.PrintView);
        }
    }
}
