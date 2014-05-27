using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman_6
{
    [TestClass]
    public class SecretWordManager_Test
    {
        [TestMethod]
        public void Loading_Word_Library()
        {
            List<string> expected = new List<string>{"computer","programmer","software","debugger","compiler","developer"};

            HangmanSix.SecretWordManager actual = new HangmanSix.SecretWordManager();
            actual.LoadAllSecretWords(@"../../Test Resources/SecretWordLibraryTest.txt");

            Assert.AreEqual(expected.ToString(), actual.AllSecretWords.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Loading_Word_Library_File_Not_Found()
        {
            HangmanSix.SecretWordManager invalidPath = new HangmanSix.SecretWordManager();
            invalidPath.LoadAllSecretWords(@"../../Test Resources/WordLibraryTest.txt");
        }
    }
}
