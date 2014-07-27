using System;
using System.IO;
using System.Collections.Generic;
using HangmanSix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanSixTest
{
    [TestClass]
    public class SecretWordManager_Test
    {
        [TestMethod]
        public void LoadingWordsFromTest()
        {
            List<string> expected = new List<string> { "computer", "programmer", "software", "debugger", "compiler", "developer" };

            SecretWordManager actual = new SecretWordManager();
            actual.LoadAllSecretWords(@"../../Test Resources/SecretWordLibraryTest.txt");

            Assert.AreEqual(expected.ToString(), actual.GetAllSecretWords().ToString());
        }

        [TestMethod]
        public void SingleWordCheckTest()
        {
            SecretWordManager actual = new SecretWordManager();
            actual.LoadAllSecretWords(@"../../Test Resources/SecretWordLibraryTest.txt");

            Assert.IsTrue(actual.GetAllSecretWords().Contains("computer"));
        }

        [TestMethod]
        public void LoadingWordsFromNonOrderedFileWithWordsTest()
        {
            List<string> expected = new List<string> { "computer", "debugger", "silence" };

            SecretWordManager actual = new SecretWordManager();
            actual.LoadAllSecretWords(@"../../Test Resources/nonOrderedWords.txt");

            Assert.AreEqual(expected.ToString(), actual.GetAllSecretWords().ToString());
        }

        [TestMethod]
        public void LoadingWordsFromEmptyFileTest()
        {
            List<string> expected = new List<string>();

            SecretWordManager actual = new SecretWordManager();
            actual.LoadAllSecretWords(@"../../Test Resources/emptyfile.txt");

            Assert.AreEqual(expected.ToString(), actual.GetAllSecretWords().ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LoadingWordLibraryFileNotFoundTest()
        {
            SecretWordManager invalidPath = new SecretWordManager();
            invalidPath.LoadAllSecretWords(@"../../Test Resources/WordLibraryTest.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(PathTooLongException))]
        public void PathTooLongExceptionTest()
        {
            SecretWordManager invalidPath = new SecretWordManager();
            invalidPath.LoadAllSecretWords(@"../../Test Resources/WordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTestWordLibraryTest.txt");
        }


    }
}
