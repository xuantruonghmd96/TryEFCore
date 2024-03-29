﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Try_LazyLoad_EagerLoad.Models;

namespace Try_LazyLoad_EagerLoad.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.BranchGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BranchGroups");
                });

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.BranchGroupMap", b =>
                {
                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("BranchGroupId")
                        .HasColumnType("int");

                    b.HasKey("BranchId", "BranchGroupId");

                    b.HasIndex("BranchGroupId");

                    b.ToTable("BranchGroupMaps");
                });

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.Factory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Factories");
                });

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.ProductFactoryMap", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("FactoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "FactoryId");

                    b.HasIndex("FactoryId")
                        .IsUnique();

                    b.ToTable("ProductFactoryMaps");
                });

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.ProductTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTags");
                });

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.ProductTagMap", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTagId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ProductTagId");

                    b.HasIndex("ProductTagId");

                    b.ToTable("ProductTagMaps");
                });

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.BranchGroupMap", b =>
                {
                    b.HasOne("Try_LazyLoad_EagerLoad.Models.BranchGroup", "BranchGroup")
                        .WithMany("BranchGroupMaps")
                        .HasForeignKey("BranchGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Try_LazyLoad_EagerLoad.Models.Branch", "Branch")
                        .WithMany("BranchGroupMaps")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.Factory", b =>
                {
                    b.HasOne("Try_LazyLoad_EagerLoad.Models.Branch", "Branch")
                        .WithMany("Factories")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.Product", b =>
                {
                    b.HasOne("Try_LazyLoad_EagerLoad.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId");
                });

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.ProductFactoryMap", b =>
                {
                    b.HasOne("Try_LazyLoad_EagerLoad.Models.Factory", "Factory")
                        .WithOne("ProductFactoryMaps")
                        .HasForeignKey("Try_LazyLoad_EagerLoad.Models.ProductFactoryMap", "FactoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Try_LazyLoad_EagerLoad.Models.Product", "Product")
                        .WithMany("ProductFactoryMaps")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Try_LazyLoad_EagerLoad.Models.ProductTagMap", b =>
                {
                    b.HasOne("Try_LazyLoad_EagerLoad.Models.Product", "Product")
                        .WithMany("ProductTagMaps")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Try_LazyLoad_EagerLoad.Models.ProductTag", "ProductTag")
                        .WithMany("ProductTagMaps")
                        .HasForeignKey("ProductTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
