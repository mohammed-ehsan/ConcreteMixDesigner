using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    public class AdmixtureMaterial : INotifyPropertyChanged
    {
        #region Public Properties

        /// <summary>
        /// Dosage of admixture in gm per kg of cement
        /// </summary>
        public double Dosage { get; set; }

        /// <summary>
        /// Total weight of admixture in kg per m^3 of concrete
        /// </summary>
        public double Weight { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the weight <see cref="Weight"/> of this admixture in kg
        /// </summary>
        /// <param name="cementContent">Cement content of concrete mix in kg/m^3</param>
        /// <returns>The weight of the admixture in kg/m^3 of concrete mix</returns>
        public double SetWeight(double cementContent)
        {
            this.Weight = cementContent * Dosage / 1000;
            return this.Weight;
        }

        #endregion
    }
}
