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

        public async IAsyncEnumerable<T> ReadAsync()
        {
            using var reader = new StreamReader(_path);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            var enumerator = csvReader.GetRecordsAsync<T>().GetAsyncEnumerator();
            while (await enumerator.MoveNextAsync())
            {
                yield return enumerator.Current;
            }
        }
        
    }
}