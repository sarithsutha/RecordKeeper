using RecordKeeper.Service;
using System;

namespace RecordKeeper.CLI.InputHandlers
{
    public class OutputRecordsSortByGender : IInputHandler
    {
        private IRecordsService _recordsService;
        public OutputRecordsSortByGender(IRecordsService service)
        {
            _recordsService = service;
        }
        public ConsoleKey TriggerKey => ConsoleKey.G;
        public string Message => "Output 1 – sorted by gender (females before males) then by last name ascending";
        public bool Handle()
        {
            throw new NotImplementedException();
        }
    }

    public class OutputRecordsSortByDOB : IInputHandler
    {
        private IRecordsService _recordsService;
        public OutputRecordsSortByDOB(IRecordsService service)
        {
            _recordsService = service;
        }
        public ConsoleKey TriggerKey => ConsoleKey.D;
        public string Message => "Output 2 – sorted by birth date, ascending";
        public bool Handle()
        {
            throw new NotImplementedException();
        }
    }

    public class OutputRecordsSortByLastName : IInputHandler
    {
        private IRecordsService _recordsService;
        public OutputRecordsSortByLastName(IRecordsService service)
        {
            _recordsService = service;
        }
        public ConsoleKey TriggerKey => ConsoleKey.L;
        public string Message => "Output 3 – sorted by last name, descending";
        public bool Handle()
        {
            throw new NotImplementedException();
        }
    }
}