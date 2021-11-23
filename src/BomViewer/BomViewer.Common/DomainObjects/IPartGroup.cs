namespace BomViewer.Common.DomainObjects
{
    /// <summary>
    /// Part group
    /// </summary>
    public interface IPartGroup : IDomainObjectBase
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