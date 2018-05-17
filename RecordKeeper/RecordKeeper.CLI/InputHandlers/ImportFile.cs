using RecordKeeper.Service;
using RecordKeeper.Utility;
using System;
using System.IO;

namespace RecordKeeper.CLI.InputHandlers
{
    public class ImportFile : IInputHandler
    {
        private IRecordsService _recordsService;
        public ImportFile(IRecordsService service)
        {
            _recordsService = service;
        }
        public ConsoleKey TriggerKey => ConsoleKey.I;
        public string Message => "Import a file";
        public bool Handle()
        {
            Console.WriteLine("Please enter the file path and hit enter");
            string fileName = Console.ReadLine();
            if (File.Exists(fileName))
            {
                _recordsService.AddFromFile(fileName);
            }
            else
            {
                Console.WriteLine("***File not found***");
            }
            return false;
        }
    }
}
