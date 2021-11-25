using System.Collections.Generic;
using BomViewer.DomainObjects;

namespace BomViewer.Data.Repositories
{
    /// <summary>
    /// Parts repository
    /// </summary>
    public interface IPartsRepository : IRepository<IPart>
    {
        /// <summary>
        /// Filter by group
        /// </summary>
        /// <param name="id">Group id</param>
        /// <returns>Parts repository</returns>
        IPartsRepository ByGroup(int id);

        /// <summary>
        /// Filter by group
        /// </summary>
        /// <param name="group">Group</param>
        /// <returns>Parts repository</returns>
        IPartsRepository ByGroup(IGroup group);

        /// <summary>
        /// Filter by groups
        /// </summary>
        /// <param name="ids">List of group ids</param>
        /// <returns>Parts repository</returns>
        IPartsRepository ByGroups(IList<int> ids);

        /// <summary>
        /// Filter by groups
        /// </summary>
        /// <param name="groups">List of groups</param>
        /// <returns>Parts repository</returns>
        IPartsRepository ByGroups(IList<IGroup> groups);
    }
}