using NUnit.Framework;
using IndianCensusAnalyser;
using System.Collections.Generic;
using IndianCensusAnalyser.DTO;
using System.Security;

namespace IndianCensusAnalyserTest
{
    public class IndianCensusTest
    {
        //File path and header definition stored in a string
        public static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        string indianStateCensusFilePath = @"C:\Users\Chetan\source\repos\IndianCensusAnalyser\IndianCensusAnalyserTest\CSV Files\IndiaStateCensusData.csv";
        string indianStateCodeFilePath = @"C:\Users\Chetan\source\repos\IndianCensusAnalyser\IndianCensusAnalyserTest\CSV Files\IndiaStateCode.csv";
        ///File path definition for test cases while implementing the Use Case 1 for the Indian State Census Data Analysis.
        public static string wrongIndianStateCensusFilePath = @"C:\Users\Chetan\source\repo\IndianCensusAnalyser\IndianCensusAnalyserTest\CSV Files\WrongIndiaStateCensusData.csv";
        public static string wrongIndianStateCensusFileType = @"C:\Users\Chetan\source\repos\IndianCensusAnalyser\IndianCensusAnalyserTest\CSV Files\IndiaStateCensusData.txt";
        public static string wrongHeaderIndianStateCensusFilePath = @"C:\Users\Chetan\source\repos\IndianCensusAnalyser\IndianCensusAnalyserTest\CSV Files\WrongIndiaStateCensusData.csv";
        public static string wrongDelimeterIndianStateCensusFilePath = @"C:\Users\Chetan\source\repos\IndianCensusAnalyser\IndianCensusAnalyserTest\CSV Files\DelimiterIndiaStateCensusData.csv";
        ///Instance for the Census Analyser Class
        CensusAnalyser censusAnalyser;
        ///A dictionary to store the data from the Indian Census Data file
        Dictionary<string, CensusDTO> totalRecord;
        ///A dictionary to store the data from the Indian State Code Data file
        Dictionary<string, CensusDTO> stateRecord;
        /// <summary>
        /// Initialising the instance of the Class objects
        /// </summary>
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        /// <summary>
        /// TC 1.1 - To get the records and to assert whether the count of all the records matches to manually addressed or not
        /// Using the Dictionary Collection to store the Indian State Census Records and then Count it
        /// </summary>
        [Test]
        public void GivenIndianStateDataCensus_ReturnsCorrectCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        /// <summary>
        /// TC 1.2 - To pass a wrong file path and assert whether the custom exception of file not found is returned or not
        /// </summary>
        [Test]
        public void GivenWrongFile_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        /// <summary>
        /// TC 1.3 - To pass a wrong file type and the correct file name and assert whether the custom exception of file not found is returned or not
        /// </summary>
        [Test]
        public void GivenWrongFileType_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        /// <summary>
        /// TC 1.4 - To pass a wrong delimeter in the Indian Census File and the correct file name and assert whether the custom exception of file not found is returned or not
        /// </summary>
        [Test]
        public void GivenWrongDelimeter_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongDelimeterIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        /// <summary>
        /// TC 1.5 - To pass a wrong header in the Indian Census File and the correct file name and assert whether the custom exception of incorrect header is returned or not
        /// </summary>
        [Test]
        public void GivenWrongHeader_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}