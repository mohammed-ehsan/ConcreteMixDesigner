using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    public interface IAggregate : IMixIngredient
    {
        /// <summary>
        /// Absorption of water in percentage
        /// </summary>
        double Absorbtion { get; set; }

        /// <summary>
        /// Moisture content in percentage
        /// </summary>
        double MoistureContent { get; set; }

        /// <summary>
        /// Sepcific gravity of aggregate
        /// </summary>
        double SpecificGravity { get; set; }
    }
}
