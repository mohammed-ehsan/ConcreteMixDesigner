using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    public class FineAggregate : MixIngredient, IAggregate
    {

        #region Public Properties

        /// <summary>
        /// Absorbtion of water in percentage
        /// </summary>
        public double Absorbtion { get; set; }

        /// <summary>
        /// Current moisture content in percentage before mix
        /// </summary>
        public double MoistureContent { get; set; }

        /// <summary>
        /// Fineness modulus of fine aggregate
        /// </summary>
        public double FinenessModulus { get; set; }

        /// <summary>
        /// Specific gravity of fine aggregate
        /// </summary>
        public double SpecificGravity { get; set; }

        #endregion
    }
}
