using AutoMapper;
using Contracts;
using PesquisaService.Models;

namespace PesquisaService.Middlewares.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<LeilaoCreated, Item>();
            CreateMap<LeilaoUpdated, Item>();

        }
    }
}
