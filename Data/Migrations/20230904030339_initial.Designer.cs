﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(StoriedDbContext))]
    [Migration("20230904030339_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("9dcf30df-ad5b-4a61-8442-fef9b90f2ffa"),
                            Name = "Birth"
                        },
                        new
                        {
                            Id = new Guid("4549711d-1cf7-4bb0-ae78-aca5bf2852c6"),
                            Name = "Death"
                        },
                        new
                        {
                            Id = new Guid("a8186a06-38a7-4de5-aa2f-80688ccf61fd"),
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
                            Id = new Guid("40e513a1-1fbb-41c8-9c9b-8d6bb6d9531a"),
                            Name = "Male"
                        },
                        new
                        {
                            Id = new Guid("b6b9bb29-7a78-42a4-8d3a-2e3e36f29ceb"),
                            Name = "Female"
                        },
                        new
                        {
                            Id = new Guid("872534e8-80c0-421f-b84f-834a0c29bb42"),
                            Name = "Non-binary"
                        },
                        new
                        {
                            Id = new Guid("0ab267f7-28dc-47ad-8c16-62f4fd46a210"),
                            Name = "Transgender"
                        },
                        new
                        {
                            Id = new Guid("ecde8447-59fa-478f-b870-13a329ecf032"),
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
                            Id = new Guid("500c6a87-40c7-4041-85ae-c2334b801391"),
                            Name = "Orem"
                        },
                        new
                        {
                            Id = new Guid("7f073329-04b4-4c27-b925-b2c81ef244ef"),
                            Name = "Provo"
                        },
                        new
                        {
                            Id = new Guid("d56b6370-7058-4f19-bcd4-729471953f89"),
                            Name = "New York"
                        },
                        new
                        {
                            Id = new Guid("0613ca2c-692a-41a4-bcc9-95cc271ed295"),
                            Name = "San Francisco"
                        },
                        new
                        {
                            Id = new Guid("bc9f8025-6cbc-48e4-a75e-cec46efd1a33"),
                            Name = "London"
                        },
                        new
                        {
                            Id = new Guid("89f082c5-2092-4e3c-839e-04d5024a6db4"),
                            Name = "Tokyo"
                        });
                });

            modelBuilder.Entity("Data.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Data.Entities.PersonVersion", b =>
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

                    b.Property<Guid>("PersonId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("VersionDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BirthEventId");

                    b.HasIndex("DeathEventId");

                    b.HasIndex("GenderId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonVersions");
                });

            modelBuilder.Entity("Data.Entities.Event", b =>
                {
                    b.HasOne("Data.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Data.Entities.PersonVersion", b =>
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

                    b.HasOne("Data.Entities.Person", "Person")
                        .WithMany("Versions")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BirthEvent");

                    b.Navigation("DeathEvent");

                    b.Navigation("Gender");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Data.Entities.Person", b =>
                {
                    b.Navigation("Versions");
                });
#pragma warning restore 612, 618
        }
    }
}
