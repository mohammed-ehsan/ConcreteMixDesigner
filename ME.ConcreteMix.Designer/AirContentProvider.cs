using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    public static class AirContentProvider
    {
        #region Static Properties

        /// <summary>
        /// Amount of air entrapped in non air entrapped concrete mix in percent
        /// </summary>
        public static Dictionary<NominalAggregateSize, double> EntrappedAirInNonAirConcrete =
            new Dictionary<NominalAggregateSize, double>
            {
                {NominalAggregateSize.Size9_5,3 },
                {NominalAggregateSize.Size12_5,2.5 },
                {NominalAggregateSize.Size19,2.0 },
                {NominalAggregateSize.Size25,1.5 },
                {NominalAggregateSize.Size37_5,1 },
                {NominalAggregateSize.Size50,0.5 },
                {NominalAggregateSize.Size75,0.3 },
                {NominalAggregateSize.Size150,0.2 }
            };

        /// <summary>
        /// Recommended average total air content percent according to freezing and thawing exposure level
        /// </summary>
        public static Dictionary<FreezingAndThawingExposure, Dictionary<NominalAggregateSize, double>> EntrappedAirInAirConcrete =
            new Dictionary<FreezingAndThawingExposure, Dictionary<NominalAggregateSize, double>> {
                {FreezingAndThawingExposure.Mild, new Dictionary<NominalAggregateSize, double>
                {
                    {NominalAggregateSize.Size9_5,4.5 },
                    {NominalAggregateSize.Size12_5,4.0 },
                    {NominalAggregateSize.Size19,3.5 },
                    {NominalAggregateSize.Size25,3.0 },
                    {NominalAggregateSize.Size37_5,2.5},
                    {NominalAggregateSize.Size50,2.0 },
                    {NominalAggregateSize.Size75,1.5 },
                    {NominalAggregateSize.Size150,1.0 }
                } },
                {FreezingAndThawingExposure.Moderate, new Dictionary<NominalAggregateSize, double>
                {
                    {NominalAggregateSize.Size9_5,6.0 },
                    {NominalAggregateSize.Size12_5,5.5 },
                    {NominalAggregateSize.Size19,5.0 },
                    {NominalAggregateSize.Size25,4.5 },
                    {NominalAggregateSize.Size37_5,4.5},
                    {NominalAggregateSize.Size50,4.0 },
                    {NominalAggregateSize.Size75,3.5 },
                    {NominalAggregateSize.Size150,3.0 }
                } },
                {FreezingAndThawingExposure.Severe, new Dictionary<NominalAggregateSize, double>
                {
                    {NominalAggregateSize.Size9_5,7.5 },
                    {NominalAggregateSize.Size12_5,7.0 },
                    {NominalAggregateSize.Size19,6.0 },
                    {NominalAggregateSize.Size25,6.0 },
                    {NominalAggregateSize.Size37_5,5.5},
                    {NominalAggregateSize.Size50,5.0 },
                    {NominalAggregateSize.Size75,4.5 },
                    {NominalAggregateSize.Size150,4.0 }
                } }
            };

        #endregion

        #region Static Methods

        /// <summary>
        /// Get the air content entrapped in non air entrapped concrete mix, in precent.
        /// </summary>
        /// <param name="aggSize"></param>
        /// <returns></returns>
        public static double GetAirContent(NominalAggregateSize aggSize)
        {
            return EntrappedAirInNonAirConcrete[aggSize];
        }

        /// <summary>
        /// Get the air content recommended for freezing and thawing exposure <paramref name="exposure"/>, in percent.
        /// </summary>
        /// <param name="exposure"></param>
        /// <param name="aggSize"></param>
        /// <returns></returns>
        public static double GetAirContent(FreezingAndThawingExposure exposure, NominalAggregateSize aggSize)
        {
            return EntrappedAirInAirConcrete[exposure][aggSize];
        }

        #endregion  
    }
}
