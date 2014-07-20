using System.Collections.Generic;

namespace HangmanSix
{
    /// <summary>
    /// Holding all important checking methods
    /// </summary>
    public class CheckManager
    {
        /// <summary>
        /// Initialize a new instance of the HangmanSix.CheckManager class
        /// </summary>
        /// <param name="player"></param>
        public CheckManager(Player player)
        {
            this.Player = player;
            this.CommandManager = new CommandManager();
            this.HasHelpUsed = false;
            this.UsedLetters = new HashSet<char>();
        }
        
        public ICommand HelpCommand { get; set; }

        public ICommand TopCommand { get; set; }

        public ICommand RestartCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        public ICommand UsedCommand { get; set; }

        public CommandManager CommandManager { get; set; }

        public Player Player { get; set; }

        public bool HasHelpUsed { get; set; }

        public HashSet<char> UsedLetters { get; set; }
        
        public bool CheckCommand(string playerChoise, IWord word)
        {
            if (playerChoise.ToLower() == Command.Top.ToString().ToLower())
            {
                this.CommandManager.Proceed(this.TopCommand);
                return true;
            }

            if (playerChoise.ToLower() == Command.Help.ToString().ToLower())
            {
                if (HasHelpUsed == true)
                {
                    UIMessages.UsedHelpOptionMessage();
                    UIMessages.SecretWordMessage(word.PrintView, false);
                }
                else
                {
                    this.CommandManager.Proceed(this.HelpCommand);
                    this.HasHelpUsed = true;
                    if (word.NumberOfRevealedLetters < word.WordLength)
                    {
                        UIMessages.SecretWordMessage(word.PrintView, false);
                    }
                }

                return true;
            }

            if (playerChoise.ToLower() == Command.Restart.ToString().ToLower())
            {
                this.CommandManager.Proceed(this.RestartCommand);
                return true;
            }

            if (playerChoise.ToLower() == Command.Exit.ToString().ToLower())
            {
                this.CommandManager.Proceed(this.ExitCommand);
                return true;
            }

            if (playerChoise.ToLower() == Command.Used.ToString().ToLower())
            {
                this.CommandManager.Proceed(this.UsedCommand);
                return true;
            }

            return false;
        }

        public void CheckLetterAccordance(IWord word, char playerLetter)
        {
            bool isMatch = false;
            this.AddLetterInUsed(playerLetter);

            char[] wordAsChars = word.PrintView.ToCharArray();
            for (int i = 0; i < word.WordLength; i++)
            {
                if (playerLetter == word.Content[i])
                {
                    if (!word.RevealedCharacters[i])
                    {
                        wordAsChars[i] = word.Content[i];
                        isMatch = true;
                        word.RevealedCharacters[i] = true;
                    }
                }
            }

            word.PrintView = new string(wordAsChars);

            if (isMatch)
            {
                UIMessages.RevealedLetterMessage(word.NumberOfRevealedLetters, this.Player.AttemptsToGuess);
            }

            else
            {
                this.Player.AttemptsToGuess++;
                UIMessages.NotGuessedLetterMessage(playerLetter, this.Player.AttemptsToGuess);
            }
        }

        public void DefineCommands(IWord secretWord)
        {
            this.HelpCommand = new HelpCommand(secretWord);
            this.TopCommand = new TopCommand();
            this.RestartCommand = new RestartCommand();
            this.ExitCommand = new ExitCommand();
            this.UsedCommand = new UsedCommand(this.UsedLetters);
        }

        public void AddLetterInUsed(char letter)
        {
            if (!this.UsedLetters.Contains(letter))
            {
                this.UsedLetters.Add(letter);
            }
        }
    }
}
