﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TostiBackEnd.Context;

namespace TostiBackEnd.Migrations
{
    [DbContext(typeof(TostiDBContext))]
    partial class TostiDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TostiBackEnd.Entity.TostiEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brood")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Calorieen");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Vulling")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Tostis");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brood = "Witbrood",
                            Calorieen = 400,
                            Naam = "HamKaas",
                            Vulling = "Ham en Kaas"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
