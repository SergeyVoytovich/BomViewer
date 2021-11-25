using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomViewer.Data.Entities;
using BomViewer.Data.Seed.Readers;

namespace BomViewer.Data.Seed
{
    internal class SeedBuilder : ISeedBuilder
    {
        #region Private members

        private readonly IReadersFactory _readers;
        private readonly IMapper _mapper;
        private readonly IEntityBuilder _builder;

        #endregion


        #region Public constants

        public const string GroupsFileName = "bom.csv";
        public const string PartsFileName = "part.csv";

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
            var groups = await BuildGroupsAsync();
            await BuildPartsAsync(groups);
        }

        #region BuildGroups

        internal virtual Task<IList<GroupEntity>> BuildGroupsAsync() 
            => BuildGroupsAsync(_readers.Groups(GroupsFileName));

        internal virtual Task<IList<GroupEntity>> BuildGroupsAsync(IReader<GroupSeed> reader)
            => BuildGroupsAsync(reader?.ReadAsync());

        internal virtual Task<IList<GroupEntity>> BuildGroupsAsync(IAsyncEnumerable<GroupSeed> seed)
            => BuildGroupsAsync(seed?.GetAsyncEnumerator());

        internal virtual async Task<IList<GroupEntity>> BuildGroupsAsync(IAsyncEnumerator<GroupSeed> seed)
        {
            if (seed == null)
            {
                throw new ArgumentNullException(nameof(seed));
            }

            var result = new List<GroupEntity>();
            while (await seed.MoveNextAsync())
            {
                result.Add(BuildGroup(seed.Current, result));
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

        internal virtual Task BuildPartsAsync(IList<GroupEntity> groups)
            => BuildPartsAsync(groups, _readers.Parts(PartsFileName));

        internal virtual Task BuildPartsAsync(IList<GroupEntity> groups, IReader<PartSeed> reader)
            => BuildPartsAsync(groups, reader.ReadAsync());

        internal virtual Task BuildPartsAsync(IList<GroupEntity> groups, IAsyncEnumerable<PartSeed> seed)
            => BuildPartsAsync(groups, seed.GetAsyncEnumerator());

        internal virtual async Task BuildPartsAsync(IList<GroupEntity> groups, IAsyncEnumerator<PartSeed> parts)
        {
            var id = 0;
            while (await parts.MoveNextAsync())
            {
                id = BuildPart(groups, parts.Current, id);
            }
        }

        internal virtual int BuildPart(IEnumerable<GroupEntity> groups, PartSeed part, int id)
        {
            var entity = _mapper.Map<PartEntity>(part);
            entity.Id = id + 1;
            entity.Group = groups.FirstOrDefault(g => string.Equals(g.Name, part.Name, StringComparison.OrdinalIgnoreCase));

            _builder.HasData(entity);
            return entity.Id;
        }

        #endregion

        #endregion
    }
}