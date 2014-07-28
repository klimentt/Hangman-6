namespace HangmanSixTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using HangmanSix;
    using System.IO;

    [TestClass]
    public class CommandsClassTest
    {
        [TestMethod]
        public void HelpCommandTestFirstCharacter()
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
        public void HelpCommandTestMiddleCharacter()
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
        public void HelpCommandTestLastCharacter()
        {
            CommandManager testCommands = new CommandManager();

            IWord word = new ProxyWord("wordtest");
            ICommand helpCommand = new HelpCommand(word);
            word.PrintView = "wordtes-";

            string expectedResult = "wordtest";
            testCommands.Proceed(helpCommand);

            Assert.AreEqual(expectedResult, word.PrintView);
        }

        [TestMethod]

        public void UsedCommandWithUsedLettersTest()
        {

            using (var writer = new StringWriter())
            {
                CommandManager testCommands = new CommandManager();
                var usedLetters = new HashSet<char>() { 'a', 'b', 'c' };
                ICommand usedCommand = new UsedCommand(usedLetters);

                Console.SetOut(writer);
                usedCommand.Execute();
                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "a b c d e f g h i j k l m n o p q r s t u v w x y z \r\n";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void UsedCommandWithoutUsedLettersTest()
        {

            using (var writer = new StringWriter())
            {
                CommandManager testCommands = new CommandManager();
                var usedLetters = new HashSet<char>();
                ICommand usedCommand = new UsedCommand(usedLetters);

                Console.SetOut(writer);
                usedCommand.Execute();
                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "a b c d e f g h i j k l m n o p q r s t u v w x y z \r\n";
                Assert.AreEqual(expected, result);
            }
        }
    }
}
