using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    public static class WaterCementRatioProvider
    {

        #region Static Properties

        /// <summary>
        /// Maximum W/C ration in accordance with exposure condition
        /// </summary>
        public static Dictionary<ExposureConditions, double> MaxWCRatio { get; set; } =
            new Dictionary<ExposureConditions, double>
            {
                {ExposureConditions.Protected,1.0 },
                {ExposureConditions.WaterExposed,0.5 },
                {ExposureConditions.FreezingAndThawing,0.45 },
                {ExposureConditions.CorrosionExposed,0.40 }
            };

        #endregion


        #region Static Methods

        /// <summary>
        /// Check if provided W/C ratio satisfies maximum value for <paramref name="exposure"/> specified
        /// </summary>
        /// <param name="WCRatio">Water/Cement ratio</param>
        /// <param name="exposure">Exposure condition</param>
        /// <returns></returns>
        public static bool SatisfiesMaxWC(double WCRatio, ExposureConditions exposure) =>
            WCRatio <= MaxWCRatio[exposure];


        /// <summary>
        /// Get Water/Cementitious material ratio by mass, should be used to get the require strength <paramref name="strength"/>
        /// accounting air entrainment condtion <paramref name="airEntrained"/>
        /// </summary>
        /// <param name="strength">Required concrete strength for cylinder at 28 days in Mpa</param>
        /// <param name="airEntrained">Is air entrainment required</param>
        /// <returns></returns>
        public static double GetWCRatio(double strength, bool airEntrained)
        {
            if (airEntrained)
                return 0.000000181818182 * Math.Pow(strength, 4) - 0.000024040404040 * Math.Pow(strength, 3) + 0.001362121212122 * Math.Pow(strength, 2) - 0.049279942279902 * strength + 1.204523809522720;
            else
                return 0.000000363636364 * Math.Pow(strength, 4) - 0.000043636363636 * Math.Pow(strength, 3) + 0.002090909090912 * Math.Pow(strength, 2) - 0.060551948051941 * strength + 1.356428571427430;
        }

        #endregion
    }
}
