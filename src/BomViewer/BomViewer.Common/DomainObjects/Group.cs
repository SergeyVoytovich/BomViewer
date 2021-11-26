namespace BomViewer.DomainObjects
{
    /// <summary>
    /// Part group
    /// </summary>
    public class Group : DomainObjectBase, IGroup
    {
        /// <summary>
        /// Parent group
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }
    }
}
