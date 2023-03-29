﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TodoListGQL.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230329190631_Initial Migrations")]
    partial class InitialMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("ItemData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Done")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ListId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ItemList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("ItemData", b =>
                {
                    b.HasOne("ItemList", "ItemList")
                        .WithMany("ItemDatas")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_ItemData_ItemList");

                    b.Navigation("ItemList");
                });

            modelBuilder.Entity("ItemList", b =>
                {
                    b.Navigation("ItemDatas");
                });
#pragma warning restore 612, 618
        }
    }
}