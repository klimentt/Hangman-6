namespace HangmanSix
{
    public class TopCommand : ICommand
    {
        public void Execute()
        {
            ScoreBoard scores = new ScoreBoard();
            scores.Source = "../../Resources/topScores.txt";
            scores.Load();
            scores.Print();
        }
    }
}
