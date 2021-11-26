using System;
using System.Globalization;
using System.Windows.Data;

namespace BomViewer.Presentation.Wpf.Converters
{
    public abstract class ValueConverterBase<TIn, TOut> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
            => value is TIn typed ? Convert(typed) : Convert(default);

        protected abstract TOut Convert(TIn value);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => value is TOut typed ? ConvertBack(typed) : Convert(default);

        protected virtual TIn ConvertBack(TOut value)
        {
            return default;
        }
    }
}