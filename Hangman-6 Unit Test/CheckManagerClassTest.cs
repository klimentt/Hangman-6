using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanSix;

namespace HangmanSixTest
{
    [TestClass]
    public class CheckManagerClassTest
    {
        [TestMethod]
        public void IsTheCommandWrongTest()
        {
            Player player = Player.Instance;
            player.Name = "Milena";
            player.AttemptsToGuess = 5;
            var checkManager = new CheckManager(player);
            Word testWord = new Word("testWord");
            bool isCorrect = checkManager.CheckCommand("wrongCommand", testWord);

            Assert.IsFalse(isCorrect);
        }

        [TestMethod]
        public void AddLetterInUsedMethodTest()
        {
            Player player = Player.Instance;
            player.Name = "Milena";
            player.AttemptsToGuess = 5;
            var checkManager = new CheckManager(player);

            char guessedChar = 't';

            checkManager.AddLetterInUsed(guessedChar);

            Assert.IsTrue(checkManager.UsedLetters.Contains(guessedChar));
        }

        [TestMethod]
        public void CheckWordPrintViewAfterProcessingWithCharWhichIsPartOfTheWordTest()
        {
            Player player = Player.Instance;
            player.Name = "Milena";
            player.AttemptsToGuess = 5;

            var checkManager = new CheckManager(player);
            IWord word = new ProxyWord("test");
            char guessedChar = 't';

            checkManager.CheckLetterAccordance(word, guessedChar);

            bool checkProcessedWordPrintView = word.PrintView == "t--t";
            Assert.IsTrue(checkProcessedWordPrintView);
        }

        [TestMethod]
        public void CheckWordPrintViewAfterProcessingWithCharWhichIsNotPartOfTheWordTest()
        {
            Player player = Player.Instance;
            player.Name = "Milena";
            player.AttemptsToGuess = 5;

            var checkManager = new CheckManager(player);
            IWord word = new ProxyWord("test");
            char guessedChar = 'r';

            checkManager.CheckLetterAccordance(word, guessedChar);

            bool checkProcessedWordPrintView = word.PrintView == "----";
            Assert.IsTrue(checkProcessedWordPrintView);
        }

        [TestMethod]
        public void CheckWhenTheGuessIsWrongIfThePlayerAttemptsToGuessAreIncreased()
        {
            Player player = Player.Instance;
            player.Name = "Milena";
            player.AttemptsToGuess = 0;

            var checkManager = new CheckManager(player);
            IWord word = new ProxyWord("test");
            char guessedChar = 'r';

            checkManager.CheckLetterAccordance(word, guessedChar);
            int expectedPlayerAttemptsToGuess = 1;

            Assert.AreEqual(expectedPlayerAttemptsToGuess, player.AttemptsToGuess);
        }

    }
}
