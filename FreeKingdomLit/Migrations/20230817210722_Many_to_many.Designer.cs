﻿// <auto-generated />
using FreeKingdomLit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FreeKingdomLit.Migrations
{
    [DbContext(typeof(FreeKingdomLitContext))]
    [Migration("20230817210722_Many_to_many")]
    partial class Many_to_many
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FreeKingdomLit.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("FreeKingdomLit.Models.BookGenre", b =>
                {
                    b.Property<int>("BookGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("BookGenreId");

                    b.HasIndex("BookId");

                    b.HasIndex("GenreId");

                    b.ToTable("BooksGenres");
                });

            modelBuilder.Entity("FreeKingdomLit.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("FreeKingdomLit.Models.BookGenre", b =>
                {
                    b.HasOne("FreeKingdomLit.Models.Book", "Book")
                        .WithMany("JoinEntities")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FreeKingdomLit.Models.Genre", "Genre")
                        .WithMany("JoinEntities")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("FreeKingdomLit.Models.Book", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("FreeKingdomLit.Models.Genre", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
