﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiteDeQuadrinhos.Data;

#nullable disable

namespace SiteDeQuadrinhos.Migrations
{
    [DbContext(typeof(SiteDeQuadrinhosDBContex))]
    [Migration("20231014171047_Teste2")]
    partial class Teste2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SiteDeQuadrinhos.Models.QuadrinhoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<byte[]>("Capa")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("Capitulo")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("TagPrincipal")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("usuarioModelId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("usuarioModelId");

                    b.ToTable("Quadrinhos");
                });

            modelBuilder.Entity("SiteDeQuadrinhos.Models.UsuarioModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NomeDeUsuario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SiteDeQuadrinhos.Models.QuadrinhoModel", b =>
                {
                    b.HasOne("SiteDeQuadrinhos.Models.UsuarioModel", "usuarioModel")
                        .WithMany()
                        .HasForeignKey("usuarioModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuarioModel");
                });
#pragma warning restore 612, 618
        }
    }
}