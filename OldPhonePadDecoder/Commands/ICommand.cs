namespace OldPhonePadDecoder.Commands;

public interface ICommand
{
    /// <summary>
    /// Executes a command when a key is pressed.
    /// </summary>
    /// <param name="input">A series of letters of the current key of the command.</param>
    /// <param name="output">The result after execute the commands.</param>
    void Execute(string input, ref string output);
}