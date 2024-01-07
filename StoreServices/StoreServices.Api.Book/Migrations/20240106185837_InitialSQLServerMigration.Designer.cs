﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreServices.Api.Book.Persistence;

#nullable disable

namespace StoreServices.Api.Book.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20240106185837_InitialSQLServerMigration")]
    partial class InitialSQLServerMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreServices.Api.Book.Models.BookMaterial", b =>
                {
                    b.Property<Guid?>("MaterialLibraryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookAuthor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaterialLibraryId");

                    b.ToTable("BookMaterial");
                });
#pragma warning restore 612, 618
        }
    }
}
