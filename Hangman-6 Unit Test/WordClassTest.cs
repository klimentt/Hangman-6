using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanSix;

namespace HangmanSixTest
{
    [TestClass]
    public class WordClassTest
    {
        [TestMethod]
        public void IsLettersOnlyTrueTest()
        {
            Word testWord = new Word("testWord");
            bool result = testWord.IsLettersOnly(testWord.Content);
            bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsLettersOnlyFalseWithNumberTest()
        {
            Word testWordWithNumber = new Word("test1Word");
            testWordWithNumber.IsLettersOnly(testWordWithNumber.Content);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsLettersOnlyFalseWithWhiteSpaceTest()
        {
            Word testWordWithWhiteSpace = new Word("test Word");
            testWordWithWhiteSpace.IsLettersOnly(testWordWithWhiteSpace.Content);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsLettersOnlyFalseWithSpecialSymbolTest()
        {
            Word testWordWithSpecialSymbol = new Word("test{Word}");
            testWordWithSpecialSymbol.IsLettersOnly(testWordWithSpecialSymbol.Content);
        }

        [TestMethod]
        public void PrintTest()
        {
            Word testWord = new Word("testWord");
            string result = testWord.Print();
            string expected = "testWord";

            Assert.AreEqual(expected,result);
        }
    }
}
