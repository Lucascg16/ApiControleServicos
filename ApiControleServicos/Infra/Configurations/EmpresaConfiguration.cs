using ApiControleServicos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControleServicos.Infra.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<EmpresaModel>
    {
        public void Configure(EntityTypeBuilder<EmpresaModel> builder)
        {
            builder.ToTable("Empresa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("nvarchar(450)");

            builder.Property(x => x.Cnpj)
                .HasColumnName("Cnpj")
                .HasColumnType("nvarchar(14)");

            builder.Property(x => x.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("nvarchar(11)");

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
