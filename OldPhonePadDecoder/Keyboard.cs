using OldPhonePadDecoder.Commands;
using OldPhonePadDecoder.Models;

namespace OldPhonePadDecoder;

public class Keyboard
{
    private Dictionary<char, ICommand> commands;

    public Keyboard()
    {
        commands = new Dictionary<char, ICommand>();
        
        Initialize();
    }

    /// <summary>
    /// Return the command against the key. If the keyboard doesn't know this key, it will throw an error.
    /// </summary>
    /// <param name="key">The number that we pass on the keyboard of the Phone.</param>
    /// <returns>Instance of the <see cref="ICommand"/></returns>
    /// <exception cref="Exception"> If the keyboard doesn't know this key, it will throw an error.</exception>
    public ICommand GetCommand(char key)
    {
        if (!commands.ContainsKey(key))
        {
            throw new Exception("The Keyboard doesn't know this key.");
        }

        return commands[key];
    }

    public void SetCommand(char key, ICommand command)
    {
        if (commands.ContainsKey(key))
        {
            throw new InvalidOperationException("This button already occupied.");
        }
        
        commands.Add(key, command);
    }

    /// <summary>
    /// Initializing all the command against the key of the keyboard.
    /// </summary>
    private void Initialize()
    {
        commands.Add('1', new NormalButtonPressCommand(new NormalButton
        {
            LettersToBeDisplayed = ['&', '\'', '(']
        }));
        
        commands.Add('2', new NormalButtonPressCommand(new NormalButton
        {
            LettersToBeDisplayed = ['A', 'B', 'C']
        }));
        
        commands.Add('3', new NormalButtonPressCommand(new NormalButton
        {
            LettersToBeDisplayed = ['D', 'E', 'F']
        }));
        
        commands.Add('4', new NormalButtonPressCommand(new NormalButton
        {
            LettersToBeDisplayed = ['G', 'H', 'I']
        }));
        
        commands.Add('5', new NormalButtonPressCommand(new NormalButton
        {
            LettersToBeDisplayed = ['J', 'K', 'L']
        }));
        
        commands.Add('6', new NormalButtonPressCommand(new NormalButton
        {
            LettersToBeDisplayed = ['M', 'N', 'O']
        }));
        
        commands.Add('7', new NormalButtonPressCommand(new NormalButton
        {
            LettersToBeDisplayed = ['P', 'Q', 'R', 'S']
        }));
        
        commands.Add('8', new NormalButtonPressCommand(new NormalButton
        {
            LettersToBeDisplayed = ['T', 'U', 'V']
        }));
        
        commands.Add('9', new NormalButtonPressCommand(new NormalButton
        {
            LettersToBeDisplayed = ['W', 'X', 'Y', 'Z']
        }));
        
        commands.Add('*', new BackspaceButtonPressCommand(new BackspaceButton()));
        
        commands.Add('#', new SendButtonPressCommand(new SendButton()));
    }
}