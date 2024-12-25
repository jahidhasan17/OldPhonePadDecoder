# Some Assumption
- We assume that the letter will be displayed always as capital.
- The input won't be contained `0` or any symbol apart from `1` to `9`. If they are exist we will get exception.

# Algorithm
- We devided the type letter into two part - Ongoing typing letter and previous typing letter
- We keeping two variables for stroing the result of these two types of letters
- When a key is press, we check three condition
  - If the letter is `*`, then we check two cases
    - If there is any Ongoing typing, we remove the letter from the ongoing typing result.
    - If there isn't any Ongoing typing, we remove the latter from the previous typing result.
  - If the letter is `' '`, we save the current ongoing typing result to the previous typing result and reset the ongoing typing.
  - If the letter is Any number from `1` to `9`, then we check two cases
    - If the current latter is the same as previous one, then add the letter to the ongoing typings latters and we update our result of ongoing typing letter.
    - If the current latter is not same as the previous one, then we save the previous state, reset the previous state and update the ongoing typing with the current key.
  - If the letter is `#`, not doing anythings.
 

# Low Level Design Document

We used the command design pattern to design out Old Phone Pad Decoder. There are 3 main component of this design.
- Set of Commands Class : We have a command class for each type of button press. This command encapsulate the action of each button press.
  - BackspaceButtonPressCommand : This commands will be invoked when we press `*`. This command will remove last letter from the display.
  - NormalButtonPressCommand: This commands will be invoked when we press any number from `1` to `9`. This command will decoded the correct letter from the keys.

- Keyboard Class :
- Decoder Class:

# Class diagram

![Untitled Diagram drawio](https://github.com/user-attachments/assets/882a6fc5-8f44-4ecf-8951-e4a54aaa16c9)
