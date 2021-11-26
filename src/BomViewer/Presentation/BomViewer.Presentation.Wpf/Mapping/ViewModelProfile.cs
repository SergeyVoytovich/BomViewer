using AutoMapper;
using BomViewer.DomainObjects;
using BomViewer.Presentation.Wpf.ViewModels;

namespace BomViewer.Presentation.Wpf.Mapping
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<IGroup, GroupViewModel>()
                .ConstructUsingServiceLocator()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Children, opt => opt.Ignore())
            ;
        }
    }
}