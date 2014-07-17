namespace HangmanSix
{
    using System;
    using System.Collections.Generic;

    public class GameEngine
    {
        private const int InitialPlayerScore = 0;
        private const int MaxPlayerAttempts = 10;
        private const string PathToSecretWordsDatabase = @"../../Resources/secretWordsLibrary.txt";

        public GameEngine(Player player)
        {
            this.Player = player;
        }

        public CheckManager CheckManager { get; set; }

        public ChoiceStrategy ChoiceStrategy { get; set; }

        public ScoreBoard ScoreBoard { get; set; }

        private Player Player { get; set; }

        public void Initialize()
        {
            Console.Clear();
            this.CheckManager = new CheckManager(this.Player);
            this.ChoiceStrategy = new ChoiceRandom();
            this.ScoreBoard = new ScoreBoard();
            this.Player.AttemptsToGuess = InitialPlayerScore;
            this.CheckManager.HasHelpUsed = false;
            this.Start();
        }

        private void Start()
        {
            SecretWordManager wordsManager = new SecretWordManager();
            wordsManager.LoadAllSecretWords(PathToSecretWordsDatabase);

            List<string> allWords = wordsManager.GetAllSecretWords();
            IWord secretWord = new ProxyWord(this.ChoiceWord(this.ChoiceStrategy, allWords));
            this.CheckManager.DefineCommands(secretWord);
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
            while (word.NumberOfRevealedLetters < word.Content.Length && this.Player.AttemptsToGuess < 10)
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
                    if (!this.CheckManager.CheckCommand(playerChoise, word))
                    {
                        UIMessages.IncorrectInputMessage();
                    }

                    if (word.NumberOfRevealedLetters == word.WordLength)
                    {
                        break;
                    }
                }
                else
                {
                    if (char.IsLetter(playerLetter))
                    {
                        this.CheckManager.CheckLetterAccordance(word, playerLetter);
                    }
                    else
                    {
                        UIMessages.IncorrectInputMessage();
                    }

                    break;
                }
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
                if (this.CheckManager.HasHelpUsed)
                {
                    UIMessages.GuessAllWordMessage(this.Player.AttemptsToGuess, true);
                    UIMessages.SecretWordMessage(word.Content, true);
                }
                else
                {
                    UIMessages.GuessAllWordMessage(this.Player.AttemptsToGuess, false);
                    UIMessages.SecretWordMessage(word.Content, true);
                    this.ScoreBoard.Update(this.Player);
                }
            }

            UIMessages.PressAnyKeyMessage();
            Console.ReadKey();
            this.Initialize();
        }
    }
}
