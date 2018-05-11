using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    public static class MixingWaterProvider
    {
        #region Public Properties

        /// <summary>
        /// Mass of water needed in kg per unit volume of concrete for non entrained air mix
        /// according to the nominal aggragate size and slump value
        /// </summary>
        public static Dictionary<SlumpAmount, Dictionary<NominalAggregateSize, double>> WaterMassNonAirEntrained { get; set; } =
            new Dictionary<SlumpAmount, Dictionary<NominalAggregateSize, double>>
            {
                { SlumpAmount.From25To50 ,new Dictionary<NominalAggregateSize,double>{
                    {NominalAggregateSize.Size9_5,207},
                    {NominalAggregateSize.Size12_5,199},
                    {NominalAggregateSize.Size19, 190},
                    {NominalAggregateSize.Size25, 179},
                    {NominalAggregateSize.Size37_5, 166},
                    {NominalAggregateSize.Size50, 154},
                    {NominalAggregateSize.Size75, 130},
                    {NominalAggregateSize.Size150, 113}
                } },
                { SlumpAmount.From50To100 ,new Dictionary<NominalAggregateSize,double>{
                    {NominalAggregateSize.Size9_5,228},
                    {NominalAggregateSize.Size12_5,216},
                    {NominalAggregateSize.Size19, 205},
                    {NominalAggregateSize.Size25, 193},
                    {NominalAggregateSize.Size37_5, 181},
                    {NominalAggregateSize.Size50, 169},
                    {NominalAggregateSize.Size75, 145},
                    {NominalAggregateSize.Size150, 124}
                } },
                { SlumpAmount.From150To175 ,new Dictionary<NominalAggregateSize,double>{
                    {NominalAggregateSize.Size9_5,243},
                    {NominalAggregateSize.Size12_5,228},
                    {NominalAggregateSize.Size19, 216},
                    {NominalAggregateSize.Size25, 202},
                    {NominalAggregateSize.Size37_5, 190},
                    {NominalAggregateSize.Size50, 178},
                    {NominalAggregateSize.Size75, 160},
                    {NominalAggregateSize.Size150, 0}
                } },
            };

        /// <summary>
        /// Mass of water needed in kg per unit volume of concrete for entrained air mix
        /// according to the nominal aggragate size and slump value
        /// </summary>
        public static Dictionary<SlumpAmount, Dictionary<NominalAggregateSize, double>> WaterMassAirEntrained { get; set; } =
            new Dictionary<SlumpAmount, Dictionary<NominalAggregateSize, double>>
            {
                { SlumpAmount.From25To50 ,new Dictionary<NominalAggregateSize,double>{
                    {NominalAggregateSize.Size9_5,181},
                    {NominalAggregateSize.Size12_5,175},
                    {NominalAggregateSize.Size19, 168},
                    {NominalAggregateSize.Size25, 160},
                    {NominalAggregateSize.Size37_5, 150},
                    {NominalAggregateSize.Size50, 142},
                    {NominalAggregateSize.Size75, 122},
                    {NominalAggregateSize.Size150, 107}
                } },
                { SlumpAmount.From50To100 ,new Dictionary<NominalAggregateSize,double>{
                    {NominalAggregateSize.Size9_5,202},
                    {NominalAggregateSize.Size12_5,193},
                    {NominalAggregateSize.Size19, 184},
                    {NominalAggregateSize.Size25, 175},
                    {NominalAggregateSize.Size37_5, 165},
                    {NominalAggregateSize.Size50, 157},
                    {NominalAggregateSize.Size75, 133},
                    {NominalAggregateSize.Size150, 119}
                } },
                { SlumpAmount.From150To175 ,new Dictionary<NominalAggregateSize,double>{
                    {NominalAggregateSize.Size9_5,216},
                    {NominalAggregateSize.Size12_5,205},
                    {NominalAggregateSize.Size19, 197},
                    {NominalAggregateSize.Size25, 184},
                    {NominalAggregateSize.Size37_5, 174},
                    {NominalAggregateSize.Size50, 166},
                    {NominalAggregateSize.Size75, 154},
                    {NominalAggregateSize.Size150, 0}
                } },
            };

        /// <summary>
        /// Amount of water reduction due to coarse aggregate roundness in kg per unit volume of concrete mix.
        /// </summary>
        public static double RoundnessReduction = 25;

        #endregion

        #region Static Methods

        /// <summary>
        /// Get mix water content in kg/m^3 of concrete mix
        /// </summary>
        /// <param name="aggSize">Nominal aggregate size of coarse aggregate</param>
        /// <param name="slump">Amount of slump required</param>
        /// <param name="isAirEntrained">Is air entrained mix required</param>
        /// <returns>Water mass in kg/m^3</returns>
        public static double GetWaterContent(NominalAggregateSize aggSize, SlumpAmount slump, bool isAirEntrained)
        {
            if (isAirEntrained)
                return WaterMassAirEntrained[slump][aggSize];
            else
                return WaterMassNonAirEntrained[slump][aggSize];
        }

        #endregion
    }
}
