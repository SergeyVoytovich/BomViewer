namespace BomViewer.DomainObjects
{
    /// <summary>
    /// Part
    /// </summary>
    public class Part : DomainObjectBase, IPart
    {
        /// <summary>
        /// Group id
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Part number
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Material
        /// </summary>
        public string Material { get; set; }
    }
}