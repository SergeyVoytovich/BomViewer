using System.Linq;
using AutoMapper;
using BomViewer.Data.Entities;
using BomViewer.DomainObjects;

namespace BomViewer.Data.Repositories
{
    internal class GroupsRepository : RepositoryBase<IGroup, GroupEntity, IRepository<IGroup>>
    {
        public GroupsRepository(IQueryable<GroupEntity> query, IMapper mapper) : base(query, mapper)
        {
        }

        protected override IRepository<IGroup> Init(IQueryable<GroupEntity> query, IMapper mapper)
            => new GroupsRepository(query, mapper);
    }
}