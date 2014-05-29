namespace HangmanSix
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    /// <summary>
    /// Keeps data for the top scores
    /// </summary>
    public class ScoreBoard
    {
        private SortedDictionary<int, string> scoreBoard = new SortedDictionary<int, string>();
        
        public SortedDictionary<int, string> ScoreBoard
        {
            get { return this.scoreBoard; }
        }

        /// <summary>
        /// Loads a localy stored scoreboard
        /// </summary>
        /// <param name="sourceFile">Path to the locally stored file</param>
        public void Load(string sourceFile)
        {
            string[] scoreTemp;
            string[] scores = File.ReadAllLines(sourceFile);
            
            foreach(string score in scores)
            {
                scoreTemp = score.Split(',');
                scoreBoard.Add(int.Parse(scoreTemp[0]),scoreTemp[1]);
            }
        }
        public void AddScore(Player player)
        {
            scoreBoard.Add(player.Score, player.Name);
        }

        /// <summary>
        /// Sorts the existing Scoreboard and Removes all but the top five Players
        /// </summary>
        private void TopFiveScores()
        {
            scoreBoard.OrderByDescending(key => key.Key);

            if(scoreBoard.Count > 5)
            {
                for (int i = 4; i < scoreBoard.Count; i++)
                {
                    scoreBoard.Remove(scoreBoard.ElementAt(i).Key);
                }
            }
        }

        /// <summary>
        /// Saves the scoreboard to a file in the game folder
        /// </summary>
        /// <param name="scoreBoard">Current scoreboard</param>
        public void Save(SortedDictionary<int, string> scoreBoard)
        {
            string scoreFile = "../../Resources/topScores.txt";

            using (StreamWriter scoreWriter = new StreamWriter(scoreFile))
            {
                foreach (var score in scoreBoard)
                {
                    scoreWriter.WriteLine("{0},{1}", score.Key, score.Value);
                }
            }
        }

    }
}
