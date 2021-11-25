namespace BomViewer.Data.Seed.Readers
{
    /// <summary>
    /// Readers factory
    /// </summary>
    internal interface IReadersFactory
    {
        /// <summary>
        /// Init groups reader
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>List of groups seed</returns>
        IReader<GroupSeed> Groups(string path);

        /// <summary>
        /// Init parts reader
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>List of parts seed</returns>
        IReader<PartSeed> Parts(string path);
    }
}