using OldPhonePadDecoder.Models;

namespace OldPhonePadDecoder.Commands;

public class NormalButtonPressCommand : ICommand
{
    private NormalButton button;

    public NormalButtonPressCommand(NormalButton button)
    {
        this.button = button;
    }

    public void Execute(string input, ref string output)
    {
        ValidateInput(input);
        
        int positionOfChar = (input.Length - 1) % button.MaximumNumberOfCharacter;

        output = button.LettersToBeDisplayed[positionOfChar].ToString();
    }

    private void ValidateInput(string input)
    {
        int length = input.Length;

        for (int i = 1; i < length; i++)
        {
            if (input[i - 1] != input[i])
            {
                throw new Exception("All Letter in a input should be same.");
            }
        }
    }
}