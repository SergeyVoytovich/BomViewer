using System;
using System.Linq;
using BomViewer.Data.Entities;
using BomViewer.Data.Seed;
using Microsoft.EntityFrameworkCore;
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

        internal DataContext(IBuilderFactory builders)
        {
            this._builders = builders;
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
            AddSeed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Disable cascading deleting for all entities
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void DisableCascadeDeleting(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys());
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }

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