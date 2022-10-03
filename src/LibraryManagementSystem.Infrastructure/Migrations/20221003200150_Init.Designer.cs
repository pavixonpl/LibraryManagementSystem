﻿// <auto-generated />
using System;
using LibraryManagementSystem.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221003200150_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibraryManagementSystem.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LibraryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LibraryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f0811a4e-628a-4e9b-98da-9e5523f1a6d3"),
                            LibraryId = new Guid("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb"),
                            Title = "Some book 1"
                        },
                        new
                        {
                            Id = new Guid("73e03a55-d760-4415-aeb5-743e9dd79f20"),
                            LibraryId = new Guid("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb"),
                            Title = "Some book 2"
                        },
                        new
                        {
                            Id = new Guid("2ce20daa-4315-4a1d-b555-5a1d337de520"),
                            LibraryId = new Guid("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb"),
                            Title = "Some book 3"
                        },
                        new
                        {
                            Id = new Guid("49b1ba68-e260-4a7e-9e3f-da55f79c90f4"),
                            LibraryId = new Guid("adea7009-34c0-4aa4-8284-d76757d2d5f2"),
                            Title = "Some book 4"
                        },
                        new
                        {
                            Id = new Guid("dd582fe1-1b4b-4c10-910e-e41c8b78d30c"),
                            LibraryId = new Guid("adea7009-34c0-4aa4-8284-d76757d2d5f2"),
                            Title = "Some book 5"
                        },
                        new
                        {
                            Id = new Guid("ac64849c-a923-4346-a2ad-6fa9d19cd2be"),
                            LibraryId = new Guid("adea7009-34c0-4aa4-8284-d76757d2d5f2"),
                            Title = "Other some book 1"
                        },
                        new
                        {
                            Id = new Guid("3efa03c9-c526-46ed-9808-835fd44a646e"),
                            LibraryId = new Guid("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea"),
                            Title = "Other some book 2"
                        },
                        new
                        {
                            Id = new Guid("73eddf44-edc3-441f-8366-27cdf6595bc7"),
                            LibraryId = new Guid("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea"),
                            Title = "Other some book 3"
                        },
                        new
                        {
                            Id = new Guid("4f47a31e-3a6b-4b61-8061-95c6619ae4f6"),
                            LibraryId = new Guid("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea"),
                            Title = "Other some book 4"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Entities.Library", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Libraries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb"),
                            Name = "Library one"
                        },
                        new
                        {
                            Id = new Guid("adea7009-34c0-4aa4-8284-d76757d2d5f2"),
                            Name = "Library two"
                        },
                        new
                        {
                            Id = new Guid("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea"),
                            Name = "Library three"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Entities.Book", b =>
                {
                    b.HasOne("LibraryManagementSystem.Domain.Entities.Library", "Library")
                        .WithMany("Books")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Library");
                });

            modelBuilder.Entity("LibraryManagementSystem.Domain.Entities.Library", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
