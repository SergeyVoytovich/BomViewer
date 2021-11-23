using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BomViewer.Data.Entities
{
    /// <summary>
    /// Group entity
    /// </summary>
    [Table("Groups")]
    public class GroupEntity : EntityBase
    {
        #region Parent

        [ForeignKey(nameof(Parent))]
        public int? ParentId { get; set; }

        /// <summary>
        /// Parent group
        /// </summary>
        public virtual GroupEntity Parent { get; set; }

        #endregion

        /// <summary>
        /// Group name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}