﻿using ApiControleServicos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControleServicos.Infra.Configurations
{
    public sealed class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("nvarchar(450)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("nvarchar(max)");

            builder.HasOne<EmpresaModel>()
                .WithMany()
                .HasForeignKey(x => x.EmpresaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Excluido)
                .HasColumnName("Excluido")
                .HasDefaultValue(false)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.DataAtualizacao)
               .HasColumnName("DataDeAtualizacao")
               .HasColumnType("dateTime")
               .IsRequired();

            builder.Property(x => x.DataCriacao)
                .HasColumnName("DataDeCriacao")
                .HasColumnType("dateTime")
                .IsRequired();

        }
    }
}
