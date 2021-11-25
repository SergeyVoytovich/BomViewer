using System.Collections.Generic;
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
        IList<IGroup> GetGroups();

        /// <summary>
        /// Get parts for groups
        /// </summary>
        /// <param name="groups">List of groups</param>
        /// <returns></returns>
        IList<IPart> GetParts(IList<IGroup> groups);
    }
}