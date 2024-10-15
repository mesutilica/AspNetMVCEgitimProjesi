using AspNetMVCEgitimProjesi.NetCore.Models;
using AutoMapper;

namespace AspNetCoreMVCEgitimKonulari.Dtos
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<UyeDto, Uye>().ReverseMap();
            CreateMap<UyeListDto, Uye>().ReverseMap();
        }
    }
}
