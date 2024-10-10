﻿// <auto-generated />
using System;
using ApiControleServicos.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiControleServicos.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20241010153421_AdicionarIdVisualParaUrl")]
    partial class AdicionarIdVisualParaUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiControleServicos.Domain.Models.EmpresaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("Cnpj");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("Cpf");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("dateTime")
                        .HasColumnName("DataDeAtualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("dateTime")
                        .HasColumnName("DataDeCriacao");

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("Excluido");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Empresa", (string)null);
                });

            modelBuilder.Entity("ApiControleServicos.Domain.Models.ServicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("Custos")
                        .HasColumnType("float");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("dateTime")
                        .HasColumnName("DataDeAtualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("dateTime")
                        .HasColumnName("DataDeCriacao");

                    b.Property<DateTime?>("DataFinalizado")
                        .HasColumnType("dateTime")
                        .HasColumnName("DataFinalizado");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(Max)")
                        .HasColumnName("Descricao");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("Excluido");

                    b.Property<double?>("LucroLiquido")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Nome");

                    b.Property<double?>("OrcamentoInicial")
                        .HasColumnType("float");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<double?>("ValorFaturado")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("servico", (string)null);
                });

            modelBuilder.Entity("ApiControleServicos.Domain.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("dateTime")
                        .HasColumnName("DataDeAtualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("dateTime")
                        .HasColumnName("DataDeCriacao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("Excluido");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("none");

                    b.Property<string>("VId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("VisualId");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("ApiControleServicos.Domain.Models.ServicoModel", b =>
                {
                    b.HasOne("ApiControleServicos.Domain.Models.EmpresaModel", null)
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ApiControleServicos.Domain.Models.UsuarioModel", null)
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiControleServicos.Domain.Models.UsuarioModel", b =>
                {
                    b.HasOne("ApiControleServicos.Domain.Models.EmpresaModel", null)
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
