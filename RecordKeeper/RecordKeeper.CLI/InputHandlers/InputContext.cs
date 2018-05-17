using RecordKeeper.Service;
using System;
using System.Collections.Generic;

namespace RecordKeeper.CLI.InputHandlers
{
    public class InputContext
    {
        private IRecordsService _recordsService;
        public InputContext(IRecordsService service)
        {
            _recordsService = service;

            IInputHandler inputHandler = new ImportFile(_recordsService);
            _inputHandlers.Add(inputHandler.TriggerKey, inputHandler);

            inputHandler = new OutputRecordsSortByGender(_recordsService);
            _inputHandlers.Add(inputHandler.TriggerKey, inputHandler);

            inputHandler = new OutputRecordsSortByDOB(_recordsService);
            _inputHandlers.Add(inputHandler.TriggerKey, inputHandler);

            inputHandler = new OutputRecordsSortByLastName(_recordsService);
            _inputHandlers.Add(inputHandler.TriggerKey, inputHandler);

            inputHandler = new Exit();
            _inputHandlers.Add(inputHandler.TriggerKey, inputHandler);
        }

        private readonly Dictionary<ConsoleKey, IInputHandler> _inputHandlers = new Dictionary<ConsoleKey, IInputHandler>();

        public void PrintOptions()
        {
            Console.WriteLine("Please choose one of the following options to proceed:");
            foreach (IInputHandler handler in _inputHandlers.Values)
            {
                Console.WriteLine($"[{handler.TriggerKey.ToString()}] - {handler.Message}");
            }
        }
        public bool HandleInputKey(ConsoleKey key)
        {
            Console.Clear();
            if (_inputHandlers.ContainsKey(key))
            {
                try
                {
                    return _inputHandlers[key].Handle();
                }
                catch
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Invalid option");
                return true;
            }
        }
    }
}
