using Microsoft.EntityFrameworkCore;
using TrabajadoresPrueba.Data.Context;

namespace TrabajadoresPrueba
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<PruebaContext>(opt =>
                {
                    opt.UseSqlServer(configuration.GetConnectionString("PruebaConnection"));
                });
            return services;
        }
    }
}
