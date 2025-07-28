using NUnit.Framework;
using OldPhonePadDecoder.Commands;

namespace OldPhonePadDecoder.Tests;

public class KeyboardTest
{
    [TestCase('1')]
    [TestCase('2')]
    [TestCase('3')]
    [TestCase('4')]
    [TestCase('5')]
    [TestCase('6')]
    [TestCase('7')]
    [TestCase('8')]
    [TestCase('9')]
    public void GetCommand_ValidInputForNormalButtonPressCommand_GetCorrectNormalButtonPressCommandInstance(char c)
    {
        var keyboard = new Keyboard();

        var command = keyboard.GetCommand(c);

        Assert.That(command, Is.TypeOf<NormalButtonPressCommand>());
    }
    
    [TestCase('*')]
    public void GetCommand_ValidInputForBackspaceButtonPressCommand_GetCorrectBackspaceButtonPressCommandInstance(char c)
    {
        var keyboard = new Keyboard();

        var command = keyboard.GetCommand(c);
        
        Assert.That(command, Is.TypeOf<BackspaceButtonPressCommand>());
    }
    
    [TestCase('#')]
    public void GetCommand_ValidInputForSendButtonPressCommand_GetCorrectSendButtonPressCommandInstance(char c)
    {
        var keyboard = new Keyboard();

        var command = keyboard.GetCommand(c);
        
        Assert.That(command, Is.TypeOf<SendButtonPressCommand>());
    }

    [TestCase('0')]
    [TestCase('^')]
    [TestCase('@')]
    [TestCase('$')]
    [TestCase('`')]
    [TestCase('a')]
    [TestCase('b')]
    [TestCase('c')]
    [TestCase('Z')]
    public void GetCommand_InValidInput_ShouldThrowError(char c)
    {
        var keyboard = new Keyboard();

        Assert.Throws<Exception>(() => keyboard.GetCommand(c));
    }
}