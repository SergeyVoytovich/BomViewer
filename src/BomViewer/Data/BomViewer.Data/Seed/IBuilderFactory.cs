using Microsoft.EntityFrameworkCore;

namespace BomViewer.Data.Seed
{
    /// <summary>
    /// Builder factory
    /// </summary>
    internal interface IBuilderFactory
    {
        /// <summary>
        /// Init new seed builder
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <returns>Seed builder</returns>
        ISeedBuilder Init(ModelBuilder modelBuilder);
    }
}