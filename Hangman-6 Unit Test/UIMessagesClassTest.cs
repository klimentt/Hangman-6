using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanSix;

namespace HangmanSixTest
{
    [TestClass]
    public class UIMessagesClassTest
    {
        [TestMethod]
        public void WelcomeMessageTest()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                UIMessages.WelcomeMessage(5);

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "Welcome to \"Hangman\" game. Please try to guess my secret word.\r\n" +
                          "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat, " +
                          "'used' to see all used letters (in red) and 'exit' to quit the game.\r\n" +
                          "Maximum attempts to guess the word: 5\n\r\n";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void SecretWordMessageNoGameOverTest()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                UIMessages.SecretWordMessage("testWord", false);

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "The secret word is:testWord\r\n";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void SecretWordMessageGameOverTest()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                UIMessages.SecretWordMessage("testWord", true);

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "The secret word is:   t e s t W o r d\r\n";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void RevealedLetterMessageTest()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                UIMessages.RevealedLetterMessage(4, 5);

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "Good job! You revealed 4 letters. Your mistakes are: 5\r\n";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void NotGuessedLetterMessageTest()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                UIMessages.NotGuessedLetterMessage('e', 5);

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "Sorry! There are no unrevealed letters \"e\"). Your mistakes are: 5\r\n";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void GuessAllWordMessageNoHelpTest()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                UIMessages.GuessAllWordMessage(5);

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "You won with 5 mistakes\r\n";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void GuessAllWordMessageWithHelpTest()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                UIMessages.GuessAllWordMessage(5);

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "You won with 5 mistakes\r\n";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void RevealingNextLetterMessageTest()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                UIMessages.RevealingNextLetterMessage('e');

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "OK, I reveal for you the next letter 'e'\r\n";
                Assert.AreEqual(expected, result);
            }
        }
    }
}
