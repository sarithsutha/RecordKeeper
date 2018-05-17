using System;

namespace RecordKeeper.CLI.InputHandlers
{
    interface IInputHandler
    {
        ConsoleKey TriggerKey { get; }
        String  Message { get; }
        bool Handle();
    }
}
