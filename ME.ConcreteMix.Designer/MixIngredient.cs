using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    public class MixIngredient : IMixIngredient, INotifyPropertyChanged
    {
        #region Public Properties

        /// <summary>
        /// Weight of ingredient used in concrete mix
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Density of ingredient used in concrete mix
        /// </summary>
        public double Density { get; set; }

        /// <summary>
        /// Volume of ingredient used in concrete mix
        /// </summary>
        public double Volume {
            get {
                return this.Weight / this.Density;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
