using RecordKeeper.Core;
using System.Collections.Generic;

namespace RecordKeeper.Service
{
    public interface IRecordsService
    {
        bool AddFromFile(string filename);
        bool AddFromString(string data);
        List<Person> GetAll();
    }
}
