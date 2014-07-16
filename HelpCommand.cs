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

        public void Execute()
        {
            string newWord = this.Word.PrintView;
            for (int characterIndex = 0; characterIndex < newWord.Length; characterIndex++)
            {
                if (!char.IsLetter(newWord[characterIndex]))
                {
                    UIMessages.RevealingNextLetterMessage(this.Word.Content[characterIndex]);
                    newWord = ReplaceLetter(newWord, this.Word.Content, characterIndex);
                    this.Word.RevealedCharacters[characterIndex] = true;
                    break;
                }
            }

            this.Word.PrintView = newWord;
        }

        private static string ReplaceLetter(string dashword, string word, int possitionToReplace)
        {
            int currentPossition = 0;

            StringBuilder newWord = new StringBuilder();

            while (currentPossition != dashword.Length)
            {
                if (currentPossition != possitionToReplace)
                {
                    newWord.Append(dashword[currentPossition]);
                }
                else if (currentPossition == possitionToReplace)
                {
                    newWord.Append(word[currentPossition]);
                }

                currentPossition++;
            }

            return newWord.ToString();
        }
    }
}
