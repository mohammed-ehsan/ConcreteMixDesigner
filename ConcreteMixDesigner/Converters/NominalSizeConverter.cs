using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ME.ConcreteMix.Designer;

namespace ConcreteMixDesigner
{
    public class NominalSizeConverter : BaseValueConverter<NominalSizeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NominalAggregateSize size = (NominalAggregateSize)value;
            switch (size)
            {
                case NominalAggregateSize.Size9_5:
                    return "9.5mm";
                case NominalAggregateSize.Size12_5:
                    return "12.5mm";
                case NominalAggregateSize.Size19:
                    return "19mm";
                case NominalAggregateSize.Size25:
                    return "25mm";
                case NominalAggregateSize.Size37_5:
                    return "37.5mm";
                case NominalAggregateSize.Size50:
                    return "50mm";
                case NominalAggregateSize.Size75:
                    return "75mm";
                case NominalAggregateSize.Size150:
                    return "150mm";
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
