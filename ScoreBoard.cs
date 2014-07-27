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
        private const string TopScoresDataPath = @"../../Resources/topScores.txt";

        private const int NumberOfTopScores = 5;

        private Dictionary<string, int> scoreBoard = new Dictionary<string, int>();

        public ScoreBoard()
        {
            this.Source = TopScoresDataPath;
        }

        public Dictionary<string, int> TopScores
        {
            get
            {
                return this.scoreBoard;
            }
            private set
            {
                this.scoreBoard = value;
            }
        }

        public string Source { get; set; }

        private void OrderScore()
        {
            this.TopScores = this.TopScores.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Sorts the existing Scoreboard and Removes all but the top five Players
        /// </summary>
        private void ExtractSpecificTopScores()
        {
            OrderScore();

            if (this.TopScores.Count > NumberOfTopScores)
            {
                for (int i = NumberOfTopScores; i < scoreBoard.Count; i++)
                {
                    this.TopScores.Remove(this.TopScores.ElementAt(i).Key);
                }
            }
        }

        /// <summary>
        /// Loads a localy stored scoreboard
        /// </summary>
        public void Load()
        {
            string[] scoreTemp;

            try
            {
                string[] scores = File.ReadAllLines(this.Source);
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
            this.TopScores.Add(player.Name, player.AttemptsToGuess);
            ExtractSpecificTopScores();
        }

        /// <summary>
        /// Saves the scoreboard to a file in the game folder
        /// </summary>
        public void Save()
        {
            try
            {
                using (StreamWriter scoreWriter = new StreamWriter(this.Source))
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
        /// Prints the current top scores 
        /// </summary>
        public void Print()
        {
            int possition = 1;

            Console.WriteLine("{0}***** Top {1} Scores *****", new string(' ', 5), NumberOfTopScores);

            foreach (var score in this.TopScores)
            {
                Console.WriteLine("{0}.  {1} --> {2} mistakes", possition, score.Key, score.Value.ToString());
                possition++;
            }
        }

        public void Update(Player player)
        {
            this.Load();
            if (this.TopScores.Count < NumberOfTopScores || player.AttemptsToGuess < this.TopScores.Values.Last())
            {
                while (true)
                {
                    UIMessages.EnterPlayerNameMessage();
                    player.Name = Console.ReadLine();
                    if (player.Name != string.Empty)
                    {
                        break;
                    }
                }

                this.AddScore(player);
                this.Save();
            }
        }
    }
}
