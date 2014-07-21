namespace HangmanSixTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using HangmanSix;
    using Telerik.JustMock;

    [TestClass]
    public class CheckManagerClassTest
    {
        //[TestMethod]
        //public void ShouldReturnTrue_CheckCommandTest_TopCommand()
        //{
        //    var mockedManager = Mock.Create<SecretWordManager>();
        //    Mock.Arrange(() => mockedManager.LoadAllSecretWords(@"../../Resources/secretWordsLibrary.txt")).DoNothing().MustBeCalled();
        //    Player player = Player.Instance;
        //    IWord testWord = new ProxyWord("testWord");
        //    CheckManager checkManager = new CheckManager(player);
        //    checkManager.DefineCommands(testWord);
        //    string playerCommand = "top";
        //    bool result = checkManager.CheckCommand(playerCommand, testWord);

        //    Assert.IsTrue(result);
        //}

        [TestMethod]
        public void ShouldReturnTrue_CheckCommandTest_RestartCommand()
        {
            Mock.SetupStatic(typeof(HangmanSix));
            Mock.Arrange(()=>HangmanSix.Main()).DoNothing();
            Player player = Player.Instance;
            IWord testWord = new ProxyWord("testWord");
            CheckManager checkManager = new CheckManager(player);
            checkManager.DefineCommands(testWord);
            string playerCommand = "restart";
            bool result = checkManager.CheckCommand(playerCommand, testWord);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldReturnFalse_CheckCommandTest_InvalidCommand()
        {
            Player player = Player.Instance;
            IWord testWord = new ProxyWord("testWord");
            CheckManager checkManager = new CheckManager(player);
            checkManager.DefineCommands(testWord);
            string playerCommand = "jump";
            bool result = checkManager.CheckCommand(playerCommand, testWord);

            Assert.IsFalse(result);
        }
    }
}
