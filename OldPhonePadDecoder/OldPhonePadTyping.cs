namespace OldPhonePadDecoder;

public class OldPhonePadTyping
{
    public static string OldPhonePad(string input)
    {
        var decoder = new Decoder(new Keyboard());
        
        foreach (var c in input)
        {
            decoder.PressKey(c);
        }

        return decoder.GetCurrentResult();
    }
}