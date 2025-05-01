using AutoMapper;
using Villa_Web.Models;
using Villa_Web.Models.Dto;

namespace Villa_Web
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa_Web.Models.Villa, VillaDTo>().ReverseMap();
            CreateMap<Villa_Web.Models.Villa, VillaCreateDTo>().ReverseMap();
            CreateMap<Villa_Web.Models.Villa, VillaUpdateDTo>().ReverseMap();


            CreateMap<Models.VillaNumber, VillaNumberDTo>().ReverseMap();
        }
    }
}
