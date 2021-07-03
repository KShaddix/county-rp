﻿// <auto-generated />
using System;
using CountyRP.Services.Site.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CountyRP.Services.Site.Migrations
{
    [DbContext(typeof(SiteDbContext))]
    [Migration("20210702204238_AddSupportRequest")]
    partial class AddSupportRequest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CountyRP.Services.Site.Entities.BanDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("FinishDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("IP")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Reason")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTimeOffset>("StartDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Bans");
                });

            modelBuilder.Entity("CountyRP.Services.Site.Entities.GroupDao", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<bool>("AdminPanel")
                        .HasColumnType("bit");

                    b.Property<bool>("ChangeGroup")
                        .HasColumnType("bit");

                    b.Property<bool>("ChangeLogin")
                        .HasColumnType("bit");

                    b.Property<string>("Color")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<bool>("CreateUsers")
                        .HasColumnType("bit");

                    b.Property<bool>("DeleteUsers")
                        .HasColumnType("bit");

                    b.Property<bool>("EditGroups")
                        .HasColumnType("bit");

                    b.Property<int>("MaxBan")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("SeeLogs")
                        .HasColumnType("bit");

                    b.Property<string>("_BanGroupIds")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BanGroupIds");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("CountyRP.Services.Site.Entities.SupportRequestMessageDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("EditionDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SupportRequestMessages");
                });

            modelBuilder.Entity("CountyRP.Services.Site.Entities.SupportRequestTopicDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("CreatorUserId")
                        .HasColumnType("int");

                    b.Property<int?>("RefUserId")
                        .HasColumnType("int");

                    b.Property<bool>("ShowRefUser")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SupportRequestTopics");
                });

            modelBuilder.Entity("CountyRP.Services.Site.Entities.UserDao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ForumUserId")
                        .HasColumnType("int");

                    b.Property<string>("GroupId")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Login")
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Password")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
