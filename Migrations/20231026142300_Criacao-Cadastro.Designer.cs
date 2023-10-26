﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoGame.Models;

#nullable disable

namespace ProjetoGame.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20231026142300_Criacao-Cadastro")]
    partial class CriacaoCadastro
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetoGame.Models.Cadastro", b =>
                {
                    b.Property<int>("CadastroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CadastroId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CadastroId"));

                    b.Property<string>("CadastroName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CadastroCategoria");

                    b.Property<string>("CadastroNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CadastroNome");

                    b.HasKey("CadastroId");

                    b.ToTable("Cadastro");
                });
#pragma warning restore 612, 618
        }
    }
}