namespace HangmanSixTest
{
    using System;
    using HangmanSix;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class FakeConsoleClassTest
    {
        [TestMethod]
        public void WithFakeConsoleCounterTest()
        {
            var fakeConsoleWithCounter = new FakeConsoleWrapper(true,false);

            string result = fakeConsoleWithCounter.ReadLine();
            string expected = "b";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void WithOutFakeConsoleCounterTest()
        {
            var fakeConsoleWithCounter = new FakeConsoleWrapper(false,false);

            string result = fakeConsoleWithCounter.ReadLine();
            string expected = "a";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CheckIfDataIsCorrectWhenTheCounterIBeingNullifiedTest()
        {
            var fakeConsoleWithCounter = new FakeConsoleWrapper(true, false);

            List<string> alphabetSymbols = new List<string>();

            for (int i = 0; i < 30; i++)
            {
                alphabetSymbols.Add(fakeConsoleWithCounter.ReadLine());
            }
            string result = alphabetSymbols[26];
            string expected = "b";
            Assert.AreEqual(result, expected);
        }
    }
}
