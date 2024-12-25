using NUnit.Framework;

namespace OldPhonePadDecoder.Tests;

public class OldPhonePadTypingTests
{
    [TestCase("222 2 222#", "CAC")]
    [TestCase("33#", "E")]
    [TestCase("4433555 555666#", "HELLO")]
    [TestCase("8 88777444666*664#", "TURING")]
    [TestCase("5566 *#", "K")]
    [TestCase("2222#", "A")]
    [TestCase("77777777777777777777#", "S")]
    [TestCase("5244 4444443333#", "JAHID")]
    [TestCase("1 11 111#", "&'(")]
    [TestCase("9************#", "")]
    [TestCase("* * * * * * * *#", "")]
    [TestCase("", "")]
    public void OldPhonePad_ValidInput_ShouldCorrectDecodedValue(string input, string expectedOutput)
    {
        var actualOutput = OldPhonePadTyping.OldPhonePad(input);
        
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [TestCase("&$23")]
    public void OldPhonePad_InValidInput_ShouldThrowError(string input)
    {
        Assert.Throws<Exception>(() => OldPhonePadTyping.OldPhonePad(input));
    }
}