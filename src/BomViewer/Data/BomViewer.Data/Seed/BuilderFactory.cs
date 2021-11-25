using System;
using AutoMapper;
using BomViewer.Data.Seed.Readers;
using Microsoft.EntityFrameworkCore;

namespace BomViewer.Data.Seed
{
    /// <summary>
    /// Builder factory
    /// </summary>
    internal class BuilderFactory : IBuilderFactory
    {
        #region Private members

        private readonly IReadersFactory _readers;
        private readonly IMapper _mapper;

        #endregion


        #region Constructors

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="mapper">Mapper</param>
        public BuilderFactory(IMapper mapper) : this(new ReadersFactory(), mapper)
        {
        }

        /// <summary>
        /// Init new instance
        /// </summary>
        /// <param name="readers">Reader factory</param>
        /// <param name="mapper">Mapper</param>
        public BuilderFactory(IReadersFactory readers, IMapper mapper)
        {
            _readers = readers ?? throw new ArgumentNullException(nameof(readers));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion


        #region Methods

        /// <summary>
        /// Init new seed builder
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <returns>Seed builder</returns>
        public ISeedBuilder Init(ModelBuilder modelBuilder) 
            => Init(new EntityBuilder(modelBuilder));

        /// <summary>
        /// Init new seed builder
        /// </summary>
        /// <param name="builder">Entity builder</param>
        /// <returns>Seed builder</returns>
        private ISeedBuilder Init(IEntityBuilder builder)
            => new SeedBuilder(_readers, _mapper, builder);

        #endregion
    }
}