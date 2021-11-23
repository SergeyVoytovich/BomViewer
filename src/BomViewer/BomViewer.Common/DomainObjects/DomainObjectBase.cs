namespace BomViewer.Common.DomainObjects
{
    public abstract class DomainObjectBase : IDomainObjectBase
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }
    }
}