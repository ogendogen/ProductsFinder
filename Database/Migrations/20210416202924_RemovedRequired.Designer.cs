﻿// <auto-generated />
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20210416202924_RemovedRequired")]
    partial class RemovedRequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Database.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Addon1")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Addon2")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Addon3")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Addon4")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Remarks")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductNumber")
                        .IsUnique();

                    b.HasIndex("Tag")
                        .IsUnique();

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
