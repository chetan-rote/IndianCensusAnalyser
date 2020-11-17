using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IndianCensusAnalyser.DTO;

namespace IndianCensusAnalyser
{
    public class CensusAnalyser
    {
        /// <summary>
        /// Enum to create instance for multiple countries.
        /// <summary>
        public enum Country
        {
            INDIA
        }
        /// Dictionary to load the data from the CSV file using CsvHelper
        Dictionary<string, CensusDTO> dataMap;
        /// <summary>
        /// Function to load the data from Csv files.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
