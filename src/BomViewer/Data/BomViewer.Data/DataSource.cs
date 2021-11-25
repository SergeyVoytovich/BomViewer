using System;
using AutoMapper;
using BomViewer.Data.Mapping;
using BomViewer.Data.Repositories;

namespace BomViewer.Data
{
    public class DataSource : IDataSource
    {
        #region Properties

        public IGroupsRepository Groups { get; }
        public IPartsRepository Parts { get; }

        #endregion


        #region Constructors

        public DataSource()
            : this(new DataContext(), MapperFactory.Init())
        {
        }

        internal DataSource(DataContext context, IMapper mapper)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            Groups = new GroupsRepository(context.Groups.AsQueryable(), mapper);
            Parts = new PartsRepository(context.Parts.AsQueryable(), mapper);
        }

        #endregion
    }
}