﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SOS.Infrastructure.Database;

#nullable disable

namespace SOS.Infrastructure.Migrations
{
    [DbContext(typeof(SOSContext))]
    [Migration("20230418101835_postreSQL")]
    partial class postreSQL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SOS.Core.Domain.CoordinatesSpan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("LatitudeEnd")
                        .HasColumnType("double precision");

                    b.Property<double>("LatitudeStart")
                        .HasColumnType("double precision");

                    b.Property<double>("LongitudeEnd")
                        .HasColumnType("double precision");

                    b.Property<double>("LongitudeStart")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("CoordinatesSpan");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CoordinatesSpan");
                });

            modelBuilder.Entity("SOS.Core.Domain.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TeamAreaId")
                        .HasColumnType("integer");

                    b.Property<int>("VehicleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeamAreaId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Team");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Team");
                });

            modelBuilder.Entity("SOS.Core.Domain.TeamMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMember");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TeamMember");
                });

            modelBuilder.Entity("SOS.Core.Domain.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Seats")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Vehicle");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Vehicle");
                });

            modelBuilder.Entity("SOS.Infrastructure.DTO.MissionDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Mission");
                });

            modelBuilder.Entity("SOS.Infrastructure.DTO.CoordinatesSpanDTO", b =>
                {
                    b.HasBaseType("SOS.Core.Domain.CoordinatesSpan");

                    b.HasDiscriminator().HasValue("CoordinatesSpanDTO");
                });

            modelBuilder.Entity("SOS.Infrastructure.DTO.TeamDTO", b =>
                {
                    b.HasBaseType("SOS.Core.Domain.Team");

                    b.HasDiscriminator().HasValue("TeamDTO");
                });

            modelBuilder.Entity("SOS.Infrastructure.DTO.TeamMemberDTO", b =>
                {
                    b.HasBaseType("SOS.Core.Domain.TeamMember");

                    b.HasDiscriminator().HasValue("TeamMemberDTO");
                });

            modelBuilder.Entity("SOS.Infrastructure.DTO.VehicleDTO", b =>
                {
                    b.HasBaseType("SOS.Core.Domain.Vehicle");

                    b.HasDiscriminator().HasValue("VehicleDTO");
                });

            modelBuilder.Entity("SOS.Core.Domain.Team", b =>
                {
                    b.HasOne("SOS.Core.Domain.CoordinatesSpan", "TeamArea")
                        .WithMany()
                        .HasForeignKey("TeamAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SOS.Core.Domain.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeamArea");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("SOS.Core.Domain.TeamMember", b =>
                {
                    b.HasOne("SOS.Core.Domain.Team", null)
                        .WithMany("Members")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("SOS.Infrastructure.DTO.MissionDTO", b =>
                {
                    b.HasOne("SOS.Core.Domain.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("SOS.Core.Domain.Team", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}