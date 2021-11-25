using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using BomViewer.Data.Entities;
using BomViewer.Data.Seed.Readers;

[assembly: InternalsVisibleTo("BomViewer.Data.Tests")]

namespace BomViewer.Data.Seed
{
    internal class SeedBuilder : ISeedBuilder
    {
        #region Private members

        private readonly IReadersFactory _readers;
        private readonly IMapper _mapper;
        private readonly IEntityBuilder _builder;

        #endregion


        #region Constructors

        public SeedBuilder(IReadersFactory readers, IMapper mapper, IEntityBuilder modelBuilder)
        {
            _readers = readers ?? throw new ArgumentNullException(nameof(readers));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _builder = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));
        }

        #endregion


        #region Methods

        public async Task BuildAsync()
        {
            var groups = await BuildGroups();
            await BuildParts(groups);
        }

        #region BuildGroups

        internal virtual Task<IList<GroupEntity>> BuildGroups() 
            => BuildGroups(_readers.Groups("").ReadAsync().GetAsyncEnumerator());

        internal virtual async Task<IList<GroupEntity>> BuildGroups(IAsyncEnumerator<GroupSeed> groups)
        {
            if (groups == null)
            {
                throw new ArgumentNullException(nameof(groups));
            }

            var result = new List<GroupEntity>();
            while (await groups.MoveNextAsync())
            {
                BuildGroup(groups.Current, result);
            }

            return result;
        }

        internal virtual GroupEntity BuildGroup(GroupSeed seed, IList<GroupEntity> groups)
        {
            if (groups == null)
            {
                throw new ArgumentNullException(nameof(groups));
            }

            var entity = _mapper.Map<GroupEntity>(seed);
            entity.Id = groups.Count + 1;
            entity.Parent = groups.FirstOrDefault(i => string.Equals(i.Name, seed.ParentName, StringComparison.OrdinalIgnoreCase));

            _builder.HasData(entity);
            return entity;
        }

        #endregion


        #region BuildParts

        internal virtual Task BuildParts(IList<GroupEntity> groups)
            => BuildParts(groups, _readers.Parts("").ReadAsync().GetAsyncEnumerator());

        internal virtual async Task BuildParts(IList<GroupEntity> groups, IAsyncEnumerator<PartSeed> parts)
        {
            var id = 0;
            while (await parts.MoveNextAsync())
            {
                id = BuildPart(groups, parts, id);
            }
        }

        internal virtual int BuildPart(IEnumerable<GroupEntity> groups, IAsyncEnumerator<PartSeed> parts, int id)
        {
            var entity = _mapper.Map<PartEntity>(parts.Current);
            entity.Id = ++id;
            entity.Group = groups.FirstOrDefault(g => string.Equals(g.Name, parts.Current.Name, StringComparison.OrdinalIgnoreCase));

            _builder.HasData(entity);
            return id;
        }

        #endregion

        #endregion
    }
}