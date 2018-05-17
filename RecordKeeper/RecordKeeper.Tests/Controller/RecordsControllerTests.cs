using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordKeeper.API.Controllers;
using RecordKeeper.Core;
using RecordKeeper.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace RecordKeeper.Tests.Controller
{
    public class RecordsControllerTests
    {
        private RecordsController _controller;
        private Mock<IRecordsService> _serviceMock;
        public RecordsControllerTests()
        {
            _serviceMock = new Mock<IRecordsService>();
            _serviceMock.Setup(x => x.AddFromFile(It.IsAny<string>())).Returns(true);
            _serviceMock.Setup(x => x.AddFromString(It.IsAny<string>())).Returns(true);

            var testdata = new List<Person>();
            testdata.Add(new Person() { FirstName = "Albert", LastName = "Einstein", Gender = "Male", FavoriteColor = "Violet", DateOfBirth = DateTime.Parse("03/14/1879") });
            testdata.Add(new Person() { FirstName = "Ada", LastName = "Lovelace", Gender = "Female", FavoriteColor = "Pink", DateOfBirth = DateTime.Parse("12/10/1815") });
            _serviceMock.Setup(x => x.GetAll()).Returns(testdata);

            _controller = new RecordsController(_serviceMock.Object);
        }

        [Fact]
        public void PostTestSimpleData()
        {
            _controller.Post("Einstein,Albert,Male,Violet,03/14/1879");
            _serviceMock.Verify(x => x.AddFromString(It.Is<string>(p => p.StartsWith("Einstein"))), Times.Once);
        }

        [Fact]
        public void GetByGenderTest()
        {
            //Arrange


            //Act
            var result = _controller.GetByGender();

            //Assert
            var reponse = Assert.IsType<OkObjectResult>(result);
            var people = Assert.IsType<List<Person>>(reponse.Value);
            Assert.Equal(2, people.Count);
            Assert.Equal("Female", people[0].Gender);
        }

        [Fact]
        public void GetByDOBTest()
        {
            //Arrange


            //Act
            var result = _controller.GetByDOB();

            //Assert
            var reponse = Assert.IsType<OkObjectResult>(result);
            var people = Assert.IsType<List<Person>>(reponse.Value);
            Assert.Equal(2, people.Count);
            Assert.Equal(DateTime.Parse("12/10/1815"), people[0].DateOfBirth);
        }

        [Fact]
        public void GetByNameTest()
        {
            //Arrange


            //Act
            var result = _controller.GetByName();

            //Assert
            var reponse = Assert.IsType<OkObjectResult>(result);
            var people = Assert.IsType<List<Person>>(reponse.Value);
            Assert.Equal(2, people.Count);
            Assert.Equal("Lovelace", people[0].LastName);
        }
    }
}
