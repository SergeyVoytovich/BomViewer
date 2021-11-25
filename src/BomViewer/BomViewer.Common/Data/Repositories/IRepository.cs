using System.Collections.Generic;
using System.Threading.Tasks;
using BomViewer.DomainObjects;

namespace BomViewer.Data.Repositories
{
    /// <summary>
    /// Repository
    /// </summary>
    /// <typeparam name="T">Domain object</typeparam>
    public interface IRepository<T> where T : IDomainObject
    {
        /// <summary>
        /// Get list of objects
        /// </summary>
        /// <returns>List of objects</returns>
        Task<IList<T>> ToListAsync();
    }
}