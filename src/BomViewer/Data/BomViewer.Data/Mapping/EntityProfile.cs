using AutoMapper;
using BomViewer.Data.Entities;
using BomViewer.DomainObjects;

namespace BomViewer.Data.Mapping
{
    internal class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<EntityBase, IDomainObject>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap()
                ;


            CreateMap<GroupEntity, IGroup>()
                .ConstructUsing(e => new Group())
                .IncludeBase<EntityBase, IDomainObject>()
                .ForMember(dst => dst.ParentId, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap()
                .ForMember(dst => dst.Parent, opt => opt.Ignore())
                ;

            CreateMap<PartEntity, IPart>()
                .ConstructUsing(e => new Part())
                .IncludeBase<EntityBase, IDomainObject>()
                .ForMember(dst => dst.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dst => dst.Material, opt => opt.MapFrom(src => src.Material))
                .ForMember(dst => dst.Item, opt => opt.MapFrom(src => src.Item))
                .ForMember(dst => dst.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                .ReverseMap()
                .ForMember(dst => dst.Group, opt => opt.Ignore())
                ;
        }
    }
}