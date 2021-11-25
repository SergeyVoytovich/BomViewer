using System.Collections.Generic;
using System.Threading.Tasks;
using BomViewer.DomainObjects;

namespace BomViewer.Application
{
    /// <summary>
    /// Application
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// Get groups
        /// </summary>
        /// <returns></returns>
        Task<IList<IGroup>> GetGroupsAsync();

        /// <summary>
        /// Get parts for groups
        /// </summary>
        /// <param name="groups">List of groups</param>
        /// <returns></returns>
        Task<IList<IPart>> GetPartsAsync(IList<IGroup> groups);
    }
}