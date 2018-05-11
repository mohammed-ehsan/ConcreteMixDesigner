using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    /// <summary>
    /// Static class that provides linear interpolation methods
    /// </summary>
    public static class Interpolator
    {
        #region Public Methods

        public static double Interpolate(double X1, double Y1, double X2, double Y2, double X)
        {
            if (X < X1 || X > X2)
                throw new ArgumentOutOfRangeException("Provided X should fall between X1 and X2");
            double mSlope = (Y2 - Y1) / (X2 - X1);
            double mDelta = (X - X1) * mSlope;
            double result = mDelta + Y1;
            return result;
        }

        #endregion

    }
}
