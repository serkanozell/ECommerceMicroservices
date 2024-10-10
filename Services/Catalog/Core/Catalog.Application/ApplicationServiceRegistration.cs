using BuildingBlocks.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            // burada milan jovanovicin servisleri de böldüğü metotlar vardı bi örnekte. onu incele daha temiz bişey yapılabilir gibi
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(assemblies: assembly);
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
                cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddValidatorsFromAssembly(assembly: assembly);

            return services;
        }
    }
}