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

        [Fact]
        public void ConstructorTestWithNullData()
        {
            Assert.Throws<ArgumentNullException>(() => { new DelimitedFileParser(null, true); });
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

        [Theory]
        [InlineData("Einstein,Albert,Male,Violet,03/14/1879", "Albert Einstein")]
        [InlineData("Lovelace|Ada|Female|Pink|12/10/1815", "Ada Lovelace")]
        [InlineData("Babbage Charles Male Azure 12/26/1791", "Charles Babbage")]
        public void GetRecordsBasicTestFromString(string inputline, string expected)
        {
            //Arrange
            var parser = new DelimitedFileParser(inputline, true);
            Func<string[], string> getFullName = (input) => $"{input[1]} {input[0]}";

            //Act
            var result = parser.GetRecords<string>(getFullName);

            //Assert
            Assert.Single(result);
            Assert.Equal(expected, result[0]);
        }
    }
}
