using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BomViewer.Data.Seed
{
    internal interface ISeedBuilder
    {
        Task BuildAsync(ModelBuilder modelBuilder);
    }
}