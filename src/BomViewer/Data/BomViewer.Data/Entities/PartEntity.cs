using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BomViewer.Data.Entities
{
    /// <summary>
    /// Parts entity
    /// </summary>
    [Table("Parts")]
    public class PartEntity : EntityBase
    {
        #region Group

        [ForeignKey(nameof(Group))]
        public int? GroupId { get; set; }

        /// <summary>
        /// Parent group
        /// </summary>
        public virtual GroupEntity Group { get; set; }

        #endregion


        /// <summary>
        /// Type
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Type { get; set; }

        /// <summary>
        /// Part number
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Number { get; set; }

        /// <summary>
        /// Item
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Item { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// Material
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Material { get; set; }
    }
}