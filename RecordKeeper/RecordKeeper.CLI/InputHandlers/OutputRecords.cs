using RecordKeeper.Core;
using RecordKeeper.Service;
using System;
using System.Collections.Generic;
using System.Linq;

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
            OutputHelper.PrettyPrint(_recordsService.GetAll()
                .OrderBy(p => p.Gender)
                .ThenBy(p => p.LastName)
                .ToList());
            return true;
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
            OutputHelper.PrettyPrint(_recordsService.GetAll()
                .OrderBy(p => p.DateOfBirth)
                .ToList());
            return true;
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
            OutputHelper.PrettyPrint(_recordsService.GetAll()
                .OrderByDescending(p => p.LastName)
                .ToList());
            return true;
        }
    }

    public class OutputHelper {
        public static void PrettyPrint(List<Person> people)
        {
            string separator = $"{new string('-', 20)}|{new string('-', 20)}|{new string('-', 10)}|{new string('-', 10)}|{new string('-', 10)}";
            Console.WriteLine($"{"LastName",-20}|{"FirstName",-20}|{"Gender",-10}|{"Fav Color",-10}|{"Date Of Birth",-10}");
            Console.WriteLine(separator);
            people.ForEach(
                p =>
                Console.WriteLine($"{p.LastName,-20}|{p.FirstName,-20}|{p.Gender,-10}|{p.FavoriteColor,-10}|{p.DateOfBirth.ToString("d/M/yyyy")}"));
            Console.WriteLine(separator);
            Console.WriteLine();
        }
    }
}