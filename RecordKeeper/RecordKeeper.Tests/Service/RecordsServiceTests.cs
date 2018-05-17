using Moq;
using RecordKeeper.Core;
using RecordKeeper.Repo;
using RecordKeeper.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace RecordKeeper.Tests.Service
{
    public class RecordsServiceTests
    {
        private IRecordsService _service;
        private Mock<IRecordsRepository> _repoMock;

        public RecordsServiceTests()
        {
            var testdata = new List<Person>();
            testdata.Add(new Person() { FirstName = "Albert", LastName = "Einstein", Gender = "Male", FavoriteColor = "Violet", DateOfBirth = DateTime.Parse("03/14/1879") });
            testdata.Add(new Person() { FirstName = "Ada", LastName = "Lovelace", Gender = "Female", FavoriteColor = "Pink", DateOfBirth = DateTime.Parse("12/10/1815") });

            _repoMock = new Mock<IRecordsRepository>();
            _repoMock.Setup(x => x.AddRecord(It.IsAny<Person>())).Verifiable();
            _repoMock.Setup(x => x.GetAll()).Returns(testdata);
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

        [Fact]
        public void GetAllBasicTest()
        {
            var result = _service.GetAll();
            _repoMock.Verify(x => x.GetAll(), Times.Once);
            Assert.Equal(2, result.Count);
        }
    }
}
