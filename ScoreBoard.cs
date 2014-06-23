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
        private Dictionary<string, int> scoreBoard = new Dictionary<string, int>();
        
        public Dictionary<string, int> TopScores
        {
            get { return this.scoreBoard; }
        }

        public string Source { get; set; }
  
        /// <summary>
        /// Loads a localy stored scoreboard
        /// </summary>
        /// <param name="sourceFile">Path to the locally stored file</param>
        public void Load()
        {
            string sourceFile = this.Source;
            string[] scoreTemp;

            try
            {
                string[] scores = File.ReadAllLines(sourceFile);
                foreach (string score in scores)
                {
                    scoreTemp = score.Split(',');
                    scoreBoard.Add(scoreTemp[0], int.Parse(scoreTemp[1]));
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
            if (this.TopScores.ContainsKey(player.Name))
            {
                for (int i = 0; i < scoreBoard.Count; i++)
                {
                    if (this.TopScores.ElementAt(i).Key == player.Name)
                    {
                        this.TopScores.Remove(player.Name);
                        this.TopScores.Add(player.Name, player.Score);
                    }
                }
            }
            else
            {
                this.TopScores.Add(player.Name, player.Score);
            }

            TopFiveScores();
        }

        /// <summary>
        /// Sorts the existing Scoreboard and Removes all but the top five Players
        /// </summary>
        private void TopFiveScores()
        {
            OrderScore();

            if(this.TopScores.Count > 5)
            {
                for (int i = 4; i < scoreBoard.Count; i++)
                {
                    this.TopScores.Remove(this.TopScores.ElementAt(i).Key);
                }
            }
        }

        /// <summary>
        /// Saves the scoreboard to a file in the game folder
        /// </summary>
        /// <param name="scoreBoard">Current scoreboard</param>
        public void Save()
        {
            try
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
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Unable to save file");
            }
            catch (DirectoryNotFoundException)
            {
                throw new FileNotFoundException("Unable to find save directory!");
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

        private void OrderScore()
        {
            List<KeyValuePair<string, int>> scores = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < this.TopScores.Count; i++)
            {
                if (i == 0)
                { 
                    scores.Add(new KeyValuePair<string, int>(this.TopScores.ElementAt(i).Key, this.TopScores.ElementAt(i).Value));
                }
                else
                {
                    if(this.TopScores.ElementAt(i).Value > scores[i-1].Value)
                    {
                        scores.Add(new KeyValuePair<string, int>(this.TopScores.ElementAt(i).Key, this.TopScores.ElementAt(i).Value));
                    }
                    else
                    {
                        scores.Insert(i-1, new KeyValuePair<string,int>(this.TopScores.ElementAt(i).Key,this.TopScores.ElementAt(i).Value));
                    }
                }
            }

            this.TopScores.Clear();

            for (int i = scores.Count - 1; i >= 0; i--)
            {
                this.TopScores.Add(scores[i].Key, scores[i].Value);
            }
        }
    }
}
