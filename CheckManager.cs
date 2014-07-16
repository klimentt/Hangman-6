namespace HangmanSix
{
    public class CheckManager
    {
        public CheckManager(Player player)
        {
            this.Player = player;
            this.CommandManager = new CommandManager();
            this.HasHelpUsed = false;
        }

        public ICommand HelpCommand { get; set; }

        public ICommand TopCommand { get; set; }

        public ICommand RestartCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        public CommandManager CommandManager { get; set; }

        public Player Player { get; set; }

        public bool HasHelpUsed { get; set; }

        public bool CheckCommand(string playerChoise, IWord word)
        {
            if (playerChoise.ToLower() == Command.Top.ToString().ToLower())
            {
                this.CommandManager.Proceed(this.TopCommand);
                return true;
            }

            if (playerChoise.ToLower() == Command.Help.ToString().ToLower())
            {
                this.CommandManager.Proceed(this.HelpCommand);
                this.HasHelpUsed = true;
                if (word.NumberOfRevealedLetters < word.WordLength)
                {
                    UIMessages.SecretWordMessage(word.PrintView, false);
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

            return false;
        }

        public void CheckLetterAccordance(IWord word, char playerLetter)
        {
            bool isMatch = false;

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
        }
    }
}
