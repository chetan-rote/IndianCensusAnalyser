using IndianCensusAnalyser.DTO;
using IndianCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianCensusAnalyser
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        /// <summary>
        /// Dictionary to match the header data with the census dto class instance.
        /// </summary>
        Dictionary<string, CensusDTO> dataMap;
        /// <summary>
        /// Load census data method returning the mapped dictionary of data loaded from the csv files.
        /// </summary>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyserException">File Contains Wrong Delimiter</exception>
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            /// Initialising the instance for this dictionary
            dataMap = new Dictionary<string, CensusDTO>();
            /// Census data getting the data as the string array when passed the csv file path and correct header.
            censusData = GetCensusData(csvFilePath, dataHeaders);
            /// Iterating over the string array and skipping the header row written in the string array
            /// when loaded from the csv file.
            foreach (string data in censusData.Skip(1))
            {
                /// Exception check for the wrong delimeter and returning the custom exception for wrong delimeter.
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                /// Adding the data for the Indian State Code csv file.
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    dataMap.Add(column[1], new CensusDTO(new StateCodeDAO(column[0], column[1], column[2], column[3])));
                /// Adding the data for the Indian State census csv file.
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    dataMap.Add(column[0], new CensusDTO(new CensusDataDAO(column[0], column[1], column[2], column[3])));
            }
            return dataMap.ToDictionary(records => records.Key, records => records.Value);
        }
    }
}
