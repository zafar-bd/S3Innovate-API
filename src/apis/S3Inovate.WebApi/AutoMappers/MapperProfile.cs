using AutoMapper;
using S3Inovate.Core.Models;
using S3Inovate.Core.ViewModels;

namespace S3Inovate.WebApi.AutoMappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Reading, ReadingVm>();
                //.ForMember(v => v.Timestamp,
                //          e => e.MapFrom(v => v.Timestamp.Ticks));

            CreateMap<Building, BuildingVm>()
               .ForMember(v => v.Name,
                          e => e.MapFrom(v => $"{v.Name} {v.Location}"));

            CreateMap<DataField, DataFieldVm>();

            CreateMap<Core.Models.Object, ObjectVm>();
        }
    }
}
