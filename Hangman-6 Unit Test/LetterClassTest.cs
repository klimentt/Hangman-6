namespace HangmanSixTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using HangmanSix;
    using System.IO;

    [TestClass]
    public class LetterClassTest
    {
        [TestMethod]

        public void DefaultLetterSignTest()
        {
            Letter currentLetter = new Letter();
            char expectedDefaultSign = 'a';

            Assert.AreEqual(expectedDefaultSign, currentLetter.Sign);
        }

        [TestMethod]
        public void LetterSignTest()
        {
            Letter currentLetter = new Letter();
            currentLetter.Sign = 'h';
            char expectedSign = 'h';

            Assert.AreEqual(expectedSign, currentLetter.Sign);
        }

        [TestMethod]

        public void DefaultLetterColorTest()
        {
            Letter currentLetter = new Letter();
            ConsoleColor expectedColor = ConsoleColor.Gray;

            Assert.AreEqual(expectedColor, currentLetter.Color);
        }

        [TestMethod]
        public void LetterColorTest()
        {
            Letter currentLetter = new Letter();
            currentLetter.Color = ConsoleColor.Yellow;
            ConsoleColor expectedColor = ConsoleColor.Yellow;

            Assert.AreEqual(expectedColor, currentLetter.Color);
        }

        [TestMethod]
        public void PrintLetterTest()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                Letter currentLetter = new Letter();
                currentLetter.Print();

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "a ";

                Assert.AreEqual(expected, result);
            }
        }
    }
}
