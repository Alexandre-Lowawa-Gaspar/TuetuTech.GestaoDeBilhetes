﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TuetuTech.GestaoDeBilhetes.Persistence;

#nullable disable

namespace TuetuTech.GestaoDeBilhetes.Persistence.Migrations
{
    [DbContext(typeof(TuetuTechDbContext))]
    [Migration("20240909143951_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TuetuTech.GestaoDeBilhetes.Domain.Entities.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlteradoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            AlteradoPor = "",
                            CriadoPor = "",
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Concertos"
                        },
                        new
                        {
                            CategoriaId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            AlteradoPor = "",
                            CriadoPor = "",
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Musicais"
                        },
                        new
                        {
                            CategoriaId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            AlteradoPor = "",
                            CriadoPor = "",
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Shows"
                        },
                        new
                        {
                            CategoriaId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            AlteradoPor = "",
                            CriadoPor = "",
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Conferências"
                        });
                });

            modelBuilder.Entity("TuetuTech.GestaoDeBilhetes.Domain.Entities.Evento", b =>
                {
                    b.Property<Guid>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlteradoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Artista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Preco")
                        .HasColumnType("int");

                    b.HasKey("EventoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Eventoos");

                    b.HasData(
                        new
                        {
                            EventoId = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                            AlteradoPor = "",
                            Artista = "John Egbert",
                            CategoriaId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CriadoPor = "",
                            Data = new DateTime(2025, 3, 9, 15, 39, 50, 680, DateTimeKind.Local).AddTicks(6571),
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                            ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                            Nome = "John Egbert Live",
                            Preco = 65
                        },
                        new
                        {
                            EventoId = new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                            AlteradoPor = "",
                            Artista = "Michael Johnson",
                            CategoriaId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CriadoPor = "",
                            Data = new DateTime(2025, 6, 9, 15, 39, 50, 680, DateTimeKind.Local).AddTicks(6618),
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                            ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg",
                            Nome = "The State of Affairs: Michael Live!",
                            Preco = 85
                        },
                        new
                        {
                            EventoId = new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                            AlteradoPor = "",
                            Artista = "DJ 'The Mike'",
                            CategoriaId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CriadoPor = "",
                            Data = new DateTime(2025, 1, 9, 15, 39, 50, 680, DateTimeKind.Local).AddTicks(6639),
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "DJs from all over the world will compete in this epic battle for eternal fame.",
                            ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg",
                            Nome = "Clash of the DJs",
                            Preco = 85
                        },
                        new
                        {
                            EventoId = new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                            AlteradoPor = "",
                            Artista = "Manuel Santinonisi",
                            CategoriaId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CriadoPor = "",
                            Data = new DateTime(2025, 1, 9, 15, 39, 50, 680, DateTimeKind.Local).AddTicks(6657),
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Get on the hype of Spanish Guitar concerts with Manuel.",
                            ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg",
                            Nome = "Spanish guitar hits with Manuel",
                            Preco = 25
                        },
                        new
                        {
                            EventoId = new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                            AlteradoPor = "",
                            Artista = "Many",
                            CategoriaId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            CriadoPor = "",
                            Data = new DateTime(2025, 7, 9, 15, 39, 50, 680, DateTimeKind.Local).AddTicks(6676),
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "The best tech conference in the world",
                            ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg",
                            Nome = "Techorama 2021",
                            Preco = 400
                        },
                        new
                        {
                            EventoId = new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                            AlteradoPor = "",
                            Artista = "Nick Sailor",
                            CategoriaId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CriadoPor = "",
                            Data = new DateTime(2025, 5, 9, 15, 39, 50, 680, DateTimeKind.Local).AddTicks(6699),
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                            ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg",
                            Nome = "To the Moon and Back",
                            Preco = 135
                        });
                });

            modelBuilder.Entity("TuetuTech.GestaoDeBilhetes.Domain.Entities.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlteradoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Pago")
                        .HasColumnType("bit");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<Guid>("UtilizadorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                            AlteradoPor = "",
                            CriadoPor = "",
                            Data = new DateTime(2024, 9, 9, 15, 39, 50, 680, DateTimeKind.Local).AddTicks(6723),
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Pago = true,
                            Total = 400,
                            UtilizadorId = new Guid("a441eb40-9636-4ee6-be49-a66c5ec1330b")
                        },
                        new
                        {
                            Id = new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                            AlteradoPor = "",
                            CriadoPor = "",
                            Data = new DateTime(2024, 9, 9, 15, 39, 50, 680, DateTimeKind.Local).AddTicks(6746),
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Pago = true,
                            Total = 135,
                            UtilizadorId = new Guid("ac3cfaf5-34fd-4e4d-bc04-ad1083ddc340")
                        },
                        new
                        {
                            Id = new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                            AlteradoPor = "",
                            CriadoPor = "",
                            Data = new DateTime(2024, 9, 9, 15, 39, 50, 680, DateTimeKind.Local).AddTicks(6764),
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Pago = true,
                            Total = 85,
                            UtilizadorId = new Guid("d97a15fc-0d32-41c6-9ddf-62f0735c4c1c")
                        },
                        new
                        {
                            Id = new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                            AlteradoPor = "",
                            CriadoPor = "",
                            Data = new DateTime(2024, 9, 9, 15, 39, 50, 680, DateTimeKind.Local).AddTicks(6786),
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Pago = true,
                            Total = 245,
                            UtilizadorId = new Guid("4ad901be-f447-46dd-bcf7-dbe401afa203")
                        },
                        new
                        {
                            Id = new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                            AlteradoPor = "",
                            CriadoPor = "",
                            Data = new DateTime(2024, 9, 9, 15, 39, 50, 680, DateTimeKind.Local).AddTicks(6813),
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Pago = true,
                            Total = 142,
                            UtilizadorId = new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c")
                        },
                        new
                        {
                            Id = new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                            AlteradoPor = "",
                            CriadoPor = "",
                            Data = new DateTime(2024, 9, 9, 15, 39, 50, 680, DateTimeKind.Local).AddTicks(6846),
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Pago = true,
                            Total = 40,
                            UtilizadorId = new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923")
                        },
                        new
                        {
                            Id = new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                            AlteradoPor = "",
                            CriadoPor = "",
                            Data = new DateTime(2024, 9, 9, 15, 39, 50, 680, DateTimeKind.Local).AddTicks(6877),
                            DataAlteracao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataCriacao = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Pago = true,
                            Total = 116,
                            UtilizadorId = new Guid("7aeb2c01-fe8e-4b84-a5ba-330bdf950f5c")
                        });
                });

            modelBuilder.Entity("TuetuTech.GestaoDeBilhetes.Domain.Entities.Evento", b =>
                {
                    b.HasOne("TuetuTech.GestaoDeBilhetes.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Eventos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("TuetuTech.GestaoDeBilhetes.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
