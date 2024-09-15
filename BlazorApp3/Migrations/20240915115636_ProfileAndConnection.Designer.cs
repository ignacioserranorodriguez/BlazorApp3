﻿// <auto-generated />
using System;
using BlazorApp3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorApp3.Migrations
{
    [DbContext(typeof(BlazorApp3Context))]
    [Migration("20240915115636_ProfileAndConnection")]
    partial class ProfileAndConnection
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Connection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("TransmitterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("TransmitterId");

                    b.ToTable("Connection");
                });

            modelBuilder.Entity("Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("Ip")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Device");

                    b.HasDiscriminator().HasValue("Device");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("BlazorApp3.Models.Receiver", b =>
                {
                    b.HasBaseType("Device");

                    b.Property<int?>("TransmitterId")
                        .HasColumnType("int");

                    b.HasIndex("TransmitterId");

                    b.HasDiscriminator().HasValue("Receiver");
                });

            modelBuilder.Entity("BlazorApp3.Models.Transmitter", b =>
                {
                    b.HasBaseType("Device");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Transmitter");
                });

            modelBuilder.Entity("Connection", b =>
                {
                    b.HasOne("Profile", "Profile")
                        .WithMany("Connections")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorApp3.Models.Receiver", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorApp3.Models.Transmitter", "Transmitter")
                        .WithMany()
                        .HasForeignKey("TransmitterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("Receiver");

                    b.Navigation("Transmitter");
                });

            modelBuilder.Entity("BlazorApp3.Models.Receiver", b =>
                {
                    b.HasOne("BlazorApp3.Models.Transmitter", "Transmitter")
                        .WithMany()
                        .HasForeignKey("TransmitterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Transmitter");
                });

            modelBuilder.Entity("Profile", b =>
                {
                    b.Navigation("Connections");
                });
#pragma warning restore 612, 618
        }
    }
}
