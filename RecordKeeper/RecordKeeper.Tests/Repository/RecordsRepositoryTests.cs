using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordKeeper.API.Controllers;
using RecordKeeper.Core;
using RecordKeeper.Repo;
using RecordKeeper.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace RecordKeeper.Tests.Repository
{
    public class RecordsRepositoryTests
    {
        [Fact]
        public void GetAllTest()
        {
            IRecordsRepository repo = new RecordsRepository();
            Assert.Empty(repo.GetAll());
            repo.AddRecord(new Person() { LastName = "L", FirstName = "F", FavoriteColor = "Blue", Gender = "Male", DateOfBirth = DateTime.Now });
            Assert.Single(repo.GetAll());
        }
    }
}
