﻿using ApiControleServicos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiControleServicos.Infra
{
    public class ApiDbContext : DbContext
    {
        public DbSet<UsuarioModel> Pessoas { get; set; } = null!;
        public DbSet<EmpresaModel> Empresa { get; set; } = null!;
        public DbSet<ServicoModel> Servicos { get; set; } = null!;

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
