﻿// <auto-generated />
using CountyRP.Forum.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CountyRP.Forum.Infrastructure.Migrations.Moderator
{
    [DbContext(typeof(ModeratorContext))]
    [Migration("20210209173048_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CountyRP.Forum.Domain.Models.Moderator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CreatePosts")
                        .HasColumnType("bit");

                    b.Property<bool>("CreateTopics")
                        .HasColumnType("bit");

                    b.Property<bool>("DeletePosts")
                        .HasColumnType("bit");

                    b.Property<bool>("DeleteTopics")
                        .HasColumnType("bit");

                    b.Property<bool>("EditPosts")
                        .HasColumnType("bit");

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<int>("EntityType")
                        .HasColumnType("int");

                    b.Property<int>("ForumId")
                        .HasColumnType("int");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Moderators");
                });
#pragma warning restore 612, 618
        }
    }
}
