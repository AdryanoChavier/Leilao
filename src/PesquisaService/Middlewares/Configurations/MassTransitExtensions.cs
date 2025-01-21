using MassTransit;
using PesquisaService.Data.Consumers;

namespace PesquisaService.Middlewares.Configurations
{
    public static class MassTransitExtensions
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumersFromNamespaceContaining<LeilaoCreatedCosumer>();

                x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("pesquisa", false));

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("pesquisa-leilao-created", e =>
                    {
                        e.UseMessageRetry(r => r.Interval(5, 5));

                        e.ConfigureConsumer<LeilaoCreatedCosumer>(context);
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
            return services;
        }
    }
}