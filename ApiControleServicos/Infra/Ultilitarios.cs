using Microsoft.EntityFrameworkCore;

namespace ApiControleServicos.Infra
{
    public static class Ultilitarios
    {
        public static string? NormalizeCnpj(string cnpj)
        {
            if (!string.IsNullOrWhiteSpace(cnpj))
                return cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            return null;
        }
        public static string? NormalizeCpf(string cpf)
        {
            if (!string.IsNullOrWhiteSpace(cpf))
                return cpf.Replace(".", "").Replace("-", "");
            return null;
        }

        public static void MigrationInicialization(this IApplicationBuilder app)
        {
            try
            {
                using var serviceScope = app.ApplicationServices.CreateScope();
                var serviceDb = serviceScope.ServiceProvider.GetService<ApiDbContext>();
                serviceDb?.Database.Migrate();
            }
            catch
            {
                return;
            }
        }
    }
}
