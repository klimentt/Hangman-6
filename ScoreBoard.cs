namespace HangmanSix
{
    using System;
    using System.IO;
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
    }
}
