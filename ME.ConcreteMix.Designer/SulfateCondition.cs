using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    /// <summary>
    /// Concrete sulfate exposure condition
    /// </summary>
    public class SulfateCondition : INotifyPropertyChanged
    {
        #region Public Properties

        /// <summary>
        /// Exposure condition of sulfate on concrete
        /// </summary>
        public SulfateExposure Exposure { get; set; }

        /// <summary>
        /// Water soluble solfate in soil in percent %
        /// </summary>
        public string SoilSulfate { get; set; }

        /// <summary>
        /// Sulfate in water (SO4) in ppm
        /// </summary>
        public string WaterSulfate { get; set; }

        /// <summary>
        /// Recommended cement type to be used with this exposure condition
        /// </summary>
        public string CementType { get; set; }

        /// <summary>
        /// Maximum water cementitious materal ratio allowable by mass
        /// </summary>
        public double MaxWCRatio { get; set; }

        /// <summary>
        /// Minimum design compressive strength of concrete cylinder
        /// </summary>
        public double MinCS { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Static Methods

        /// <summary>
        /// Get an array of Sulfate conditions requirement for concrete exposed to sulfates in soil or water.
        /// </summary>
        /// <returns></returns>
        public static SulfateCondition[] GetConditions()
        {
            var mConditions = new List<SulfateCondition>()
            {
                new SulfateCondition()
                {
                    Exposure = SulfateExposure.Negligible,
                    SoilSulfate = "Less than 0.10",
                    WaterSulfate = "Less than 150",
                    CementType = "No special type required",
                    MaxWCRatio=0,
                    MinCS=0
                },
                new SulfateCondition()
                {
                    Exposure=SulfateExposure.Moderate,
                    SoilSulfate="0.10 to 0.20",
                    WaterSulfate = "150 to 1500",
                    CementType = "II, MS, IP(MS), IS(MS, P(MS), I(PM)(MS), I(SM)(MS)",
                    MaxWCRatio=0.5,
                    MinCS=28
                },
                new SulfateCondition()
                {
                    Exposure=SulfateExposure.Severe,
                    SoilSulfate="0.20 to 2.00",
                    WaterSulfate = "1500 to 10000",
                    CementType = "V, HS",
                    MaxWCRatio=0.45,
                    MinCS=31
                },
                new SulfateCondition()
                {
                    Exposure = SulfateExposure.VerySevere,
                    SoilSulfate = "Over 2.00",
                    WaterSulfate = "Over 10000",
                    CementType = "V,HS",
                    MaxWCRatio = 0.4,
                    MinCS = 35
                }
            };
            return mConditions.ToArray();
        }

        #endregion 

    }
}
