using System.Linq;

namespace HangmanSix
{
    using System;

    public class GameEngine
    {
        private Player Player { get; set; }
        public int NumberOfRevealed { get; set; }
        public CommandManager PlayerCommand { get; set; }

        public GameEngine(Player player)
        {
            this.Player = player;
            this.NumberOfRevealed = 0;
            this.PlayerCommand = new CommandManager();
        }

        public void Initialize()
        {
            const int InitialPlayerScore = 0;
            this.Player.Score = InitialPlayerScore;
            this.Start();
        }

        public void Start()
        {
            SecretWordManager wordsManager = new SecretWordManager();
            wordsManager.LoadAllSecretWords(@"../../Resources/secretWordsLibrary.txt");

            RandomUtils randomGenerator = new RandomUtils();
            IWord secretWord = new ProxyWord(randomGenerator.RandomizeWord(wordsManager.AllSecretWords));

            GamePlay(secretWord);
        }

        private void GamePlay(IWord word)
        {
            const int MaxPlayerAttempts = 10;
            while (this.NumberOfRevealed < word.Content.Length && this.Player.Score < 10)
            {
                char playerLetter;
                Console.WriteLine("The secret word is:{0}", word.PrintView);
                bool isCommand = false;

                while (true)
                {
                    Console.Write("Enter your guess or command:");
                    string playerChoise = Console.ReadLine().ToLower();
                    if (playerChoise != String.Empty)
                    {
                        if (playerChoise.Length > 1)
                        {
                            if (!CheckCommand(playerChoise, word))
                            {
                                Console.WriteLine("Incorrect guess or command!");
                                continue;
                            }
                            isCommand = true;
                        }
                        playerLetter = playerChoise[0];
                        if (Char.IsLetter(playerChoise[0]))
                        {
                            break;
                        }
                        Console.WriteLine("You've entered incorrect input!");
                    }
                }

                if (!isCommand)
                {
                    bool isMatch = false;
                    bool isRevealed = false;

                    char[] tempArr = word.PrintView.ToCharArray();
                    for (int i = 0; i < word.WordLength; i++)
                    {
                        if (playerLetter == word.Content[i])
                        {
                            if (word.RevealedCharacters[i])
                            {
                                isRevealed = true;
                                continue;
                            }
                            tempArr[i] = word.Content[i];
                            isMatch = true;
                            word.RevealedCharacters[i] = true;
                            this.NumberOfRevealed++;
                        }
                    }

                    word.PrintView = new string(tempArr);

                    if (isMatch)
                    {
                        Console.WriteLine("Good job! You revealed {0} letters. Your mistakes are: {1}", this.NumberOfRevealed, this.Player.Score);
                    }
                    else if (isRevealed)
                    {
                        Console.WriteLine("The letter '{0}' was revealed", playerLetter);
                    }
                    else
                    {
                        this.Player.Score++;
                        Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\"). Your mistakes are: {1}", playerLetter, this.Player.Score);
                    }
                }
            }

            if (this.Player.Score == MaxPlayerAttempts)
            {
                Console.WriteLine("You lost the game. Try again.");
            }
            else
            {
                Console.WriteLine("You guessed the word \"{0}\" and you won. Congratulations!", word.Content);
                GameOver();
            }
        }

        private bool CheckCommand(string playerChoise, IWord word)
        {
            if (playerChoise == Command.Top.ToString().ToLower())
            {
                this.PlayerCommand.PrintTopScores();
                return true;
            }
            if (playerChoise == Command.Help.ToString().ToLower())
            {
                word.PrintView = this.PlayerCommand.Help(word.PrintView, word.Content);
                this.NumberOfRevealed++;
                this.PlayerCommand.HasHelpUsed = true;
                return true;
            }
            if (playerChoise == Command.Restart.ToString().ToLower())
            {
                this.PlayerCommand.Restart();
                return true;
            }
            if (playerChoise == Command.Exit.ToString().ToLower())
            {
                this.PlayerCommand.Exit();
                return true;
            }
            return false;
        }

        public void GameOver()
        {
            ScoreBoard topScores = new ScoreBoard();
            topScores.Source = @"../../Resources/topScores.txt";
            topScores.Load();
            if (!this.PlayerCommand.HasHelpUsed)
            {
                if (this.Player.Score < topScores.TopScores.Values.Last())
                {

                    while (true)
                    {
                        Console.Write("Please enter you name: ");
                        this.Player.Name = Console.ReadLine();
                        if (this.Player.Name != String.Empty)
                        {
                            break;
                        }
                    }


                    topScores.AddScore(this.Player);
                    topScores.Save();
                }
            }

            topScores.Print();
            this.Initialize();
        }
    }
}
