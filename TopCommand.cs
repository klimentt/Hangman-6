namespace HangmanSix
{
    public class TopCommand : ICommand
    {

        public void Execute()
        {
            var consoleWrapper = new ConsoleWrapper();
            ScoreBoard scores = new ScoreBoard(consoleWrapper);
            scores.Source = "../../Resources/topScores.txt";
            scores.Load();
            scores.Print();
        }
    }
}
