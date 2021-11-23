using System;
using System.Linq;
using BomViewer.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BomViewer.Data
{
    /// <summary>
    /// Data context
    /// </summary>
    internal class DataContext : DbContext
    {
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

        #endregion
    }
}