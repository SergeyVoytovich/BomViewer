using System.IO;
using BomViewer.Presentation.Wpf.ViewModels;

namespace BomViewer.Presentation.Wpf.Converters
{
    /// <summary>
    /// Group path to string converter
    /// </summary>
    public class GroupPathToStringConverter : ValueConverterBase<GroupViewModel, string>
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override string Convert(GroupViewModel value)
            => value?.Parent is null ? value?.Name : Path.Combine(Convert(value.Parent), value.Name);


    }
}