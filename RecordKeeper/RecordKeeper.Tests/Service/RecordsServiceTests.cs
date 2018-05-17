using Moq;
using RecordKeeper.Core;
using RecordKeeper.Repo;
using RecordKeeper.Service;
using System;
using Xunit;

namespace RecordKeeper.Tests.Service
{
    public class RecordsServiceTests
    {
        private IRecordsService _service;
        private Mock<IRecordsRepository> _repoMock;

        public RecordsServiceTests()
        {
            _repoMock = new Mock<IRecordsRepository>();
            _repoMock.Setup(x => x.AddRecord(It.IsAny<Person>())).Verifiable();
           _service = new RecordsService(_repoMock.Object);
        }

        [Fact]
        public void AddFromFileTestNullFile()
        {
            Assert.Throws<ArgumentNullException>(() => { _service.AddFromFile(null); });
            _repoMock.Verify(x => x.AddRecord(It.IsAny<Person>()), Times.Never);
        }

        [Fact]
        public void AddFromFileTestSampleFile()
        {
            _service.AddFromFile(@"Utility\testrecords.csv");
            _repoMock.Verify(x => x.AddRecord(It.Is<Person>(p => p.FirstName.StartsWith("Albert"))), Times.Once);
        }

        [Fact]
        public void AddFromStringTestNullstring()
        {
            Assert.Throws<ArgumentNullException>(() => { _service.AddFromString(null); });
            _repoMock.Verify(x => x.AddRecord(It.IsAny<Person>()), Times.Never);
        }

        [Fact]
        public void AddFromStringTestSampleData()
        {
            _service.AddFromString(@"Einstein,Albert,Male,Violet,03/14/1879");
            _repoMock.Verify(x => x.AddRecord(It.Is<Person>(p => p.FirstName.StartsWith("Albert"))), Times.Once);
        }
    }
}
