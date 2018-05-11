using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    public class WaterReducer : AdmixtureMaterial
    {
        #region Public Properties

        /// <summary>
        /// Percentage of water reduction
        /// </summary>
        public double Reduction { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public WaterReducer() { }

        /// <summary>
        /// Create water reducer with specified properties.
        /// </summary>
        /// <param name="reduction">Amount of water reduction in precent</param>
        /// <param name="dosage">Dosage of reducer in gm reducer per kg cement</param>
        public WaterReducer(double reduction, double dosage)
        {
            this.Reduction = reduction;
            this.Dosage = dosage;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the water content after reduction applied
        /// </summary>
        /// <param name="waterContent">Original water content in kg/m^3 of concrete mix</param>
        /// <returns>Reduced water content in kg/m^3 of concrete mix</returns>
        public double GetReducedWaterContent(double waterContent)
        {
            return waterContent * (1 - this.Reduction / 100);
        }

        #endregion
    }
}
