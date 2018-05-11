using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    /// <summary>
    /// Concrete exposure conditon class
    /// </summary>
    public class ExposureCondition : INotifyPropertyChanged
    {
        #region Public Properties

        /// <summary>
        /// Condition of exposure
        /// </summary>
        public ExposureConditions Condition { get; private set; }

        /// <summary>
        /// Maximum water/cement ratio
        /// </summary>
        public double MaxWCRatio {get; private set;}


        /// <summary>
        /// Minimum compressive strength of concrete to be used to resist exposure condition <see cref="Condition"/>
        /// </summary>
        public double MinimumStrength { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="Condition">Exposure condition of concrete</param>
        /// <param name="MaxWCRation">Maximum water cement ration by mass</param>
        /// <param name="MinStrength">Minimum compressive strength of concrete cylinder</param>
        public ExposureCondition(ExposureConditions Condition, double MaxWCRation, double MinStrength)
        {
            this.Condition = Condition;
            this.MaxWCRatio = MaxWCRatio;
            this.MinimumStrength = MinimumStrength;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
