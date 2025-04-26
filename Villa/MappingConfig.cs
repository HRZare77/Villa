using AutoMapper;
using Villa.Models;
using Villa.Models.Dto;

namespace Villa
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
