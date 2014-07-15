using System.Linq;

namespace HangmanSix
{
    using System;

    public class GameEngine
    {
        private Player Player { get; set; }
        public int NumberOfRevealed { get; set; }
        public CommandManager PlayerCommand { get; set; }
        const int InitialPlayerScore = 0;
        const int MaxPlayerAttempts = 10;

        public GameEngine(Player player)
        {
            this.Player = player;
            this.NumberOfRevealed = 0;
            this.PlayerCommand = new CommandManager();
        }

        public void Initialize()
        {
            Console.Clear();
            this.Player.Score = InitialPlayerScore;
            this.NumberOfRevealed = 0;
            this.PlayerCommand.HasHelpUsed = false;
            this.Start();
        }

        private void Start()
        {
            SecretWordManager wordsManager = new SecretWordManager();
            wordsManager.LoadAllSecretWords(@"../../Resources/secretWordsLibrary.txt");

            RandomUtils randomGenerator = new RandomUtils();
            var allWords = wordsManager.GetAllSecretWords();
            IWord secretWord = new ProxyWord(randomGenerator.RandomizeWord(wordsManager.GetAllSecretWords()));
            this.Welcome();
            this.GamePlay(secretWord);
        }

        private void Welcome()
        {
            Console.WriteLine("Welcome to \"Hangman\" game. Please try to guess my secret word.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat and 'exit' to quit the game.\n");
        }

        private void GamePlay(IWord word)
        {
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
                        playerLetter = playerChoise.ToLower()[0];
                        if (Char.IsLetter(playerLetter))
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
            GameOver(word);
        }

        private bool CheckCommand(string playerChoise, IWord word)
        {
            if (playerChoise.ToLower() == Command.Top.ToString().ToLower())
            {
                this.PlayerCommand.PrintTopScores();
                return true;
            }
            if (playerChoise.ToLower() == Command.Help.ToString().ToLower())
            {
                word.PrintView = this.PlayerCommand.Help(word.PrintView, word.Content);
                this.NumberOfRevealed++;
                this.PlayerCommand.HasHelpUsed = true;
                return true;
            }
            if (playerChoise.ToLower() == Command.Restart.ToString().ToLower())
            {
                this.PlayerCommand.Restart();
                return true;
            }
            if (playerChoise.ToLower() == Command.Exit.ToString().ToLower())
            {
                this.PlayerCommand.Exit();
                return true;
            }
            return false;
        }

        public void GameOver(IWord word)
        {
            if (this.Player.Score == MaxPlayerAttempts)
            {
                Console.WriteLine("You lost the game. Try again.");
            }
            else
            {
                if (this.PlayerCommand.HasHelpUsed)
                {
                    Console.WriteLine("You won with {0} mistakes but you have cheated. You are not allowed to enter into the scoreboard", this.Player.Score);
                    Console.WriteLine("The secret word is:  {0}", String.Join(" ", word.Content.ToCharArray()));
                }
                else
                {
                    Console.WriteLine("You won with {0} mistakes", this.Player.Score);
                    Console.WriteLine("The secret word is:  {0}", String.Join(" ", word.Content.ToCharArray()));
                    UpdateAndPrintScoreBoard();
                }
            }
            Console.WriteLine("Press any key to start a new game ...");
            Console.ReadKey();
            this.Initialize();
        }

        private void UpdateAndPrintScoreBoard()
        {
            ScoreBoard topScores = new ScoreBoard();
            topScores.Source = @"../../Resources/topScores.txt";
            topScores.Load();
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
            topScores.Print();
        }
    }
}
