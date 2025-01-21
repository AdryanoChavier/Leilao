using AuctionService.Consumers;
using AuctionService.Data;
using MassTransit;

namespace AuctionService.Middlewares.Configurations
{
    public static class MassTransitExtensions
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddEntityFrameworkOutbox<LeilaoDbContext>(o =>
                {
                    o.QueryDelay = TimeSpan.FromSeconds(10);
                    o.UsePostgres();
                    o.UseBusOutbox();
                });

                x.AddConsumersFromNamespaceContaining<LeilaoCreatedFaultoConsumer>();
                x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("leilao", false));

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
