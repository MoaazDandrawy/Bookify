using Bookify.Application.Abstractions.Behaviors;
using Bookify.Domain.Bookings;
using Microsoft.Extensions.DependencyInjection;

namespace Bookify.Application
{
    public static class DependencyInjection
    {
        //faida el method asln eny adeef kol el services bta3t el application layer f el program.cs elly haikon mawgood f el API project
        //di extension method 3lshan ykon 3andy method esmha AddApplication goa el noo3 elly esmo IServiceCollection elly mawgood asln f el C#
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);//di bt3ml wiring up between command & command handlers and Query & Query Handlers.
                // el line da (RegisterServicesFromAssembly) 3lshan ysagl kol el handlers, behaviours automatic 3lshan a2dr ast5dm IMediator.Send() masln mn 8er ma asgl kol handler manual

                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));//da hena 3lshan kol mara ykoon 3andy Command b ai noo3 request w response hai3dy 3la da
            });
            services.AddTransient<PricingService>();//3amel el noo3 Transient 3lshan kol mara ytlob el service y3ml mnha instance
            return services;
        }
    }
}
