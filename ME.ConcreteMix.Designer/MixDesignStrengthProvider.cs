using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    /// <summary>
    /// Class provides calculations for strength used in mix designing
    /// </summary>
    public static class MixDesignStrengthProvider
    {

        #region Static Properties

        /// <summary>
        /// Minimum required structural strengths in MPa in accordance with exposure condition
        /// </summary>
        public static Dictionary<ExposureConditions, double> MinStrength { get; set; } =
            new Dictionary<ExposureConditions, double>
            {
                {ExposureConditions.Protected,0 },
                {ExposureConditions.WaterExposed,28 },
                {ExposureConditions.FreezingAndThawing,31 },
                {ExposureConditions.CorrosionExposed,35 }
            };

        #endregion  

        #region Static Methods

        /// <summary>
        /// Calculate modification factor for standard deviation, for samples count from 15 to 30
        /// </summary>
        /// <param name="samplesCount">Counts of samples used for calculating standard deviation</param>
        /// <returns>Modification factor of standard deviation</returns>
        public static double ModificationFactor(int samplesCount) =>
            -0.000013333333333 * Math.Pow(samplesCount, 3) + 0.0014 * Math.Pow(samplesCount, 2) - 0.052666666666664 * samplesCount + 1.6799999999998;

        /// <summary>
        /// Check if min strength requirement is met.
        /// </summary>
        /// <param name="strength">structural strength in MPa</param>
        /// <param name="exposure">Exposure condition</param>
        /// <returns></returns>
        public static bool IsAdequateForExposure(double strength, ExposureConditions exposure)
        {
            return strength >= MinStrength[exposure];
        }

        /// <summary>
        /// Calculate the design strength of concrete mixture according to <paramref name="requiredStrength"/>
        /// </summary>
        /// <param name="requiredStrength">Required strength by structural designer</param>
        /// <param name="samplesCount">Samples count used for calculating standard deviation of strength</param>
        /// <param name="standardDeviation">calculated standard deviation</param>
        /// <returns>Design strength used for designing concrete mix</returns>
        public static double DesignStrength(double requiredStrength, int samplesCount, double standardDeviation)
        {
            double mModifiedSD = 0;
            if (samplesCount < 30)
                mModifiedSD = ModificationFactor(samplesCount) * standardDeviation;
            else
                mModifiedSD = standardDeviation;
            if (requiredStrength <= 35)
            {
                double mDesignStrength1 = requiredStrength + 1.34 * mModifiedSD;
                double mDesignStrength2 = requiredStrength + 2.33 * mModifiedSD - 3.45;
                if (mDesignStrength1 > mDesignStrength2)
                    return mDesignStrength1;
                else
                    return mDesignStrength2;
            }

            if (requiredStrength > 35)
            {
                double mDesignStrength1 = requiredStrength + 1.34 * mModifiedSD;
                double mDesignStrength2 = 0.9 * requiredStrength + 2.33 * mModifiedSD;
                if (mDesignStrength1 > mDesignStrength2)
                    return mDesignStrength1;
                else
                    return mDesignStrength2;
            }
            throw new InvalidOperationException("No result was ommited, this behaviour should not happen");
        }

        /// <summary>
        /// Required average design strength in MPa if no standard deviation data is available
        /// </summary>
        /// <param name="requiredStrength">Required strength by structural designer in MPa</param>
        /// <returns></returns>
        public static double DesignStrength(double requiredStrength)
        {
            if (requiredStrength < 21)
                return requiredStrength + 7;
            if (requiredStrength >= 21 && requiredStrength <= 35)
                return requiredStrength + 8.5;
            return 1.1 * requiredStrength + 5;
        }

        #endregion

    }
}
