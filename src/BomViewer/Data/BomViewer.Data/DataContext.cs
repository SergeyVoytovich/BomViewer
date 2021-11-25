using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.Internal;
using BomViewer.Data.Entities;
using BomViewer.Data.Mapping;
using BomViewer.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BomViewer.Data
{
    /// <summary>
    /// Data context
    /// </summary>
    internal class DataContext : DbContext
    {
        #region Private members

        private readonly IBuilderFactory _builders;

        #endregion


        #region Properties

        /// <summary>
        /// Groups
        /// </summary>
        public DbSet<GroupEntity> Groups { get; set; }

        /// <summary>
        /// Parts
        /// </summary>
        public DbSet<PartEntity> Parts { get; set; }

        #endregion


        #region Constructors

        public DataContext() : this(new BuilderFactory(MapperFactory.Init()))
        {
        }

        private DataContext(IBuilderFactory builders)
        {
            _builders = builders;
        }

        #endregion


        #region Methods

        /// <summary>
        /// See <see cref="DbContext.OnConfiguring"/>
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("BomDatabase"));
        }

        /// <summary>
        /// See <see cref="DbContext.OnModelCreating"/>
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DisableCascadeDeleting(modelBuilder);

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            AddSeed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        #region DisableCascadeDeleting

        /// <summary>
        /// Disable cascading deleting for all entities
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void DisableCascadeDeleting(ModelBuilder modelBuilder)
            => DisableCascadeDeleting(modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()));

        private void DisableCascadeDeleting(IEnumerable<IMutableForeignKey> keys) 
            => keys.ForAll(key => key.DeleteBehavior = DeleteBehavior.NoAction);

        #endregion

        #region AddSeed

        /// <summary>
        /// Add seed data
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void AddSeed(ModelBuilder modelBuilder) => AddSeed(_builders.Init(modelBuilder));

        /// <summary>
        /// Add seed data
        /// </summary>
        /// <param name="builder"></param>
        private void AddSeed(ISeedBuilder builder) => builder?.BuildAsync().Wait();

        #endregion

        #endregion
    }
}