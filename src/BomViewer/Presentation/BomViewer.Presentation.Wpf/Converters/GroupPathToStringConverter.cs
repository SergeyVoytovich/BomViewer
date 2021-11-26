using System.IO;
using BomViewer.Presentation.Wpf.ViewModels;

namespace BomViewer.Presentation.Wpf.Converters
{
    public class GroupPathToStringConverter : ValueConverterBase<GroupViewModel, string>
    {
        protected override string Convert(GroupViewModel value)
            => value?.Parent is null ? value?.Name : Path.Combine(Convert(value.Parent), value.Name);


    }
}