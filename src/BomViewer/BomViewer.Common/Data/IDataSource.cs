using BomViewer.Common.Data.Repositories;

namespace BomViewer.Common.Data
{
    /// <summary>
    /// Data source
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Groups repository
        /// </summary>
        IGroupsRepository Groups { get; }

        /// <summary>
        /// Parts repository
        /// </summary>
        IPartsRepository Parts { get; }
    }
}