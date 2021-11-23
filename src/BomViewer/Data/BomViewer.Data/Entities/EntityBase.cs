using System.ComponentModel.DataAnnotations;

namespace BomViewer.Data.Entities
{
    /// <summary>
    /// Base entity
    /// </summary>
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}