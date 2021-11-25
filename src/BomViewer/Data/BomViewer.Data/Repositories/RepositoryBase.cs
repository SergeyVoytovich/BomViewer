using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BomViewer.Data.Entities;
using BomViewer.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace BomViewer.Data.Repositories
{
    internal abstract class RepositoryBase<TDomain, TEntity, TRepository> : IRepository<TDomain>
        where TDomain : IDomainObject
        where TEntity : EntityBase
        where TRepository : IRepository<TDomain>
    {

        #region Properties

        protected IMapper Mapper { get; }
        protected IQueryable<TEntity> Query { get; }

        #endregion


        #region Constructors

        protected RepositoryBase(IQueryable<TEntity> query, IMapper mapper)
        {
            Query = query ?? throw new ArgumentNullException(nameof(query));
            Mapper = mapper;
        }

        #endregion



        #region Methods

        #region Select

        public async Task<IList<TDomain>> ToListAsync()
        {
            var entities = await Query.ToListAsync();
            var domains = Mapper.Map<IList<TEntity>, IList<TDomain>>(entities);
            return domains;
        }

        #endregion


        #region Fluent

        protected abstract TRepository Init(IQueryable<TEntity> query, IMapper mapper);

        internal TRepository Init(Func<IQueryable<TEntity>, IQueryable<TEntity>> aPredicate)
            => Init(aPredicate(Query), Mapper);

        #endregion


        #endregion


    }
}