﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using S3Inovate.Core.Context;

namespace S3Inovate.Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210213175341_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("S3Inovate.Core.Models.Building", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("Location", "Name")
                        .IsUnique()
                        .HasFilter("[Location] IS NOT NULL");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("S3Inovate.Core.Models.DataField", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("DataFields");
                });

            modelBuilder.Entity("S3Inovate.Core.Models.Object", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("S3Inovate.Core.Models.Reading", b =>
                {
                    b.Property<short>("BuildingId")
                        .HasColumnType("smallint");

                    b.Property<byte>("ObjectId")
                        .HasColumnType("tinyint");

                    b.Property<byte>("DataFieldId")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BuildingId", "ObjectId", "DataFieldId");

                    b.HasIndex("DataFieldId");

                    b.HasIndex("ObjectId");

                    b.HasIndex("Timestamp");

                    b.ToTable("Readings");
                });

            modelBuilder.Entity("S3Inovate.Core.Models.Reading", b =>
                {
                    b.HasOne("S3Inovate.Core.Models.Building", "Building")
                        .WithMany("Readings")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("S3Inovate.Core.Models.DataField", "DataField")
                        .WithMany("Readings")
                        .HasForeignKey("DataFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("S3Inovate.Core.Models.Object", "Object")
                        .WithMany("Readings")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("DataField");

                    b.Navigation("Object");
                });

            modelBuilder.Entity("S3Inovate.Core.Models.Building", b =>
                {
                    b.Navigation("Readings");
                });

            modelBuilder.Entity("S3Inovate.Core.Models.DataField", b =>
                {
                    b.Navigation("Readings");
                });

            modelBuilder.Entity("S3Inovate.Core.Models.Object", b =>
                {
                    b.Navigation("Readings");
                });
#pragma warning restore 612, 618
        }
    }
}
