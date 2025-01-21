using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using PesquisaService.Models;

namespace PesquisaService.Consumers
{
    public class LeilaoUpdatedConsumer : IConsumer<LeilaoUpdated>
    {
        private readonly IMapper _mapper;

        public LeilaoUpdatedConsumer (IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<LeilaoUpdated> context)
        {
            Console.WriteLine("--> Consuming auction updated: " + context.Message.Id);

            var Item = _mapper.Map<Item>(context.Message);

            var result = await DB.Update<Item>()
                .Match(a => a.ID == context.Message.Id)
                .ModifyOnly(x => new
                {
                    x.Cor,
                    x.Marca,
                    x.Modelo,
                    x.Ano,
                    x.Quilometragem
                },Item)
                .ExecuteAsync();

            if(!result.IsAcknowledged) throw new MessageException(typeof(LeilaoUpdated),"Problema no Updade MongoDB");
            
        }
    }
}
