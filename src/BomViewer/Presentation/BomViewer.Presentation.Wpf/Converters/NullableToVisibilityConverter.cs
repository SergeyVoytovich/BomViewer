namespace BomViewer.Presentation.Wpf.Converters
{
    public class NullableToBoolConverter : ValueConverterBase<object, bool>
    {
        protected bool Nullable { get; set; } = false;
        protected bool NotNullable { get; set; } = true;

        protected override bool Convert(object value)
            => value is null ? Nullable : NotNullable;
    }
}