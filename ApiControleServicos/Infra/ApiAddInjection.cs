using Microsoft.EntityFrameworkCore;

namespace ApiControleServicos.Infra
{
    public static class ApiAddInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(connectionString));

            //Services

            //Respositores

            return services;
        }
    }
}
