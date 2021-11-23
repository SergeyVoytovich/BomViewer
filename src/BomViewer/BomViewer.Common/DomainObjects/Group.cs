namespace BomViewer.Common.DomainObjects
{
    /// <summary>
    /// Part group
    /// </summary>
    public class Group : DomainObjectBase, IGroup
    {
        /// <summary>
        /// Parent group
        /// </summary>
        public IGroup Parent { get; set; }

        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }
    }
}
