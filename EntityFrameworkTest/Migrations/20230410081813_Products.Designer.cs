﻿// <auto-generated />
using EntityFrameworkTest.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkTest.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230410081813_Products")]
    partial class Products
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityFrameworkTest.Models.Entities.ProductEntity", b =>
                {
                    b.Property<string>("ArticleNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(200)");

                    b.Property<decimal>("StockPrice")
                        .HasColumnType("MONEY");

                    b.HasKey("ArticleNumber");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
