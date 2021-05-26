﻿// <auto-generated />
using EFCodeFirstAssignment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCodeFirstAssignment.Migrations
{
    [DbContext(typeof(BookDBContext))]
    [Migration("20210520052821_01_createtables")]
    partial class _01_createtables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCodeFirstAssignment.Book", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("BookName")
                        .HasColumnType("varchar(20)");

                    b.HasKey("BookId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("EFCodeFirstAssignment.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("MemberName")
                        .HasColumnType("varchar(20)");

                    b.HasKey("MemberId");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("EFCodeFirstAssignment.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewText")
                        .HasColumnType("varchar(50)");

                    b.HasKey("ReviewId");

                    b.ToTable("Review");
                });
#pragma warning restore 612, 618
        }
    }
}
