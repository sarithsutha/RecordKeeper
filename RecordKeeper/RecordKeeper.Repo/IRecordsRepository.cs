using RecordKeeper.Core;

namespace RecordKeeper.Repo
{
    public interface IRecordsRepository
    {
        void AddRecord(Person person);
    }
}
