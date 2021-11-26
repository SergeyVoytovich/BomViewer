namespace BomViewer.Presentation.Wpf.Converters
{
    public class NullableToBoolConverter : ValueConverterBase<object, bool>
    {
        public bool Nullable { get; set; } = false;
        public bool NotNullable { get; set; } = true;

        protected override bool Convert(object value)
            => value is null ? Nullable : NotNullable;
    }
}