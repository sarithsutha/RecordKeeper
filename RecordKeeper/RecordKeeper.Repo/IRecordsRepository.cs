using RecordKeeper.Core;
using System.Collections.Generic;

namespace RecordKeeper.Repo
{
    public interface IRecordsRepository
    {
        void AddRecord(Person person);
        List<Person> GetAll();
    }
}
