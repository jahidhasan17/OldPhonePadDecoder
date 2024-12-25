namespace OldPhonePadDecoder;

public class Decoder
{
    private readonly Keyboard Keyboard;
    
    // This one store the previous typed key result.
    private string PreviousResult;
    
    // This one store the current contineous letters.
    private string OngoingTypedKeys;
    
    // This one store the result of the current type letters.
    private string ResultOfOngoingTypedKeys;

    public Decoder(Keyboard keyboard)
    {
        Keyboard = keyboard;
        PreviousResult = string.Empty;
        OngoingTypedKeys = string.Empty;
        ResultOfOngoingTypedKeys = string.Empty;
    }

    public void PressKey(char buttonKey)
    {
        if (buttonKey == '#')
        {
            HandleSendButton(buttonKey);
            return;
        }

        if (buttonKey == '*')
        {
            HandleBackspaceButton(buttonKey);
        }

        if (buttonKey == ' ')
        {
            HandleSpace();

            return;
        }

        HandleButtonThatAddLetterInDisplay(buttonKey);
    }
    
    public string GetCurrentResult()
    {
        return PreviousResult + ResultOfOngoingTypedKeys;
    }

    private void HandleSendButton(char key)
    {
        return;
    }

    private void HandleBackspaceButton(char buttonKey)
    {
        var command = Keyboard.GetCommand(buttonKey);
        
        /*
         * We need to check from where we remove the letter.
         * Case - 1: If we already on the typing some letter and at the same we type backspace(*), in that case
                   we need to remove the letter from the current typing result (ResultOfOngoingTypedKeys).
         * Case - 2: If we currently don't type anything and we type backspace(*), in that case we need to remove
                   the letter from the previous typing result (PreviousResult).
         */
        if (!string.IsNullOrEmpty(ResultOfOngoingTypedKeys))
        {
            command.Execute(OngoingTypedKeys, ref ResultOfOngoingTypedKeys);
        }
        else
        {
            command.Execute(OngoingTypedKeys, ref PreviousResult);
        }
        
        OngoingTypedKeys = string.Empty;
        ResultOfOngoingTypedKeys = string.Empty;
    }

    private void HandleSpace()
    {
        ResetOngoingType();
    }

    private void HandleButtonThatAddLetterInDisplay(char buttonKey)
    {
        /*
         * If current key is the same as previous typing key without any pause, then we can update the display without resetting the ongoing typing.
         * If the current is not the same as previous typing letter/key, first we need to save and reset the previous typing, then we need to update the current type key.
         */
        if (string.IsNullOrEmpty(OngoingTypedKeys) || buttonKey == OngoingTypedKeys.Last())
        {
            UpdateOngoingTypedKeys(buttonKey);
        }
        else
        {
            ResetOngoingType();
            UpdateOngoingTypedKeys(buttonKey);
        }
        
        var command = Keyboard.GetCommand(buttonKey);
        command.Execute(OngoingTypedKeys, ref ResultOfOngoingTypedKeys);
    }
    
    private void UpdateOngoingTypedKeys(char buttonKey)
    {
        OngoingTypedKeys += buttonKey;
    }

    private void ResetOngoingType()
    {
        OngoingTypedKeys = string.Empty;
        
        if (!string.IsNullOrEmpty(ResultOfOngoingTypedKeys))
        {
            PreviousResult += ResultOfOngoingTypedKeys;
        }
        
        ResultOfOngoingTypedKeys = string.Empty;
    }
}