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
        private SortedDictionary<string, int> scoreBoard = new SortedDictionary<string, int>();
        
        public SortedDictionary<string, int> TopScores
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

            try
            {
                string[] scores = File.ReadAllLines(sourceFile);
                foreach (string score in scores)
                {
                    scoreTemp = score.Split(',');
                    scoreBoard.Add(scoreTemp[1], int.Parse(scoreTemp[0]));
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The ScoreBoard File was not found");
            }
            catch (FileLoadException)
            {
                throw new FileLoadException("Unable to load scoreboard!");
            }
            catch (PathTooLongException)
            {
                throw new PathTooLongException("The path specified is too long!");
            }

        }
        public void AddScore(Player player)
        {
            scoreBoard.Add(player.Name, player.Score);
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
        public void Save()
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

        /// <summary>
        /// Prints the current top 5 scores 
        /// </summary>
        public void Print()
        {
            int possition = 1;

            this.TopFiveScores();

            Console.WriteLine("***** Top Five Scores *****".PadRight(5, ' '));

            foreach (var score in this.TopScores)
            {
                Console.WriteLine("{0}. | {1} | {2}",possition, score.Key.PadRight(10, ' '), score.Value.ToString().PadLeft(5, ' '));
                possition++;
            }
        }
    }
}
