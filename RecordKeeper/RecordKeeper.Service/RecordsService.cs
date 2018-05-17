using RecordKeeper.Core;
using RecordKeeper.Repo;
using RecordKeeper.Utility;
using System;
using System.Collections.Generic;

namespace RecordKeeper.Service
{
    public class RecordsService : IRecordsService
    {
        private IRecordsRepository _recordsRepository;
        private Func<string[], Person> _stringsToPerson = (input) => new Person()
        {
            LastName = input[0],
            FirstName = input[1],
            Gender = input[2],
            FavoriteColor = input[3],
            DateOfBirth = DateTime.Parse(input[4])
        };

        public RecordsService(IRecordsRepository recordsRepository)
        {
            _recordsRepository = recordsRepository;
        }

        public bool AddFromString(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException("data");


            var parser = new DelimitedFileParser(data, true);
            List<Person> people = parser.GetRecords<Person>(_stringsToPerson);
            foreach (var person in people)
            {
                _recordsRepository.AddRecord(person);
            }
            return true;
        }

        public bool AddFromFile(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentNullException("filename");

            var parser = new DelimitedFileParser(filename);
            List<Person> people = parser.GetRecords<Person>(_stringsToPerson);
            foreach (var person in people)
            {
                _recordsRepository.AddRecord(person);
            }
            return true;
        }

        public List<Person> GetAll()
        {
            return _recordsRepository.GetAll();
        }
    }
}
