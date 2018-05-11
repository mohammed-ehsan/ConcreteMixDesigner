using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using ME.Wpf.Mvvm;

namespace ConcreteMixDesigner
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter where T : new()
    {
        public static T Instance { get; set; } = new T();
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        public override object ProvideValue(IServiceProvider provider) => Instance;

    }
}
