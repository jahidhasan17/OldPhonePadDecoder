using NUnit.Framework;
using OldPhonePadDecoder.Commands;

namespace OldPhonePadDecoder.Tests;

public class NormalButtonPressCommandTest
{
    [TestCase("2", "A")]
    [TestCase("55555555", "K")]
    [TestCase("7777", "S")]
    public void Execute_ValidInput_ShouldCorrectDecodedValue(string input, string expectedOutput)
    {
        var command = GetSut(input.Last());

        string output = string.Empty;
        
        command.Execute(input, ref output);
        
        Assert.That(output, Is.EqualTo(expectedOutput));
    }

    [TestCase("22333", "All character should be same")]
    [TestCase("55 55", "All character should be same.")]
    public void Execute_InValidInput_ShouldThrowException(string input, string message)
    {
        var command = GetSut(input.Last());

        string output = string.Empty;

        Assert.Throws<Exception>(() => command.Execute(input, ref output), message);
    }

    private ICommand GetSut(char c)
    {
        var keyboard = new Keyboard();

        return keyboard.GetCommand(c);
    }
}