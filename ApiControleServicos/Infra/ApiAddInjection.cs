using ApiControleServicos.Domain;
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
            services.AddScoped<IUsuarioServices, UsuarioServices>();
			services.AddScoped<IEmpresaServices, EmpresaServices>();
            services.AddScoped<IServicoServices, ServicoServices>();
            services.AddScoped<ITokenServices, TokenServices>();
            services.AddScoped<ICriptoServices, CriptoServices>();

			//Respositores
			services.AddScoped<IUsuarioRepository, UsuarioRespository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IServicoRespository, ServicoRepository>();


            return services;
        }

        public static void MigrationInicialization(this IApplicationBuilder app)
        {
			using var serviceScope = app.ApplicationServices.CreateScope();
			var serviceDb = serviceScope.ServiceProvider.GetService<ApiDbContext>();
			serviceDb.Database.Migrate();
		}
    }
}
