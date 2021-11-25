using System.Threading.Tasks;

namespace BomViewer.Data.Seed
{
    /// <summary>
    /// Seed data builder
    /// </summary>
    internal interface ISeedBuilder
    {
        /// <summary>
        /// Build seed data async
        /// </summary>
        /// <returns></returns>
        Task BuildAsync();
    }
}