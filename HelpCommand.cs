namespace HangmanSix
{
    using System.Text;

    public class HelpCommand : ICommand
    {
        public HelpCommand(IWord word)
        {
            this.Word = word;
        }

        public IWord Word { get; set; }

        /// <summary>
        /// Reveal the first occurance of not revealed letter of the secret word.
        /// </summary>
        public void Execute()
        {
            string newWord = this.Word.PrintView;
            for (int characterIndex = 0; characterIndex < newWord.Length; characterIndex++)
            {
                if (!char.IsLetter(newWord[characterIndex]))
                {
                    UIMessages.RevealingNextLetterMessage(this.Word.Content[characterIndex]);
                    newWord = ReplaceLetter(newWord, this.Word.Content[characterIndex], characterIndex);
                    this.Word.RevealedCharacters[characterIndex] = true;
                    break;
                }
            }

            this.Word.PrintView = newWord;
        }

        private static string ReplaceLetter(string dashword, char letter, int positionToReplace)
        {
            char[] newWord = dashword.ToCharArray();
            newWord[positionToReplace] = letter;

            return new string(newWord);
        }
    }
}
