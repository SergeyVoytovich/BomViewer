using System;

namespace BomViewer.Data.Seed.Readers
{
    /// <summary>
    /// Readers factory
    /// </summary>
    internal class ReadersFactory : IReadersFactory
    {
        /// <summary>
        /// Init groups reader
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>List of groups seed</returns>
        public IReader<GroupSeed> Groups(string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Init parts reader
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>List of parts seed</returns>
        public IReader<PartSeed> Parts(string path)
        {
            throw new NotImplementedException();
        }
    }
}