using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using PesquisaService.Models;

namespace PesquisaService.Consumers
{
    public class LeilaoCreatedCosumer : IConsumer<LeilaoCreated>
    {
        private readonly IMapper _mapper;
        public LeilaoCreatedCosumer(IMapper mapper)
        {
         _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<LeilaoCreated> context)
        {
            Console.WriteLine("--> Consumido leilao criado: " + context.Message.Id);

            var item = _mapper.Map<Item>(context.Message);

            await item.SaveAsync();
        }
    }
}
