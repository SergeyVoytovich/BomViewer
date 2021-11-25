using System.Linq;
using AutoMapper;
using BomViewer.Data.Entities;
using BomViewer.DomainObjects;

namespace BomViewer.Data.Repositories
{
    internal class GroupsRepository : RepositoryBase<IGroup, GroupEntity, IGroupsRepository>, IGroupsRepository
    {
        public GroupsRepository(IQueryable<GroupEntity> query, IMapper mapper) : base(query, mapper)
        {
        }

        protected override IGroupsRepository Init(IQueryable<GroupEntity> query, IMapper mapper)
            => new GroupsRepository(query, mapper);
    }
}