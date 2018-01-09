# KD.AutoBot

KD.AutoBot is a library which give User a possibility to create a self-learning Robot for specified application / game which can simulate a User behavior. Robot can simulate everything that User can do.

Library has been written in .NET Standard (components written for specific libraries / systems may be written in .NET Core or .NET Framework).

KD.AutoBot:
---
- [X] Don't need to have a reference to a project / process it should connect to !!!
- [X] Should always be assemble using predefined [IAutoBotBuilder](https://github.com/Sejoslaw/KD.AutoBot/blob/master/KD.AutoBot/IAutoBotBuilder.cs)
- [X] Can save / load data to / from specified source.
- [X] Can connect to running process (through platform native API).
- [X] Can read data from process controls (TextBoxes, Buttons, etc.) and their childs.
- [X] Can click buttons !!!
- [X] Can simulate User input (Keyboard, Mouse, new specially prepared device) using system native API.
- [X] Will learn which action is right. But this is something what needs to be setup programmatically (see: [ILearningModule](https://github.com/Sejoslaw/KD.AutoBot/blob/master/KD.AutoBot/AI/ILearningModule.cs)).

TODO:
---
- [ ] Add predefined logging options in additional library.
- [ ] Extend [IAutoBot](https://github.com/Sejoslaw/KD.AutoBot/blob/master/KD.AutoBot/IAutoBot.cs) and [IModule](https://github.com/Sejoslaw/KD.AutoBot/blob/master/KD.AutoBot/IModule.cs) with events.
- [ ] Finish porting to TicTacToe game.
- [ ] Clean everything from TODO.txt file.

Solution overview:
---
Logical folder | Project title | .NET Platform | Description
---------------|---------------|---------------|-------------
[Core](https://github.com/Sejoslaw/KD.AutoBot/tree/master/Core) | [KD.AutoBot](https://github.com/Sejoslaw/KD.AutoBot/tree/master/KD.AutoBot) | .NET Standard 2.0 | Contains core interfaces with abstract implementation.
[Core](https://github.com/Sejoslaw/KD.AutoBot/tree/master/Core) | [KD.AutoBot.AI](https://github.com/Sejoslaw/KD.AutoBot/tree/master/KD.AutoBot.AI) | .NET Standard 2.0 | Contains abstract layer for Robot learning.
[Core](https://github.com/Sejoslaw/KD.AutoBot/tree/master/Core) | [KD.AutoBot.AI.Impl](https://github.com/Sejoslaw/KD.AutoBot/tree/master/KD.AutoBot.AI.Impl) | .NET Standard 2.0 | [W.I.P.] Contains implementations for Robot learning.
[PlatformSpecific\Windows](https://github.com/Sejoslaw/KD.AutoBot/tree/master/PlatformSpecific/Windows) | [KD.AutoBot.Connection.Windows](https://github.com/Sejoslaw/KD.AutoBot/tree/master/PlatformSpecific/Windows/KD.AutoBot.Connection.Windows) | .NET Standard 2.0 | Contains calls to Win32Api related to connecting to Windows processes.
[PlatformSpecific\Windows](https://github.com/Sejoslaw/KD.AutoBot/tree/master/PlatformSpecific/Windows) | [KD.AutoBot.Input.Windows](https://github.com/Sejoslaw/KD.AutoBot/tree/master/PlatformSpecific/Windows/KD.AutoBot.Input.Windows) | .NET Standard 2.0 | Contains calls to Win32Api related to sending / simulating User input.
[Game](https://github.com/Sejoslaw/KD.AutoBot/tree/master/Game) | | | Contains various games and KD.AutoBot implementations for them.
[Game\TicTacToe](https://github.com/Sejoslaw/KD.AutoBot/tree/master/Game/TicTacToe) | | .NET Framework 4.6.1 | Contains all projects for TicTacToe game and AutoBot implementation.
[Tests](https://github.com/Sejoslaw/KD.AutoBot/tree/master/Tests) | | | Contains all tests - projects which starts with prefix "Test_".
