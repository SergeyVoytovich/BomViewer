using CsvHelper.Configuration.Attributes;

namespace BomViewer.Data.Seed
{
    /// <summary>
    /// Group seed item
    /// </summary>
    public class GroupSeed
    {
        /// <summary>
        /// Parent name
        /// </summary>
        [Index(0)]
        public string ParentName { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [Index(1)]
        public int Quantity { get; set; }

        /// <summary>
        /// Component name
        /// </summary>
        [Index(2)]
        public string ComponentName { get; set; }
    }
}