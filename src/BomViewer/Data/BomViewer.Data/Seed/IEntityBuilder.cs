using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BomViewer.Data.Seed
{
    /// <summary>
    /// Entity builder
    /// </summary>
    public interface IEntityBuilder
    {
        /// <summary>
        /// See <see cref="EntityTypeBuilder{TEntity}.HasData(TEntity[])"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void HasData<T>(T entity) where T : class;
    }
} 