﻿// <auto-generated />
using System;
using DSU21.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DSU21.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220119121617_captain")]
    partial class captain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            modelBuilder.Entity("DSU21.Models.Pirate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ShipId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ShipId");

                    b.ToTable("Pirates");
                });

            modelBuilder.Entity("DSU21.Models.Ship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("PirateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PirateId");

                    b.ToTable("Ships");
                });

            modelBuilder.Entity("DSU21.Models.Pirate", b =>
                {
                    b.HasOne("DSU21.Models.Ship", null)
                        .WithMany("Pirates")
                        .HasForeignKey("ShipId");
                });

            modelBuilder.Entity("DSU21.Models.Ship", b =>
                {
                    b.HasOne("DSU21.Models.Pirate", "Captain")
                        .WithMany()
                        .HasForeignKey("PirateId");

                    b.Navigation("Captain");
                });

            modelBuilder.Entity("DSU21.Models.Ship", b =>
                {
                    b.Navigation("Pirates");
                });
#pragma warning restore 612, 618
        }
    }
}
