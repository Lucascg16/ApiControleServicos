using ApiControleServicos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControleServicos.Infra.Configurations
{
    public class ServicoConfiguration : IEntityTypeConfiguration<ServicoModel>
    {
        public void Configure(EntityTypeBuilder<ServicoModel> builder)
        {
            builder.ToTable("servico");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("nvarchar(450)");

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("nvarchar(Max)");

            builder.Property(x => x.Orcamento);
            builder.Property(x => x.ValorFaturado);
            builder.Property(x => x.LucroLiquido);

            builder.Property(x => x.DataFinalizado)
                .HasColumnName("DataFinalizado")
                .HasColumnType("dateTime");

            builder.HasOne<UsuarioModel>()
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<EmpresaModel>()
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.EmpresaId)
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
