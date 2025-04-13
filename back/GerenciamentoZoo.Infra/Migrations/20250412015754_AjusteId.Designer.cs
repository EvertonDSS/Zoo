﻿// <auto-generated />
using System;
using GerenciamentoZoo.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GerenciamentoZoo.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250412015754_AjusteId")]
    partial class AjusteId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AnimaisEntityCuidadosEntity", b =>
                {
                    b.Property<int>("AnimaisId")
                        .HasColumnType("integer");

                    b.Property<int>("CuidadosId")
                        .HasColumnType("integer");

                    b.HasKey("AnimaisId", "CuidadosId");

                    b.HasIndex("CuidadosId");

                    b.ToTable("AnimaisEntityCuidadosEntity");
                });

            modelBuilder.Entity("GerenciamentoZoo.Domain.Entidade.AnimaisEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Habitat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaisOrigem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("GerenciamentoZoo.Domain.Entidade.CuidadosEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Frequencia")
                        .HasColumnType("integer");

                    b.Property<string>("NomeCuidado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UnidadeFrequencia")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Cuidados");
                });

            modelBuilder.Entity("AnimaisEntityCuidadosEntity", b =>
                {
                    b.HasOne("GerenciamentoZoo.Domain.Entidade.AnimaisEntity", null)
                        .WithMany()
                        .HasForeignKey("AnimaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciamentoZoo.Domain.Entidade.CuidadosEntity", null)
                        .WithMany()
                        .HasForeignKey("CuidadosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
