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
        
        public RecordsService(IRecordsRepository recordsRepository)
        {
            _recordsRepository = recordsRepository;
        }

        public bool AddFromFile(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentNullException("filename");

            Func<string[], Person> stringsToPerson = (input) => new Person() {
                LastName = input[0],
                FirstName = input[1],
                Gender = input[2],
                FavoriteColor = input[3],
                DateOfBirth = DateTime.Parse(input[4])
            };
            var parser = new DelimitedFileParser(filename);
            List<Person> people = parser.GetRecords<Person>(stringsToPerson);
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
