﻿// <auto-generated />
using System;
using CountyRP.WebAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CountyRP.WebAPI.Migrations.Player
{
    [DbContext(typeof(PlayerContext))]
    partial class PlayerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CountyRP.DAO.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminLevelId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CommonInventoryId")
                        .HasColumnType("int");

                    b.Property<string>("FactionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Leader")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("PocketsInventoryId")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("_Position")
                        .HasColumnName("Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("CountyRP.DAO.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
