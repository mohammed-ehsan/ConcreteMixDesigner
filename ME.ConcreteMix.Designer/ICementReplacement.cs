using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    public interface ICementReplacement
    {
        /// <summary>
        /// Type of cementitious material
        /// </summary>
        CementitiousMaterial Material { get; set; }

        /// <summary>
        /// Percent of material to replace cement
        /// </summary>
        double Percent { get; set; }

        /// <summary>
        /// Checks if the <see cref="Percent"/> of material is less than maximum allowed
        /// </summary>
        bool LessThanMax { get; }
    }
}
