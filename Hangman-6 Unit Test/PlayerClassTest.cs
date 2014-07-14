using System;
using HangmanSix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanSixTest
{
    [TestClass]
    public class PlayerClassTest
    {
        [TestMethod]
        public void SingletonePatternOneInstanceTest()
        {
            Player firstPlayer = Player.Instance;
            firstPlayer.Name = "FirstTestPlayer";
            Player secondPlayer = Player.Instance;
            secondPlayer.Name = "SecondTestPlayer";
            string expectedPlayerName = "SecondTestPlayer";

            Assert.AreEqual(expectedPlayerName, firstPlayer.Name);
        }
    }
}
