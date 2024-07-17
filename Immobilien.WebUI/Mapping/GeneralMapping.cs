using AutoMapper;
using Immobilien.Dto.Dtos.BannerDtos;
using Immobilien.Entity.Entities;

namespace Immobilien.WebUI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<ResultBannerDto, Banner>().ReverseMap();
            CreateMap<UpdateBannerDto, Banner>().ReverseMap();
            CreateMap<CreateBannerDto, Banner>().ReverseMap();
            
        }
    }
}
