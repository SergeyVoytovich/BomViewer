namespace BomViewer.DomainObjects
{
    /// <summary>
    /// Base domain object
    /// </summary>
    public interface IDomainObject
    {
        /// <summary>
        /// Identifier
        /// </summary>
        int Id { get; set; }
    }
}