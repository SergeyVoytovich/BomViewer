using AutoMapper;

namespace BomViewer.Presentation.Wpf.Mapping
{
    public class MappingFactory
    {
        public static IMapper Init()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<ViewModelProfile>();
            });

            config.AssertConfigurationIsValid();
            return config.CreateMapper();
        }
    }
}