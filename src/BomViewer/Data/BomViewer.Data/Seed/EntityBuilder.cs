using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BomViewer.Data.Seed
{
    /// <summary>
    /// Entity builder
    /// </summary>
    internal class EntityBuilder : IEntityBuilder
    {
        #region Private mbmers

        private readonly ModelBuilder _builder;

        #endregion


        #region Constructors

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="builder">Model builder</param>
        public EntityBuilder(ModelBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        #endregion


        #region Methods

        /// <summary>
        /// See <see cref="EntityTypeBuilder{TEntity}.HasData(TEntity[])"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void HasData<T>(T entity) where T : class 
            => _builder.Entity<T>().HasData(entity);

        #endregion
    }
}