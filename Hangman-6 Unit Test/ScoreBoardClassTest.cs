namespace HangmanSixTest
{
    using System;
    using System.IO;
    using HangmanSix;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ScoreBoardTest
    {
        IConsole console = new ConsoleWrapper();

        [TestMethod]
        public void Loading_File_Test()
        {
            ScoreBoard expected = new ScoreBoard(console);
            Player player = Player.Instance;
            player.Name = "Milena";
            player.AttemptsToGuess = 5;
            expected.AddScore(player);
            player.Name = "Ivan";
            player.AttemptsToGuess = 4;
            expected.AddScore(player);
            player.Name = "Stancho";
            player.AttemptsToGuess = 3;
            expected.AddScore(player);
            player.Name = "Iva";
            player.AttemptsToGuess = 2;
            expected.AddScore(player);
            player.Name = "Mitko";
            player.AttemptsToGuess = 1;
            expected.AddScore(player);

            ScoreBoard actual = new ScoreBoard(console);

            actual.Source = "../../Test Resources/ScoreBoardTest.txt";
            actual.Load();

            Assert.AreEqual(expected.TopScores.ToString(), actual.TopScores.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Loading_Files_Exception()
        {
            ScoreBoard testboard = new ScoreBoard(console);
            testboard.Source = @"../../Test Resources/ScoreBoardTST.txt";
            testboard.Load();
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Saving_File_Exception()
        {
            ScoreBoard testboard = new ScoreBoard(console);
            Player player = Player.Instance;
            player.Name = "Milena";
            player.AttemptsToGuess = 5;
            testboard.AddScore(player);
            player.Name = "Ivan";
            player.AttemptsToGuess = 4;
            testboard.AddScore(player);
            player.Name = "Stancho";
            player.AttemptsToGuess = 3;
            testboard.AddScore(player);

            testboard.Save();
        }

        [TestMethod]
        public void PrintMethodTest()
        {
            ScoreBoard scoreBoard = new ScoreBoard(console);
            
            scoreBoard.Source = "../../Test Resources/ScoreBoardTest.txt";
            scoreBoard.Load();
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                scoreBoard.Print();

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "     ***** Top 5 Scores *****\r\n"
                    + "1.  Milena --> 0 mistakes\r\n"
                    + "2.  Ivan --> 1 mistakes\r\n"
                    + "3.  Stancho --> 2 mistakes\r\n"
                    + "4.  Iva --> 3 mistakes\r\n"
                    + "5.  Mitko --> 4 mistakes\r\n";
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void TopCommandEvaluatorCheck()
        {
            ScoreBoard scoreBoard = new ScoreBoard(console);

            scoreBoard.Source = "../../Test Resources/ScoreBoardTest.txt";
            scoreBoard.Load();

            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                scoreBoard.Print();
                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                var splittedResult = result.Split(new string[] { " mistakes", " --> " }, StringSplitOptions.RemoveEmptyEntries);

                bool isTheTopScorersListCorrect = true;
                for (int i = 3; i < splittedResult.Length; i += 2)
                {
                    var previousTopResult = int.Parse(splittedResult[i]);
                    var currentTopResult = int.Parse(splittedResult[i - 2]);

                    if (currentTopResult > previousTopResult)
                    {
                        isTheTopScorersListCorrect = false;
                    }
                }

                Assert.IsTrue(isTheTopScorersListCorrect);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateScoreBoardWithEmptyPlayerNameTest()
        {
            var scoreboard = new ScoreBoard(console);
            scoreboard.Source = "../../Test Resources/updateScoresTestFile.txt";
            scoreboard.ConsoleWrapper = new FakeConsoleWrapper(false, true);

            Player player = Player.Instance;
            player.AttemptsToGuess = 1;

            scoreboard.Update(player);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateScoreBoardWithExistingNameTest()
        {
            var scoreboard = new ScoreBoard(console);
            scoreboard.Source = "../../Test Resources/updateScoresTestFile.txt";
            scoreboard.ConsoleWrapper = new FakeConsoleWrapper(false, false);

            Player player = Player.Instance;
            player.AttemptsToGuess = 0;

            scoreboard.Update(player);
        }

        [TestMethod]
        public void CheckIfDataIsCorrectAfterSaveAndLoadTest()
        {
            var scoreboard = new ScoreBoard(console);
            scoreboard.Source = "../../Test Resources/saveScores.txt";

            scoreboard.TopScores.Add("pavel", 1);
            scoreboard.TopScores.Add("pavko", 2);
            scoreboard.Save();
            scoreboard.TopScores.Clear();
            scoreboard.Load();

            bool areTheTopScoresLoadedAfterTheSaveCorrectly = scoreboard.TopScores.ContainsKey("pavel") && scoreboard.TopScores.ContainsKey("pavko");

            Assert.IsTrue(areTheTopScoresLoadedAfterTheSaveCorrectly);
        }
    }
}


