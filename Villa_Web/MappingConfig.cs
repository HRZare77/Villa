using AutoMapper;
using Villa_Web.Models;
using Villa_Web.Models.Dto;

namespace Villa_Web
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Models.Villa, VillaDTo>().ReverseMap();
            CreateMap<VillaDTo, Models.Villa>().ReverseMap();

            CreateMap<Models.Villa, VillaUpdateDTo>().ReverseMap();
            CreateMap<Models.Villa, VillaCreateDTo>().ReverseMap();

            CreateMap<Models.VillaNumber, VillaNumberDTo>().ReverseMap();
            CreateMap<VillaNumberDTo, Models.VillaNumber>().ReverseMap();

            CreateMap<Models.VillaNumber, VillaNumberUpdateDTo>().ReverseMap();
            CreateMap<Models.VillaNumber, VillaNumberCreateDTo>().ReverseMap();
        }
    }
}
