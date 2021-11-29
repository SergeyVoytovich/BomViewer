using AutoMapper;

namespace BomViewer.Presentation.Wpf.Mapping
{
    /// <summary>
    /// Mapping factory
    /// </summary>
    public class MappingFactory
    {
        /// <summary>
        /// Init new mapper
        /// </summary>
        /// <returns></returns>
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