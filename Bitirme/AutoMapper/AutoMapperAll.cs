using Application.KonularService.DTO;
using Application.KullaniciMakalelerService.DTO;
using Application.PersonelService.DTO;
using AutoMapper;
using Core.Blockchain;
using Core.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitirme.AutoMapper
{
    public class AutoMapperAll : Profile
    {
        public AutoMapperAll()
        {
            CreateMap<Personeller, PersonelListResponse>().ReverseMap();
            CreateMap<Personeller, PersonelDuzenleResponse>().ReverseMap();
            CreateMap<Konular, KonularListResponse>().ReverseMap();
            CreateMap<Konular, KonuResponse>().ReverseMap();
            CreateMap<Transactions, Transactions>().ReverseMap();
            CreateMap<BlogAdListResponse, Makaleler>().ReverseMap();
        }
    }
}
