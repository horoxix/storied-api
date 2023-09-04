﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(StoriedDbContext))]
    partial class StoriedDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("Data.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EventDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventTypeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Data.Entities.EventType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EventTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a2b38516-7b1d-4d1b-9ec5-8aabbd18233f"),
                            Name = "Birth"
                        },
                        new
                        {
                            Id = new Guid("60d2da2b-0e59-44ff-a401-6fe440404ab4"),
                            Name = "Death"
                        },
                        new
                        {
                            Id = new Guid("e75cfd1a-59f3-461b-9a02-718146571a36"),
                            Name = "Marriage"
                        });
                });

            modelBuilder.Entity("Data.Entities.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("56c6c2b9-e619-435e-b899-2d19d03c6def"),
                            Name = "Male"
                        },
                        new
                        {
                            Id = new Guid("0f48d9a9-85ee-42ba-b251-044c1f29ebaa"),
                            Name = "Female"
                        },
                        new
                        {
                            Id = new Guid("2e73a543-fad7-4703-a838-dda0a79fb5bd"),
                            Name = "Non-binary"
                        },
                        new
                        {
                            Id = new Guid("cf0a5f5d-2cb6-4741-a15b-ad898aafc9c9"),
                            Name = "Transgender"
                        },
                        new
                        {
                            Id = new Guid("586c5311-adf7-4d98-bdae-b1cbd3beee50"),
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("Data.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4aca1a49-5a43-4e7a-993a-239e5c5c91c3"),
                            Name = "Orem"
                        },
                        new
                        {
                            Id = new Guid("6023f999-51db-4ab2-8c2d-724564591ef2"),
                            Name = "Provo"
                        },
                        new
                        {
                            Id = new Guid("b59145bb-1ad0-48c8-92bd-5805e195bb57"),
                            Name = "New York"
                        },
                        new
                        {
                            Id = new Guid("ae8a5fb0-8ffa-4a50-a43e-f36659801ae4"),
                            Name = "San Francisco"
                        },
                        new
                        {
                            Id = new Guid("cf6c3a0e-cbe8-480e-923a-3a7b8944562e"),
                            Name = "London"
                        },
                        new
                        {
                            Id = new Guid("05bbc52c-0067-4d2c-849b-0ee40c192823"),
                            Name = "Tokyo"
                        });
                });

            modelBuilder.Entity("Data.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("BirthEventId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DeathEventId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("TEXT");

                    b.Property<string>("GivenName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BirthEventId");

                    b.HasIndex("DeathEventId");

                    b.HasIndex("GenderId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Data.Entities.Event", b =>
                {
                    b.HasOne("Data.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Data.Entities.Person", b =>
                {
                    b.HasOne("Data.Entities.Event", "BirthEvent")
                        .WithMany()
                        .HasForeignKey("BirthEventId");

                    b.HasOne("Data.Entities.Event", "DeathEvent")
                        .WithMany()
                        .HasForeignKey("DeathEventId");

                    b.HasOne("Data.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BirthEvent");

                    b.Navigation("DeathEvent");

                    b.Navigation("Gender");
                });
#pragma warning restore 612, 618
        }
    }
}
