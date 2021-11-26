using System.Windows;

namespace BomViewer.Presentation.Wpf.Converters
{
    public class NullableToVisibleConverter : ValueConverterBase<object, Visibility>
    {
        public Visibility Nullable { get; set; } = Visibility.Collapsed;
        public Visibility NotNullable { get; set; } = Visibility.Visible;

        protected override Visibility Convert(object value)
            => value is null ? Nullable : NotNullable;
    }
}