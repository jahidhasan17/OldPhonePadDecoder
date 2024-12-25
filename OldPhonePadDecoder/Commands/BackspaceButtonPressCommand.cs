using OldPhonePadDecoder.Models;

namespace OldPhonePadDecoder.Commands;

public class BackspaceButtonPressCommand : ICommand
{
    private BackspaceButton button;

    public BackspaceButtonPressCommand(BackspaceButton button)
    {
        this.button = button;
    }

    public void Execute(string input, ref string output)
    {
        if (!string.IsNullOrEmpty(output))
        {
            output = output.Substring(0, output.Length - 1);
        }
    }
}