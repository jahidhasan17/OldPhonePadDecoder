# Some Assumptions
- We assume that the letter will always be displayed as uppercase.
- The input will not contain `0` or any symbols apart from `1 to 9`, `*` `#`. If they exist, an exception will be thrown.

# Algorithm
- We divided the typing letters into two buffers: the ongoing typing letters buffer and the previous typing letters buffer.
- We keep two variables for storing the results of these two types of letters.
- When a key is pressed, we check three conditions.
  - If the letter is `*`, we handle two cases.
    - If there is ongoing typing, we remove the letter from the ongoing typing result.
    - If there isn’t any ongoing typing, we remove the letter from the previous typing result.
  - If the letter is `' '`, we save the current ongoing typing result to the previous typing result and reset the ongoing typing buffer.
  - If the letter is Any number from `1` to `9`, then we handle two cases.
    - If the current letter is the same as the previous one, we add it to the ongoing typing letters and update the result.
    - If the current letter is not the same as the previous one, we save the current state, reset it, and update the ongoing typing with the current key.
  - If the letter is #, we do nothing.

The following code shows the main part of the algorithm - 

```C#
public static string OldPhonePad(string input)
{
    var decoder = new Decoder(new Keyboard());
    
    foreach (var c in input)
    {
        decoder.PressKey(c);
    }

    return decoder.GetCurrentResult();
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
        return;
    }

    if (buttonKey == ' ')
    {
        HandleSpace();

        return;
    }

    HandleButtonThatAddLetterInDisplay(buttonKey);
}

private void HandleBackspaceButton(char buttonKey)
{
    var command = Keyboard.GetCommand(buttonKey);
    
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

private void HandleButtonThatAddLetterInDisplay(char buttonKey)
{
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

private void HandleSpace()
{
    ResetOngoingType();
}

private void HandleSendButton(char key)
{
    return;
}
```

# Complexity
#### Time Complexity : O(n), n = length of input
#### Space Complexity: O(n), n = length of input

# Low Level Design Document

We used the `Command Design Pattern` to design our Old Phone Pad Decoder. There are 3 main components of this design.
- Set of Commands Class : We have a command class for each type of button press. This command encapsulate the action of each button press.
  - [BackspaceButtonPressCommand](OldPhonePadDecoder/Commands/BackspaceButtonPressCommand.cs) : This command will be invoked when we press `*`. This command will remove last letter from the display.
  - [NormalButtonPressCommand](OldPhonePadDecoder/Commands/NormalButtonPressCommand.cs): This command will be invoked when we press any number from `1` to `9`. This command will decode the correct letter from the keys.
  - [SendButtonPressCommand](OldPhonePadDecoder/Commands/SendButtonPressCommand.cs): Currently, it does nothing as we don’t have any requirements for this.

- [Keyboard.cs](OldPhonePadDecoder/Keyboard.cs) : This class is responsible for assigning command to each button.
- [Decoder.cs](OldPhonePadDecoder/Decoder.cs): This class is maintaining some buffer for the ongoing typing and previous typing, and reset the current state, save the current state and generate the overall output.

# Class diagram

![Untitled Diagram drawio](https://github.com/user-attachments/assets/882a6fc5-8f44-4ecf-8951-e4a54aaa16c9)

# Unit Test
- [OldPhonePadTypingTests.cs](OldPhonePadDecoder.Tests/OldPhonePadTypingTests.cs) - This test contains all the tests for OldPhonePadTyping.OldPhonePad."
- [KeyboardTest.cs](OldPhonePadDecoder.Tests/KeyboardTest.cs) - This test contains the tests for resolving the correct command for each key of the keyboard
- [NormalButtonPressCommandTest.cs](OldPhonePadDecoder.Tests/NormalButtonPressCommandTest.cs) - This test contains the tests for button `1` to `9`
- [BackspaceButtonPressCommandTest.cs](OldPhonePadDecoder.Tests/BackspaceButtonPressCommandTest.cs) - This test contains the tests for button `*`
