using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    /// <summary>
    /// Defines a finite range between two predefined values
    /// </summary>
    public class Range : INotifyPropertyChanged
    {

        #region Public properties

        /// <summary>
        /// Minimum value included
        /// </summary>
        public double Min { get; private set; }

        /// <summary>
        /// Maximum value included
        /// </summary>
        public double Max { get; private set; }

        /// <summary>
        /// Is minimum value included in range
        /// </summary>
        public bool MinIncluded { get;private set; }

        /// <summary>
        /// Is maximum value included in range
        /// </summary>
        public bool MaxIncluded { get;private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="Min">Minimum value</param>
        /// <param name="Max">Maximum value</param>
        /// <param name="MinIncluded">Include min value</param>
        /// <param name="MaxIncluded">Include max value</param>
        public Range(double Min, double Max, bool MinIncluded, bool MaxIncluded)
        {
            this.Min = Min;
            this.Max = Max;
            this.MinIncluded = MinIncluded;
            this.MaxIncluded = MaxIncluded;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns true of the value <paramref name="value"/> provided falls within <see cref="Min"/> and <see cref="Max"/> values.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsWithin(double value)
        {
            bool mMatchMin;
            bool mMatchMax;
            if (this.MinIncluded)
                mMatchMin = value >= this.Min;
            else
                mMatchMin = value > this.Min;
            if (this.MaxIncluded)
                mMatchMax = value <= this.Max;
            else
                mMatchMax = value < this.Max;
            return mMatchMin && mMatchMax;
        }

        #endregion
    }
}
