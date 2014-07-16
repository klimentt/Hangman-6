namespace HangmanSix
{
    using System;

    public static class UIMessages
    {
        public static void WelcomeMessage(int maxPlayerAttempts)
        {
            Console.WriteLine("Welcome to \"Hangman\" game. Please try to guess my secret word.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat, 'used' to see all used letters (in red) and 'exit' to quit the game.");
            Console.WriteLine("Maximum attempts to guess the word: {0}\n", maxPlayerAttempts);
        }

        public static void SecretWordMessage(string word, bool isGameOver)
        {
            Console.WriteLine("The secret word is:{0}{1}", isGameOver ? new String(' ', 3) : String.Empty, isGameOver ? String.Join(" ", word.ToCharArray()) : word);
        }

        public static void InviteForGuessOrCommandMessage()
        {
            Console.Write("Enter your guess or command:");
        }

        public static void IncorrectInputMessage()
        {
            Console.WriteLine("Incorrect guess or command!");
        }

        public static void RevealedLetterMessage(int revealedLetters, int attempts)
        {
            Console.WriteLine("Good job! You revealed {0} letters. Your mistakes are: {1}", revealedLetters, attempts);
        }

        public static void NotGuessedLetterMessage(char letter, int attempts)
        {
            Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\"). Your mistakes are: {1}", letter, attempts);

        }

        public static void LostGameMessage()
        {
            Console.WriteLine("You lost the game. Try again.");
        }

        public static void GuessAllWordMessage(int attempts, bool usedHelp)
        {
            Console.WriteLine("You won with {0} mistakes {1}", attempts, usedHelp ? "but you have cheated. You are not allowed to enter into the scoreboard" : String.Empty);
        }

        public static void PressAnyKeyMessage()
        {
            Console.WriteLine("Press any key to start a new game ...");
        }

        public static void EnterPlayerNameMessage()
        {
            Console.Write("Please enter you name: ");
        }

        public static void RevealingNextLetterMessage(char nextLetter)
        {
            Console.WriteLine("OK, I reveal for you the next letter '{0}'", nextLetter);
        }

        public static void ExitMessage()
        {
            Console.WriteLine("Good bye!");
        }
    }
}
