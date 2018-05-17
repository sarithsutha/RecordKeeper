using RecordKeeper.Utility;
using System;
using System.IO;
using Xunit;

namespace RecordKeeper.Tests
{
    public class DelimitedFileParserTests
    {
        private DelimitedFileParser _parser;

        public DelimitedFileParserTests()
        {
            _parser = new DelimitedFileParser(@"Utility\testrecords.csv");
        }

        [Fact]
        public void ConstructorTestWithNullFilename()
        {
            Assert.Throws<ArgumentNullException>(() => { new DelimitedFileParser(null); });
        }

        [Fact]
        public void ConstructorTestWithInvalidFilename()
        {
            Assert.Throws<FileNotFoundException>(() => { new DelimitedFileParser("unknownfile"); });
        }

        [Theory]
        [InlineData("LastName|FirstName|Gender|FavoriteColor|DateOfBirth", "|")]
        [InlineData("LastName FirstName Gender FavoriteColor DateOfBirth", " ")]
        [InlineData("LastName,FirstName,Gender,FavoriteColor,DateOfBirth", ",")]
        [InlineData("", ",")]
        public void GetDelimiterTest(string inputLine, string delmiter)
        {
            //Arrange
            //Act
            var result = _parser.GetDelimiter(inputLine);
            //Assert
            Assert.Equal(delmiter, result);
        }

        [Fact]
        public void GetRecordsBasicTest()
        {
            //Arrange
            Func<string[], string> getFullName = (input) => $"{input[1]} {input[0]}";

            //Act
            var result = _parser.GetRecords<string>(getFullName);

            //Assert
            Assert.Single(result);
            Assert.Equal("Albert Einstein", result[0]);
        }
    }
}
