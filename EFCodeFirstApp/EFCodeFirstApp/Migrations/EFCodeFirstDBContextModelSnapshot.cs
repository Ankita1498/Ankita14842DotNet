// <auto-generated />
using System;
using EFCodeFirstApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCodeFirstApp.Migrations
{
    [DbContext(typeof(EFCodeFirstDBContext))]
    partial class EFCodeFirstDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCodeFirstApp.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("varchar(20)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("EFCodeFirstApp.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("CatgeoryId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric(10,2)");

                    b.Property<string>("ProductName")
                        .HasColumnType("varchar(20)");

                    b.HasKey("ProductId");

                    b.HasIndex("CatgeoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EFCodeFirstApp.Product", b =>
                {
                    b.HasOne("EFCodeFirstApp.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CatgeoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EFCodeFirstApp.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
