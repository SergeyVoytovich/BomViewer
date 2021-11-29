namespace BomViewer.Presentation.Wpf.Converters
{
    /// <summary>
    /// Nullable object to string converter
    /// </summary>
    public class NullableToBoolConverter : ValueConverterBase<object, bool>
    {
        /// <summary>
        /// Value by nullable object
        /// </summary>
        public bool Nullable { get; set; } = false;

        /// <summary>
        /// Value by not nullable object
        /// </summary>
        public bool NotNullable { get; set; } = true;

        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool Convert(object value)
            => value is null ? Nullable : NotNullable;
    }
}