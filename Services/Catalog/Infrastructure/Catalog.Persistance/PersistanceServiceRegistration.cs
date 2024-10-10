using Catalog.Persistance.Interceptors;
using Catalog.Persistance.Repositories;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Another usage for interceptors
            //services.AddScoped<AuditableEntityInterceptor>();
            //services.AddScoped<SoftDeleteInterceptor>();
            #endregion


            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                //options.AddInterceptors(sp.GetRequiredService<AuditableEntityInterceptor>());
                //options.AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>());
                options.AddInterceptors(sp.GetRequiredService<ISaveChangesInterceptor>());
                options.UseSqlServer(configuration.GetConnectionString("SqlConn"));
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}