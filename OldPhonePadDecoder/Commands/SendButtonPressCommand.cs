using OldPhonePadDecoder.Models;

namespace OldPhonePadDecoder.Commands;

public class SendButtonPressCommand : ICommand
{
    private SendButton button;

    public SendButtonPressCommand(SendButton button)
    {
        this.button = button;
    }

    public void Execute(string input, ref string output)
    {
        throw new NotImplementedException();
    }
}