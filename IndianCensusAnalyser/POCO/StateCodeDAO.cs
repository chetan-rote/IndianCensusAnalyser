using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyser.POCO
{
    public class StateCodeDAO
    {
        /// Attributes from the state code class matching the header for the CSV Class.
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;
        /// <summary>
        /// Parameterised constructor defining the instance of the Indian State code Class Attributes
        /// and assigning them the value passed.
        /// </summary>
        /// <param name="v1">The v1.</param>
        /// <param name="v2">The v2.</param>
        /// <param name="v3">The v3.</param>
        /// <param name="v4">The v4.</param>
        public StateCodeDAO(string v1, string v2, string v3, string v4)
        {
            this.serialNumber = Convert.ToInt32(v1);
            this.stateName = v2;
            this.tin = Convert.ToInt32(v3);
            this.stateCode = v4;
        }
    }
}
