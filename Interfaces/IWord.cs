namespace HangmanSix
{
    public interface IWord
    {
        string Content { get; set; }
        bool[] RevealedCharacters { get; set; }
        int NumberOfRevealedLetters { get; set; }
        int WordLength { get; set; }
        string PrintView { get; set; }
        string Print();

    }
}
