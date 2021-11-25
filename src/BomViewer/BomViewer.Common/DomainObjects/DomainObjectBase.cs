namespace BomViewer.DomainObjects
{
    public abstract class DomainObjectBase : IDomainObject
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }
    }
}