using NUnit.Framework;
using OldPhonePadDecoder.Commands;

namespace OldPhonePadDecoder.Tests;

public class BackspaceButtonPressCommandTest
{
    [TestCase("*", "ABC","AB")]
    [TestCase("*", "UIIIIIII", "UIIIIII")]
    [TestCase("*", "U", "")]
    [TestCase("*", "", "")]
    public void Execute_ValidInput_ShouldCorrectDecodedValue(string input, string output, string expectedOutput)
    {
        var command = GetSut(input.Last());
        
        command.Execute(input, ref output);
        
        Assert.That(output, Is.EqualTo(expectedOutput));
    }
    
    private ICommand GetSut(char c)
    {
        var keyboard = new Keyboard();

        return keyboard.GetCommand(c);
    }
}