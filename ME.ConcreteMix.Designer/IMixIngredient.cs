using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    /// <summary>
    /// Represents an ingredient of concrete mix
    /// </summary>
    public interface IMixIngredient
    {
        /// <summary>
        /// Weight of ingredient used in concrete mix
        /// </summary>
        double Weight { get; set; }

        /// <summary>
        /// Density of ingredient used in concrete mix
        /// </summary>
        double Density { get; set; }

        /// <summary>
        /// Volume of ingredient used in concrete mix
        /// </summary>
        double Volume { get; }
    }
}
