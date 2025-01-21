using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using MongoDB.Entities;
using PesquisaService.Models;

namespace PesquisaService.Data.Consumers
{
    public class LeilaoDeletedConsumer : IConsumer<LeilaoDeleted>
    {
        public async Task Consume(ConsumeContext<LeilaoDeleted> context)
        {
            Console.WriteLine("--> Consuming LeilaoDelted: " + context.Message.Id);

            var result = await DB.DeleteAsync<Item>(context.Message.Id);

            if (!result.IsAcknowledged) throw new MessageException(typeof(LeilaoDeleted), "Problema deletando leilao");
        }
    }
}
