using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    /// <summary>
    /// Typical standard deviation to be used if not provided from labratory samples
    /// </summary>
    public class TypicalSD : INotifyPropertyChanged
    {
        #region Public Properties

        /// <summary>
        /// Typical standard deviation of the concrete strength
        /// </summary>
        public double StandardDeviation { get; private set; }
        
        /// <summary>
        /// Control degree of concrete mix environment
        /// </summary>
        public ControlDegree ControlDegree { get; private set; }

        /// <summary>
        /// Discreption of this typical standard deviation
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Constructors

        public TypicalSD(double StandardDeviation, ControlDegree ControlDegree)
        {
            this.StandardDeviation = StandardDeviation;
            this.ControlDegree = ControlDegree;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
