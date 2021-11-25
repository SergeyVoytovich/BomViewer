using CsvHelper.Configuration.Attributes;

namespace BomViewer.Data.Seed
{
    /// <summary>
    /// Part seed item
    /// </summary>
    public class PartSeed
    {
        /// <summary>
        /// Component name
        /// </summary>
        [Index(1)]
        public string Name { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [Index(2)]
        public string Type { get; set; }

        /// <summary>
        /// Item
        /// </summary>
        [Index(3)]
        public string Item { get; set; }

        /// <summary>
        /// Part number
        /// </summary>
        [Index(4)]
        public string PartNumber { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Index(5)]
        public string Title { get; set; }

        /// <summary>
        /// Material
        /// </summary>
        [Index(6)]
        public string Material { get; set; }
    }
}