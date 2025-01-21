using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Leilao, LeilaoDto>().IncludeMembers(x => x.Item);
            CreateMap<Item, LeilaoDto>();
            CreateMap<CreateLeilaoDto, Leilao>()
                .ForMember(d => d.Item, o => o.MapFrom(s => s));
            CreateMap<CreateLeilaoDto, Item>();
            CreateMap<LeilaoDto, LeilaoCreated>();
            CreateMap<Leilao, LeilaoUpdated>().IncludeMembers(a => a.Item);
            CreateMap<Item, LeilaoUpdated>();
        }
    }
}
