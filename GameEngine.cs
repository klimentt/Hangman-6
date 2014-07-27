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

        public void InitializeData()
        {
            Console.Clear();
            this.CheckManager = new CheckManager(this.Player);
            this.ChoiceStrategy = new ChoiceRandom();
            this.ScoreBoard = new ScoreBoard();
            this.Player.AttemptsToGuess = InitialPlayerScore;
            this.CheckManager.HasHelpUsed = false;
            this.StartGame();
        }

        /// <summary>
        /// Loads the secret word through the selected choice strategy and starts the gameplay.
        /// </summary>
        private void StartGame()
        {
            SecretWordManager wordsManager = new SecretWordManager();
            wordsManager.LoadAllSecretWords(PathToSecretWordsDatabase);

            List<string> allWords = wordsManager.GetAllSecretWords();
            IWord secretWord = new ProxyWord(this.ChoiceWord(this.ChoiceStrategy, allWords));
            this.CheckManager.DefineCommands(secretWord);
            UIMessages.WelcomeMessage(MaxPlayerAttempts);
            this.StartGamePlay(secretWord);
        }

        private string ChoiceWord(ChoiceStrategy choiceStrategy, List<string> words)
        {
            string chosenSecretWord = choiceStrategy.Choice(words);
            return chosenSecretWord;
        }

        /// <summary>
        /// Check whether the player has still available guesses or not. 
        /// </summary>
        /// <param name="word"></param>
        private void StartGamePlay(IWord word)
        {
            while (word.NumberOfRevealedLetters < word.Content.Length && this.Player.AttemptsToGuess < 10)
            {
                UIMessages.SecretWordMessage(word.PrintView, false);
                this.InputData(word);
            }

            this.GameOver(word);
        }
        /// <summary>
        /// Process the player guess. Handle commands, if the player decides to use any. If the player input is not a letter or command, an exception is thrown.  
        /// </summary>
        /// <param name="word"></param>
        private void InputData(IWord word)
        {
            while (true)
            {
                UIMessages.InviteForGuessOrCommandMessage();
                string playerChoice = Console.ReadLine().ToLower();

                if (playerChoice == string.Empty)
                {
                    continue;
                }

                char playerLetter = playerChoice.ToLower()[0];
                if (playerChoice.Length > 1)
                {
                    if (!this.CheckManager.CheckCommand(playerChoice, word))
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
                UIMessages.GuessAllWordMessage(this.Player.AttemptsToGuess);
                UIMessages.SecretWordMessage(word.Content, true);
                this.ScoreBoard.Update(this.Player);
                this.ScoreBoard.Print();
            }

            UIMessages.PressAnyKeyMessage();
            Console.ReadKey();
            this.InitializeData();
        }
    }
}
