using RecordKeeper.Core;
using System.Collections.Generic;

namespace RecordKeeper.Service
{
    public interface IRecordsService
    {
        bool AddFromFile(string filename);
        List<Person> GetAll();
    }
}
