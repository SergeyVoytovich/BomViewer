using System;
using BomViewer.Data.Entities;
using Microsoft.EntityFrameworkCore;

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
        }

        #endregion
    }
}