using AutoMapper;

namespace BomViewer.Data.Mapping
{
    internal static class MapperFactory
    {
        public static IMapper Init()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<SeedProfile>();
                c.AddProfile<EntityProfile>();
            });

            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}