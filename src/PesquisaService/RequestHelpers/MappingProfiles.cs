using AutoMapper;
using Contracts;
using PesquisaService.Models;

namespace PesquisaService.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<LeilaoCreated, Item>();

        }
    }
}
