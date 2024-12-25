namespace OldPhonePadDecoder.Models;

public class NormalButton : Button
{
    /// <summary>
    /// The letters that we want to show using this button.
    /// </summary>
    public List<char> LettersToBeDisplayed { get; set; }

    public int MaximumNumberOfCharacter => LettersToBeDisplayed.Count;
}