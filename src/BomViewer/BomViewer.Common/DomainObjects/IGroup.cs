namespace BomViewer.DomainObjects
{
    /// <summary>
    /// Part group
    /// </summary>
    public interface IGroup : IDomainObject
    {
        /// <summary>
        /// Parent group id
        /// </summary>
        int ParentId { get; set; }

        /// <summary>
        /// Group name
        /// </summary>
        string Name { get; set; }
    }
}