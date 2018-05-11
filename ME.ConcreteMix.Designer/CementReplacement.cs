using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    public class CementReplacement : ICementReplacement, INotifyPropertyChanged
    {
        #region Public Properties

        /// <summary>
        /// Material used to replace portland cement
        /// </summary>
        public CementitiousMaterial Material { get; set; }

        /// <summary>
        /// Percent of cementitious material
        /// </summary>
        public double Percent { get; set; }

        public bool LessThanMax {
            get {
                return this.Percent <= Limits[this.Material];
            }
        }

        #endregion

        #region Public Static Properties

        /// <summary>
        /// Percent limits for each cementitious material individually
        /// </summary>
        public static Dictionary<CementitiousMaterial,double> Limits =
        new Dictionary<CementitiousMaterial, double>{
            {CementitiousMaterial.FlyAshAndNaturalPozzolans,25 },
            {CementitiousMaterial.Slag, 50 },
            {CementitiousMaterial.SilicaFume, 10 }
        };

        /// <summary>
        /// Maximum summation of cementitious materials allowed
        /// </summary>
        public static double MaxSumOfMaterials = 50;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Static Methods

        /// <summary>
        /// Check if <paramref name="replacements"/> matchs the maximum percentage requirements
        /// </summary>
        /// <param name="replacements"></param>
        /// <returns></returns>
        public static bool MatchMaxRequirement(IEnumerable<ICementReplacement> replacements)
        {
            double mTotalSum = 0;
            foreach (var item in replacements)
            {
                if (!item.LessThanMax)
                    return false;
                mTotalSum += item.Percent;
            }
            if (mTotalSum > MaxSumOfMaterials)
                return false;
            return true;
        }

        #endregion
    }
}
