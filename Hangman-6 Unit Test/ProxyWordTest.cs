namespace HangmanSixTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using HangmanSix;

    [TestClass]
    public class ProxyWordTest
    {
        [TestMethod]
        public void InititalDashedWordPrintTest()
        {
            IWord initialWord = new ProxyWord("initialWord");
            string expectedInitialWordView = "-----------";

            Assert.AreEqual(expectedInitialWordView, initialWord.Print());
        }

        [TestMethod]
        public void PartlyRevealedWordPrintTest()
        {
            IWord partlyRevealedWord = new ProxyWord("newWord");
            partlyRevealedWord.RevealedCharacters[1] = true;
            partlyRevealedWord.RevealedCharacters[3] = true;

            string expectedInitialWordView = "-e-W---";

            Assert.AreEqual(expectedInitialWordView, partlyRevealedWord.Print());
        }

        [TestMethod]
        public void RevealedWordPrintTest()
        {
            IWord revealedWord = new ProxyWord("word");
            revealedWord.RevealedCharacters[0] = true;
            revealedWord.RevealedCharacters[1] = true;
            revealedWord.RevealedCharacters[2] = true;
            revealedWord.RevealedCharacters[3] = true;

            string expectedInitialWordView = "word";

            Assert.AreEqual(expectedInitialWordView, revealedWord.Print());
        }
    }
}
