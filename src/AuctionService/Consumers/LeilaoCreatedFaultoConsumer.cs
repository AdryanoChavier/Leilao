using Contracts;
using MassTransit;

namespace AuctionService.Consumers
{
    public class LeilaoCreatedFaultoConsumer : IConsumer<Fault<LeilaoCreated>>
    {
        public async Task Consume(ConsumeContext<Fault<LeilaoCreated>> context)
        {
            Console.WriteLine("--> Consuming faulty creation");

            var exception = context.Message.Exceptions.First();

            if(exception.ExceptionType == "System.ArgumentException")
            {
                context.Message.Message.Marca = "FooBar";
                await context.Publish(context.Message.Message);
            }
            else
            {
                Console.WriteLine("Not an argument exception - update erro daschboard somewhere");
            }

        }
    }
}
