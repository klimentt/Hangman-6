using System.Collections.Generic;
using System.Linq;

namespace HangmanSix
{
    using System;

    public class GameEngine
    {
        private Player Player { get; set; }
        public int NumberOfRevealedLetters { get; set; }
        public CommandManager PlayerCommand { get; set; }
        public ChoiceStrategy ChoiceStrategy { get; set; }
        private const int InitialPlayerScore = 0;
        private const int InitialRevealedLetters = 0;
        private const int MaxPlayerAttempts = 10;
        private const string PathToSecretWordsDatabase = @"../../Resources/secretWordsLibrary.txt";

        public GameEngine(Player player)
        {
            this.Player = player;
            this.PlayerCommand = new CommandManager();
            this.ChoiceStrategy = new ChoiceRandom();
        }

        public void Initialize()
        {
            Console.Clear();
            this.Player.AttemptsToGuess = InitialPlayerScore;
            this.NumberOfRevealedLetters = InitialRevealedLetters;
            this.PlayerCommand.HasHelpUsed = false;
            this.Start();
        }

        private void Start()
        {
            SecretWordManager wordsManager = new SecretWordManager();
            wordsManager.LoadAllSecretWords(PathToSecretWordsDatabase);

            List<string> allWords = wordsManager.GetAllSecretWords();
            IWord secretWord = new ProxyWord(ChoiceWord(this.ChoiceStrategy, allWords));
            this.Welcome();
            this.GamePlay(secretWord);
        }

        private string ChoiceWord(ChoiceStrategy choiceStrategy, List<string> words)
        {
            string chosenSecretWord = choiceStrategy.Choice(words);
            return chosenSecretWord;
        }

        private void Welcome()
        {
            Console.WriteLine("Welcome to \"Hangman\" game. Please try to guess my secret word.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat and 'exit' to quit the game.");
            Console.WriteLine("Maximum attempts to choice the word: {0}\n", MaxPlayerAttempts);
        }

        private void GamePlay(IWord word)
        {
            while (this.NumberOfRevealedLetters < word.Content.Length && this.Player.AttemptsToGuess < 10)
            {
                Console.WriteLine("The secret word is:{0}", word.PrintView);

                InputData(word);
            }
            GameOver(word);
        }

        private void InputData(IWord word)
        {
            char playerLetter;
            while (true)
            {
                Console.Write("Enter your guess or command:");
                string playerChoise = Console.ReadLine().ToLower();
                if (playerChoise == String.Empty)
                {
                    continue;
                }
                playerLetter = playerChoise.ToLower()[0];
                if (playerChoise.Length > 1)
                {
                    if (!CheckCommand(playerChoise, word))
                    {
                        Console.WriteLine("Incorrect guess or command!");
                    }
                    if (this.NumberOfRevealedLetters == word.WordLength)
                    {
                        break;
                    }
                }
                else
                {
                    if (Char.IsLetter(playerLetter))
                    {
                        CheckLetterAccordance(word, playerLetter);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect guess or command!");
                    }
                    break;
                }
            }

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
                word.PrintView = this.PlayerCommand.Help(word);
                this.NumberOfRevealedLetters++;
                this.PlayerCommand.HasHelpUsed = true;
                if (this.NumberOfRevealedLetters < word.WordLength)
                {
                    Console.WriteLine("The secret word is:{0}", word.PrintView);
                }
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

        private void CheckLetterAccordance(IWord word, char playerLetter)
        {
            bool isMatch = false;
            bool isRevealed = false;

            char[] wordAsChars = word.PrintView.ToCharArray();
            for (int i = 0; i < word.WordLength; i++)
            {
                if (playerLetter == word.Content[i])
                {
                    if (word.RevealedCharacters[i])
                    {
                        isRevealed = true;
                        continue;
                    }
                    wordAsChars[i] = word.Content[i];
                    isMatch = true;
                    word.RevealedCharacters[i] = true;
                    this.NumberOfRevealedLetters++;
                }
            }

            word.PrintView = new string(wordAsChars);

            if (isMatch)
            {
                Console.WriteLine("Good job! You revealed {0} letters. Your mistakes are: {1}", this.NumberOfRevealedLetters, this.Player.AttemptsToGuess);
            }
            else if (isRevealed)
            {
                Console.WriteLine("The letter '{0}' was revealed", playerLetter);
            }
            else
            {
                this.Player.AttemptsToGuess++;
                Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\"). Your mistakes are: {1}", playerLetter, this.Player.AttemptsToGuess);
            }
        }

        public void GameOver(IWord word)
        {
            if (this.Player.AttemptsToGuess == MaxPlayerAttempts)
            {
                Console.WriteLine("You lost the game. Try again.");
            }
            else
            {
                if (this.PlayerCommand.HasHelpUsed)
                {
                    Console.WriteLine("You won with {0} mistakes but you have cheated. You are not allowed to enter into the scoreboard", this.Player.AttemptsToGuess);
                    Console.WriteLine("The secret word is:  {0}", String.Join(" ", word.Content.ToCharArray()));
                }
                else
                {
                    Console.WriteLine("You won with {0} mistakes", this.Player.AttemptsToGuess);
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
            const string topScoresDataPath = @"../../Resources/topScores.txt";

            ScoreBoard topScores = new ScoreBoard();
            topScores.Source = topScoresDataPath;
            topScores.Load();
            if (this.Player.AttemptsToGuess < topScores.TopScores.Values.Last())
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
