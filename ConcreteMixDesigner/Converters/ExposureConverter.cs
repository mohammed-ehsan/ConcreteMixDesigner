using ME.ConcreteMix.Designer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteMixDesigner
{
    public class ExposureConverter : BaseValueConverter<ExposureConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ExposureConditions condition = (ExposureConditions)value;
            switch (condition)
            {
                case ExposureConditions.Protected:
                    return "Protected";
                case ExposureConditions.WaterExposed:
                    return "Water Exposed";
                case ExposureConditions.FreezingAndThawing:
                    return "Freezing and Thawing";
                case ExposureConditions.CorrosionExposed:
                    return "Corrosion Exposed";
                default:
                    break;
            }
            return string.Empty;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
