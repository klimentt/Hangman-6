using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanSix;


namespace HangmanSixTest
{
    [TestClass]
    public class ChoiceByNumberClassTest
    {
        [TestMethod]
        public void NumberChoiceTest()
        {
            ChoiceStrategy byNumberStrategy = new ChoiceByIndex(5);
            List<string> testWords = new List<string>();
            testWords.Add("firstWord");
            testWords.Add("secondWord");
            testWords.Add("thirdWord");
            testWords.Add("fourthWord");
            testWords.Add("fifthhWord");
            testWords.Add("sixthhWord");
            string result = byNumberStrategy.Choice(testWords);
            string expectedValue = testWords[5];

            Assert.AreEqual(result,expectedValue);
        }
    }
}
