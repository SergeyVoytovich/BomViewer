using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace BomViewer.Data.Seed.Readers
{
    internal class Reader<T> : IReader<T>
    {
        private readonly string _path;

        protected internal Reader(string path)
        {
            _path = string.IsNullOrWhiteSpace(path) ? throw new ArgumentNullException(nameof(path)) : path;
        }

        public IAsyncEnumerable<T> ReadAsync()
        {
            using var reader = new StreamReader(_path);
            return ReadAsync(reader);
        }

        internal IAsyncEnumerable<T> ReadAsync(StreamReader reader)
        {
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            return ReadAsync(csvReader);
        }

        internal IAsyncEnumerable<T> ReadAsync(CsvReader reader) => reader.GetRecordsAsync<T>();
    }
}