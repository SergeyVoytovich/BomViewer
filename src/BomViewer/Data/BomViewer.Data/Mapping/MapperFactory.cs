using AutoMapper;

namespace BomViewer.Data.Mapping
{
    public class MapperFactory
    {
        public static IMapper Init()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<SeedProfile>();
            });

            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}