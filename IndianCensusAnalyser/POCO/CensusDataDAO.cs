using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyser.POCO
{
    public class CensusDataDAO
    {
        /// Attributes from the state census class matching the header for the CSV Class.
        public string state;
        public long population;
        public long area;
        public long density;
        /// <summary>
        /// Parameterised constructor defining the instance of the Indian Census Class 
        /// Attributes and assigning them the value passed.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="population">The population.</param>
        /// <param name="area">The area.</param>
        /// <param name="density">The density.</param>
        public CensusDataDAO(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToUInt32(population);
            this.area = Convert.ToUInt32(area);
            this.density = Convert.ToUInt32(density);
        }
    }
}
