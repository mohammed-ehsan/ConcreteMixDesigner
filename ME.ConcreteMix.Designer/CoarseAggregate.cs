using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    /// <summary>
    /// Static class providing constants and functions related to coarse aggregate
    /// </summary>
    public class CoarseAggregateMaterial :MixIngredient, IAggregate
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
        /// Nominal aggregate size
        /// </summary>
        public NominalAggregateSize NominalSize { get; set; }

        /// <summary>
        /// Is the aggregate well rounded
        /// </summary>
        public bool IsRounded { get; set; }

        /// <summary>
        /// Specific gravity of coarse aggregate
        /// </summary>
        public double SpecificGravity { get; set; }

        #endregion

        #region Static Properties

        public static Dictionary<NominalAggregateSize, Dictionary<double, double>> CoarseAggregateVolumes { get; set; } =
            new Dictionary<NominalAggregateSize, Dictionary<double, double>>
            {
                {NominalAggregateSize.Size9_5,new Dictionary<double, double>
                {
                    {2.4,0.5 },
                    {2.6,0.48 },
                    {2.8,0.46 },
                    {3.0,0.44 }
                } },
                {NominalAggregateSize.Size12_5,new Dictionary<double, double>
                {
                    {2.4,0.59 },
                    {2.6,0.57 },
                    {2.8,0.55 },
                    {3.0,0.53 }
                } },
                {NominalAggregateSize.Size19,new Dictionary<double, double>
                {
                    {2.4,0.66 },
                    {2.6,0.64 },
                    {2.8,0.62 },
                    {3.0,0.60 }
                } },
                {NominalAggregateSize.Size25,new Dictionary<double, double>
                {
                    {2.4,0.71 },
                    {2.6,0.69 },
                    {2.8,0.67 },
                    {3.0,0.65 }
                } },
                {NominalAggregateSize.Size37_5,new Dictionary<double, double>
                {
                    {2.4,0.75 },
                    {2.6,0.73 },
                    {2.8,0.71 },
                    {3.0,0.69 }
                } },
                {NominalAggregateSize.Size50,new Dictionary<double, double>
                {
                    {2.4,0.78 },
                    {2.6,0.76 },
                    {2.8,0.74 },
                    {3.0,0.72 }
                } },
                {NominalAggregateSize.Size75,new Dictionary<double, double>
                {
                    {2.4,0.82 },
                    {2.6,0.80 },
                    {2.8,0.78 },
                    {3.0,0.76 }
                } },
                {NominalAggregateSize.Size150,new Dictionary<double, double>
                {
                    {2.4,0.87 },
                    {2.6,0.85 },
                    {2.8,0.83 },
                    {3.0,0.81 }
                } },
            };

        #endregion

        #region Static Methods

        /// <summary>
        /// Calculate coarse aggregate size for unit volume of concrete
        /// </summary>
        /// <param name="nominalSize">Nominal size of coarse aggregate</param>
        /// <param name="finenessModulus">Fineness modulus of fine aggregate</param>
        public static double CalculateCoarseAggVol(NominalAggregateSize nominalSize, double finenessModulus)
        {
            var mVolumes = CoarseAggregateVolumes[nominalSize];
            double minFiness = 0;
            double maxFiness = 0;
            double minVol = 0;
            double maxVol = 0;
            for (int i = 0; i < mVolumes.Keys.Count; i++)
            {
                if (finenessModulus >= mVolumes.Keys.ToArray()[i])
                {
                    minFiness = mVolumes.Keys.ToArray()[i];
                    minVol = mVolumes[minFiness];
                }
                if (finenessModulus <= mVolumes.Keys.ToArray()[i])
                {
                    maxFiness = mVolumes.Keys.ToArray()[i];
                    maxVol = mVolumes[maxFiness];
                    break;
                }
            }

            if (minVol == maxVol)
                return minVol;

            double result = Interpolator.Interpolate(minFiness, minVol, maxFiness, maxVol, finenessModulus);
            return result;
        }

        #endregion
    }
}
