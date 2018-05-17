using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace RecordKeeper.Utility
{
    /// <summary>
    /// A helper class for handling the parsing of delimited text files
    /// </summary>
    public class DelimitedFileParser
    {
        private List<string[]> fileContent;
        public DelimitedFileParser(string filename, string delimiter = null)
        {
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentNullException("filename");

            fileContent = new List<string[]>();
            using (StreamReader reader = File.OpenText(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //Infer the delimiter if not already done
                    if (string.IsNullOrEmpty(delimiter))
                    {
                        delimiter = GetDelimiter(line);
                    }
                    fileContent.Add(line.Split(delimiter));
                }
            }
        }

        /// <summary>
        /// Infer the delimiter used in the file by accepting a line of text from it
        /// </summary>
        /// <param name="input">a line of text from the delimited file</param>
        /// <returns>The delimiter used in the file</returns>
        public string GetDelimiter(string input)
        {
            string returnValue = ",";
            var regex = new Regex(@"^\S*(?<delimiter>[\s,|])\S*");
            var match = regex.Match(input);
            if (match.Success)
            {
                returnValue = match.Groups["delimiter"].Value;
            }
            return returnValue;
        }

        /// <summary>
        /// Get the read records in a strongly typed list
        /// </summary>
        /// <typeparam name="TRecordType"></typeparam>
        /// <param name="mapperFunc">the function that does mapping of the values to a strongle typed object</param>
        /// <returns></returns>
        public List<TRecordType> GetRecords<TRecordType>(Func<string[], TRecordType> mapperFunc)
        {
            return
                fileContent
                .ConvertAll<TRecordType>(input => mapperFunc(input))
                .ToList();
        }
    }
}
