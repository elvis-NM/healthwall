﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using secrets.Models;

namespace secrets.Migrations
{
    [DbContext(typeof(secretsContext))]
    [Migration("20190623082250_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("secrets.Models.Like", b =>
                {
                    b.Property<int>("LikedId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SecretId");

                    b.Property<int>("UserId");

                    b.HasKey("LikedId");

                    b.HasIndex("SecretId");

                    b.HasIndex("UserId");

                    b.ToTable("likes");
                });

            modelBuilder.Entity("secrets.Models.Secret", b =>
                {
                    b.Property<int>("SecretId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("SecretId");

                    b.HasIndex("UserId");

                    b.ToTable("secrets");
                });

            modelBuilder.Entity("secrets.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(45)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(45)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(45)");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("secrets.Models.Like", b =>
                {
                    b.HasOne("secrets.Models.Secret", "LikedSecret")
                        .WithMany("Likes")
                        .HasForeignKey("SecretId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("secrets.Models.User", "Liker")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("secrets.Models.Secret", b =>
                {
                    b.HasOne("secrets.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
