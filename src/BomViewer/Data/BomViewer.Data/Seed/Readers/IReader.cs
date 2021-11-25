using System.Collections.Generic;

namespace BomViewer.Data.Seed.Readers
{
    /// <summary>
    /// Seed reader
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IReader<T>
    {
        /// <summary>
        /// Read objects
        /// </summary>
        /// <returns>Objects</returns>
        IAsyncEnumerable<T> ReadAsync();
    }
}