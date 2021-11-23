namespace BomViewer.Common.DomainObjects
{
    /// <summary>
    /// Part group
    /// </summary>
    public class PartGroup : DomainObjectBase, IPartGroup
    {
        /// <summary>
        /// Parent group
        /// </summary>
        public IPartGroup Parent { get; set; }

        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }
    }
}
