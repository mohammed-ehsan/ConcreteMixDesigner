using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    public class Water : MixIngredient
    {
        #region Public Properties

        /// <summary>
        /// Temperature of water used for concrete mix in degree celisiuos
        /// </summary>
        public double Temperature { get; set; }

        #endregion

        #region Static Methods

        /// <summary>
        /// Calculate water density in kg/m^3 for <paramref name="temperature"/> in degree centigrade
        /// Notice that this equation is accurate for temperatures between 16 and 30, but can also be used for slightly lower or higher temperatures
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns></returns>
        public static double GetDensity(double temperature) =>
            -0.005000000000052 * Math.Pow(temperature, 2) - 0.007738095236164 * temperature + 1000.338;
        
        #endregion
    }
}
