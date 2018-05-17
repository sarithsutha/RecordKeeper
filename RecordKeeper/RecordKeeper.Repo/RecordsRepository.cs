using RecordKeeper.Core;
using System.Collections.Generic;
using System.Linq;

namespace RecordKeeper.Repo
{
    public class RecordsRepository : IRecordsRepository
    {
        public static List<Person> People { get; set; }

        static RecordsRepository()
        {
            People = new List<Person>();
        }

        public void AddRecord(Person person)
        {
            People.Add(person);
        }

        public List<Person> GetAll()
        {
            return People;
        }
    }
}
