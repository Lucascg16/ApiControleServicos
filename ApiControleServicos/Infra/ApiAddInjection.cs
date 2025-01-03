﻿using ApiControleServicos.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ApiControleServicos.Infra
{
    public static class ApiAddInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new Exception("A string de conexão não foi encontrada, favor verificar o appsettings.");
            connectionString = UpdateConnectionPassword(connectionString, config);

            services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(connectionString));
            

            //Services
            services.AddScoped<IUsuarioServices, UsuarioServices>();
			services.AddScoped<IEmpresaServices, EmpresaServices>();
            services.AddScoped<IServicoServices, ServicoServices>();
            services.AddScoped<ITokenServices, TokenServices>();
            services.AddSingleton<CriptoServices>();

            //Respositores
            services.AddScoped<IUsuarioRepository, UsuarioRespository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IServicoRespository, ServicoRepository>();


            return services;
        }

        public static string UpdateConnectionPassword(string connectionString, IConfiguration config)
        {
            var builder = new DbConnectionStringBuilder
            {
                ConnectionString = connectionString
            };

            var decriptyPass = CriptoServices.Descriptografar(builder["Password"].ToString() ?? "", config);
            builder["Password"] = decriptyPass;

            return builder.ConnectionString;
        }
    }
}
