using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianCensusAnalyser
{
    public abstract class CensusAdapter
    {
        /// <summary>
        /// Function returning the header as the string.
        /// </summary>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyserException">
        /// File Not Found
        /// or
        /// Invalid File Type
        /// or
        /// Incorrect header in Data
        /// </exception>
        protected string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            /// String to store the data from the csv file.
            string[] censusData;
            /// Checks if the file exists for the path or not. If not exists throwing the custom exception 
            /// for the file not found.
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            /// Checking for the extension of the file path. If extension doesn't matches throws 
            /// the custom exception for the invalid file type.
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Invalid File Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            /// Reading all the file data at the present file path. 
            censusData = File.ReadAllLines(csvFilePath);
            /// Checking for the file header present at the 0th position in the string array.
            /// If header is in correct throws the custom exception for incorrect header in the data file.
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}
