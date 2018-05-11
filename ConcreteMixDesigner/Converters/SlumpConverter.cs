using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ME.ConcreteMix.Designer;

namespace ConcreteMixDesigner
{
    public class SlumpConverter : BaseValueConverter<SlumpConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SlumpAmount amount = (SlumpAmount)value;
            switch (amount)
            {
                case SlumpAmount.From25To50:
                    return "25 to 50";
                case SlumpAmount.From50To100:
                    return "50 to 100";
                case SlumpAmount.From150To175:
                    return "150 to 175";
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
