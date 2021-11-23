using System.Collections.Generic;
using BomViewer.DomainObjects;

namespace BomViewer.Data.Repositories
{
    /// <summary>
    /// Groups repository
    /// </summary>
    public interface IGroupsRepository : IRepository<IGroup>
    {
        /// <summary>
        /// Filter by parent group
        /// </summary>
        /// <param name="id">Parent group id</param>
        /// <returns>Groups repository</returns>
        IGroupsRepository ByParent(int id);

        /// <summary>
        /// Filter by parent group
        /// </summary>
        /// <param name="group">Parent group</param>
        /// <returns>Groups repository</returns>
        IGroupsRepository ByParent(IGroup group);

        /// <summary>
        /// Filter by parent groups
        /// </summary>
        /// <param name="ids">List of parent ids</param>
        /// <returns></returns>
        IGroupsRepository ByParents(IList<int> ids);

        /// <summary>
        /// Filter by parent groups
        /// </summary>
        /// <param name="groups">List of parent groups</param>
        /// <returns>Groups repository</returns>
        IGroupsRepository ByParents(IList<IGroup> groups);
    }
}