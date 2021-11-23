using BomViewer.Data.Repositories;

namespace BomViewer.Data
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