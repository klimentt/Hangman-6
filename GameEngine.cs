namespace HangmanSix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GameEngine
    {
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

        public int NumberOfRevealedLetters { get; set; }

        public CommandManager PlayerCommand { get; set; }

        public ChoiceStrategy ChoiceStrategy { get; set; }

        private Player Player { get; set; }

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
            IWord secretWord = new ProxyWord(this.ChoiceWord(this.ChoiceStrategy, allWords));
            UIMessages.WelcomeMessage(MaxPlayerAttempts);
            this.GamePlay(secretWord);
        }

        private string ChoiceWord(ChoiceStrategy choiceStrategy, List<string> words)
        {
            string chosenSecretWord = choiceStrategy.Choice(words);
            return chosenSecretWord;
        }

        private void GamePlay(IWord word)
        {
            while (this.NumberOfRevealedLetters < word.Content.Length && this.Player.AttemptsToGuess < 10)
            {
                UIMessages.SecretWordMessage(word.PrintView, false);
                this.InputData(word);
            }

            this.GameOver(word);
        }

        private void InputData(IWord word)
        {
            while (true)
            {
                UIMessages.InviteForGuessOrCommandMessage();
                string playerChoise = Console.ReadLine().ToLower();
                if (playerChoise == string.Empty)
                {
                    continue;
                }

                char playerLetter = playerChoise.ToLower()[0];
                if (playerChoise.Length > 1)
                {
                    if (!this.CheckCommand(playerChoise, word))
                    {
                        UIMessages.IncorrectInputMessage();
                    }

                    if (this.NumberOfRevealedLetters == word.WordLength)
                    {
                        break;
                    }
                }
                else
                {
                    if (char.IsLetter(playerLetter))
                    {
                        this.CheckLetterAccordance(word, playerLetter);
                    }
                    else
                    {
                        UIMessages.IncorrectInputMessage();
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
                    UIMessages.SecretWordMessage(word.PrintView, false);
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
                        break;
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
                UIMessages.RevealedLetterMessage(this.NumberOfRevealedLetters, this.Player.AttemptsToGuess);
            }
            else if (isRevealed)
            {
                UIMessages.RepeatRevealedLetterMessage(playerLetter);
            }
            else
            {
                this.Player.AttemptsToGuess++;
                UIMessages.NotGuessedLetterMessage(playerLetter, this.Player.AttemptsToGuess);
            }
        }

        private void GameOver(IWord word)
        {
            if (this.Player.AttemptsToGuess == MaxPlayerAttempts)
            {
                UIMessages.LostGameMessage();
            }
            else
            {
                if (this.PlayerCommand.HasHelpUsed)
                {
                    UIMessages.GuessAllWordMessage(this.Player.AttemptsToGuess, true);
                    UIMessages.SecretWordMessage(word.Content, true);
                }
                else
                {
                    UIMessages.GuessAllWordMessage(this.Player.AttemptsToGuess, false);
                    UIMessages.SecretWordMessage(word.Content, true);
                    this.UpdateAndPrintScoreBoard();
                }
            }

            UIMessages.PressAnyKeyMessage();
            Console.ReadKey();
            this.Initialize();
        }

        private void UpdateAndPrintScoreBoard()
        {
            const string TopScoresDataPath = @"../../Resources/topScores.txt";

            ScoreBoard topScores = new ScoreBoard();
            topScores.Source = TopScoresDataPath;
            topScores.Load();
            if (this.Player.AttemptsToGuess < topScores.TopScores.Values.Last())
            {
                while (true)
                {
                    UIMessages.EnterPlayerNameMessage();
                    this.Player.Name = Console.ReadLine();
                    if (this.Player.Name != string.Empty)
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
