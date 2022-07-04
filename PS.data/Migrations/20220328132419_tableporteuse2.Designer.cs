﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PS.data;

namespace PS.data.Migrations
{
    [DbContext(typeof(PSContext))]
    [Migration("20220328132419_tableporteuse2")]
    partial class tableporteuse2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PS.Domain.Achat", b =>
                {
                    b.Property<int>("ClientFK")
                        .HasColumnType("int");

                    b.Property<int>("ProductFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAchat")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ClientFK", "ProductFK", "DateAchat");

                    b.HasIndex("ProductFK");

                    b.ToTable("Achats");
                });

            modelBuilder.Entity("PS.Domain.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("myCategories");
                });

            modelBuilder.Entity("PS.Domain.Client", b =>
                {
                    b.Property<int>("Cin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cin");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("PS.Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateProd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryFK");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PS.Domain.Provider", b =>
                {
                    b.Property<int>("ProviderKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProviderKey");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("ProductProvider", b =>
                {
                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProvidersProviderKey")
                        .HasColumnType("int");

                    b.HasKey("ProductsProductId", "ProvidersProviderKey");

                    b.HasIndex("ProvidersProviderKey");

                    b.ToTable("Providing");
                });

            modelBuilder.Entity("PS.Domain.Biological", b =>
                {
                    b.HasBaseType("PS.Domain.Product");

                    b.Property<string>("Herbs")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Biological");
                });

            modelBuilder.Entity("PS.Domain.Chemical", b =>
                {
                    b.HasBaseType("PS.Domain.Product");

                    b.Property<string>("LabName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Chemical");
                });

            modelBuilder.Entity("PS.Domain.Achat", b =>
                {
                    b.HasOne("PS.Domain.Client", "Client")
                        .WithMany("Achats")
                        .HasForeignKey("ClientFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PS.Domain.Product", "Product")
                        .WithMany("Achats")
                        .HasForeignKey("ProductFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PS.Domain.Product", b =>
                {
                    b.HasOne("PS.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProductProvider", b =>
                {
                    b.HasOne("PS.Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PS.Domain.Provider", null)
                        .WithMany()
                        .HasForeignKey("ProvidersProviderKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PS.Domain.Biological", b =>
                {
                    b.HasOne("PS.Domain.Product", null)
                        .WithOne()
                        .HasForeignKey("PS.Domain.Biological", "ProductId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PS.Domain.Chemical", b =>
                {
                    b.HasOne("PS.Domain.Product", null)
                        .WithOne()
                        .HasForeignKey("PS.Domain.Chemical", "ProductId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.OwnsOne("PS.Domain.Adresse", "Adresse", b1 =>
                        {
                            b1.Property<int>("ChemicalProductId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("StreetAdress")
                                .HasColumnType("int");

                            b1.HasKey("ChemicalProductId");

                            b1.ToTable("Chemical");

                            b1.WithOwner()
                                .HasForeignKey("ChemicalProductId");
                        });

                    b.Navigation("Adresse");
                });

            modelBuilder.Entity("PS.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PS.Domain.Client", b =>
                {
                    b.Navigation("Achats");
                });

            modelBuilder.Entity("PS.Domain.Product", b =>
                {
                    b.Navigation("Achats");
                });
#pragma warning restore 612, 618
        }
    }
}
