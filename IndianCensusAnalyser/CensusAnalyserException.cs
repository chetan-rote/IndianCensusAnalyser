using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        /// <summary>
        /// Enum to store the different exception types.
        /// </summary>
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_DELIMITER, INCORRECT_HEADER, NO_SUCH_COUNTRY
        }

        public ExceptionType eType;
        /// <summary>
        /// Parameterised constructor intended to overwrite the base message from the exception class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public CensusAnalyserException(string message, ExceptionType exceptionType) : base(message)
        {
            this.eType = exceptionType;
        }
    }
}
