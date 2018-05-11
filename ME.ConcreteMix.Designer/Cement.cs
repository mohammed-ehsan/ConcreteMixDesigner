using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    public class CementMaterial : MixIngredient
    {
        #region Static Properties

        /// <summary>
        /// Minimum mass of cement in kg required per unit volume of concrete accodring to nominal coarse aggregate size
        /// </summary>
        public static Dictionary<NominalAggregateSize, double> MinRequiredCement =
            new Dictionary<NominalAggregateSize, double>
            {
                {NominalAggregateSize.Size9_5,360 },
                {NominalAggregateSize.Size12_5,350 },
                {NominalAggregateSize.Size19, 320 },
                {NominalAggregateSize.Size25, 310 },
                {NominalAggregateSize.Size37_5, 280 },
                {NominalAggregateSize.Size50, 280 },
                {NominalAggregateSize.Size75, 280 },
                {NominalAggregateSize.Size150, 280 }
            };

        /// <summary>
        /// Severe exposure minimum cement weight in kg/m^3
        /// </summary>
        public static Double SevereExposureMinWeight = 335;

        #endregion

        #region Static Methods
        
        /// <summary>
        /// Check if the weight <paramref name="weight"/> is sufficient for specified <paramref name="aggSize"/>
        /// </summary>
        /// <param name="aggSize">Nominal aggregate size in mm</param>
        /// <param name="weight">Cement weight in kg/m^3</param>
        /// <param name="isSevereExposure">Concrete is exposed to severe freezing and thawing and deicers components</param>
        /// <returns></returns>
        public static bool IsSufficientWeight(NominalAggregateSize aggSize, double weight, bool isSevereExposure)
        {
            double mWeight = weight;
            if (weight < MinRequiredCement[aggSize])
                mWeight = MinRequiredCement[aggSize];
            if (isSevereExposure && mWeight < SevereExposureMinWeight)
                mWeight = SevereExposureMinWeight;
            return mWeight >= weight;
        }

        /// <summary>
        /// Get the appropriate cement weight for specified <paramref name="aggSize"/> taking account for severe exposure.
        /// </summary>
        /// <param name="aggSize">Nominal aggregate size</param>
        /// <param name="isSevereExposure">Is concrete exposed to sever freezing and thawing exposure</param>
        /// <returns>Sufficient weight in kg/m^3</returns>
        public static double GetSufficientWeight(NominalAggregateSize aggSize, bool isSevereExposure)
        {
            double mWeight = MinRequiredCement[aggSize];
            if (isSevereExposure)
                return mWeight >= SevereExposureMinWeight ? mWeight : SevereExposureMinWeight;
            return mWeight;
        }

        #endregion
    }
}
