using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BomViewer.Data;
using BomViewer.DomainObjects;

namespace BomViewer.Application
{
    public class Application : IApplication
    {
        #region Private members

        private readonly IDataSource _dataSource;

        #endregion


        #region Constructors

        public Application(IDataSource dataSource)
        {
            _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
        }

        #endregion


        #region Methods

        public Task<IList<IGroup>> GetGroupsAsync()
            => _dataSource.Groups.ToListAsync();

        public Task<IList<IPart>> GetPartsAsync(IList<IGroup> groups)
            => _dataSource.Parts.ByGroups(groups).ToListAsync();

        #endregion
    }
}