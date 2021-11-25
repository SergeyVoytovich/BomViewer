using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BomViewer.Data.Entities;
using BomViewer.DomainObjects;

namespace BomViewer.Data.Repositories
{
    internal class PartsRepository : RepositoryBase<IPart, PartEntity, IPartsRepository>, IPartsRepository
    {
        #region Constructors

        public PartsRepository(IQueryable<PartEntity> query, IMapper mapper) : base(query, mapper)
        {
        }

        #endregion


        #region Methods

        protected override IPartsRepository Init(IQueryable<PartEntity> query, IMapper mapper)
            => new PartsRepository(query, mapper);

        public IPartsRepository ByGroup(int id)
            => Init(entities => entities.Where(i => i.GroupId == id));

        public IPartsRepository ByGroup(IGroup group)
            => ByGroup(group?.Id ?? 0);

        public IPartsRepository ByGroups(IList<int> ids)
            => Init(entities => entities.Where(i => i.GroupId != null && ids.Contains((int)i.GroupId)));

        public IPartsRepository ByGroups(IList<IGroup> groups)
            => ByGroups(groups?.Select(i => i.Id).ToList() ?? new List<int>());

        #endregion


    }
}