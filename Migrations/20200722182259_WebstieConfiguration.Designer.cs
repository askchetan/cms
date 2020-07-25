﻿// <auto-generated />
using CMS.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMS.Migrations
{
    [DbContext(typeof(CMSDbContext))]
    [Migration("20200722182259_WebstieConfiguration")]
    partial class WebstieConfiguration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("CMS.DataAccess.Page", b =>
                {
                    b.Property<int>("PageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BottomMenu")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TopMenu")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("PageId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("CMS.DataAccess.PageSEO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("MetaTag")
                        .HasColumnType("TEXT");

                    b.Property<int>("PageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PageId")
                        .IsUnique();

                    b.ToTable("PageSEOs");
                });

            modelBuilder.Entity("CMS.DataAccess.Paragraph", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Details")
                        .HasColumnType("TEXT");

                    b.Property<int>("PageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("Paragraph");
                });

            modelBuilder.Entity("CMS.DataAccess.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("DetailUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CMS.DataAccess.WebsiteConfiguration", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("Key");

                    b.ToTable("websiteConfigurations");
                });

            modelBuilder.Entity("CMS.DataAccess.PageSEO", b =>
                {
                    b.HasOne("CMS.DataAccess.Page", "Page")
                        .WithOne("PageSEO")
                        .HasForeignKey("CMS.DataAccess.PageSEO", "PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CMS.DataAccess.Paragraph", b =>
                {
                    b.HasOne("CMS.DataAccess.Page", "Page")
                        .WithMany("Paragraphs")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}