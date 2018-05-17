using System;

namespace RecordKeeper.CLI.InputHandlers
{
    public class Exit : IInputHandler
    {
        public ConsoleKey TriggerKey => ConsoleKey.E;
        public string Message => "Exit";
        public bool Handle()
        {
            return true;
        }
    }
}
