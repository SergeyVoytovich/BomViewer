using AutoMapper;
using BomViewer.DomainObjects;
using BomViewer.Presentation.Wpf.ViewModels;

namespace BomViewer.Presentation.Wpf.Mapping
{
    /// <summary>
    /// View models mapping profile
    /// </summary>
    public class ViewModelProfile : Profile
    {
        /// <summary>
        /// Init new instance
        /// </summary>
        public ViewModelProfile()
        {
            CreateMap<IGroup, GroupViewModel>()
                .ConstructUsingServiceLocator()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Children, opt => opt.Ignore())
                .ForMember(dst => dst.Parent, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.Parent.Id))
            ;

            CreateMap<IGroup, PartViewModel>()
                .ConstructUsingServiceLocator()
                .ForMember(dst => dst.ComponentName, opt => opt.MapFrom(src => src.Name))
                .ForAllOtherMembers(opt => opt.Ignore())
                ;

            CreateMap<IPart, PartViewModel>()
                .ConstructUsingServiceLocator()
                .ForMember(dst => dst.ComponentName, opt => opt.Ignore())
                .ForMember(dst => dst.Item, opt => opt.MapFrom(src => src.Item))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dst => dst.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dst => dst.Quantity, opt => opt.MapFrom(src => 1))
                ;
        }
    }
}