using System.Windows;

namespace BomViewer.Presentation.Wpf.Converters
{
    /// <summary>
    /// Nullable object to visibility converter
    /// </summary>
    public class NullableToVisibleConverter : ValueConverterBase<object, Visibility>
    {
        /// <summary>
        /// Value by nullable object
        /// </summary>
        public Visibility Nullable { get; set; } = Visibility.Collapsed;

        /// <summary>
        /// Value by not nullable object
        /// </summary>
        public Visibility NotNullable { get; set; } = Visibility.Visible;

        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override Visibility Convert(object value)
            => value is null ? Nullable : NotNullable;
    }
}