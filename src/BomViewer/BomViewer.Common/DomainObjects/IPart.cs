﻿namespace BomViewer.Common.DomainObjects
{
    /// <summary>
    /// Part
    /// </summary>
    public interface IPart : IDomainObjectBase
    {
        /// <summary>
        /// Group id
        /// </summary>
        int GroupId { get; set; }
        
        /// <summary>
        /// Type
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Part number
        /// </summary>
        string Number { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Material
        /// </summary>
        string Material { get; set; }
    }
}