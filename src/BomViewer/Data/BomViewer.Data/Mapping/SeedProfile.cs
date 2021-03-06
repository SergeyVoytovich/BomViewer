using AutoMapper;
using BomViewer.Data.Entities;
using BomViewer.Data.Seed;

namespace BomViewer.Data.Mapping
{
    internal class SeedProfile : Profile
    {
        public SeedProfile()
        {
            CreateMap<GroupSeed, GroupEntity>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.ParentId, opt => opt.Ignore())
                .ForMember(dst => dst.Parent, opt => opt.Ignore())
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.ComponentName))
                ;

            CreateMap<PartSeed, PartEntity>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.GroupId, opt => opt.Ignore())
                .ForMember(dst => dst.Group, opt => opt.Ignore())
                .ForMember(dst => dst.Item, opt => opt.MapFrom(src => src.Item))
                .ForMember(dst => dst.Material, opt => opt.MapFrom(src => src.Material))
                .ForMember(dst => dst.Number, opt => opt.MapFrom(src => src.PartNumber))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dst => dst.Type, opt => opt.MapFrom(src => src.Type))
                ;
        }
    }
}