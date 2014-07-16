namespace HangmanSix
{
    using System.Text;

    public class HelpCommand : ICommand
    {
        public IWord Word { get; set; }

        public HelpCommand(IWord word)
        {
            this.Word = word;
        }

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

        //public string Help(IWord word)
        //{
        //    string newWord = word.PrintView;
        //    for (int characterIndex = 0; characterIndex < newWord.Length; characterIndex++)
        //    {
        //        if (!char.IsLetter(newWord[characterIndex]))
        //        {
        //            UIMessages.RevealingNextLetterMessage(word.Content[characterIndex]);
        //            newWord = ReplaceLetter(newWord, word.Content, characterIndex);
        //            word.RevealedCharacters[characterIndex] = true;
        //            break;
        //        }
        //    }

        //    return newWord;
        //}

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
