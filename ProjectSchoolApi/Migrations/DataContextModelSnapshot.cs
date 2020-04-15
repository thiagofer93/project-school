﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectSchoolApi.Data;

namespace ProjectSchoolApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("ProjectSchoolApi.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataNasc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNasc = "31/07/1980",
                            Nome = "Harry",
                            ProfessorId = 1,
                            Sobrenome = "Potter"
                        },
                        new
                        {
                            Id = 2,
                            DataNasc = "01/03/1980",
                            Nome = "Rony",
                            ProfessorId = 1,
                            Sobrenome = "Weasley"
                        },
                        new
                        {
                            Id = 3,
                            DataNasc = "19/07/1979",
                            Nome = "Hermione",
                            ProfessorId = 1,
                            Sobrenome = "Granger"
                        });
                });

            modelBuilder.Entity("ProjectSchoolApi.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Dumbledore"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Snape"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Minerva"
                        });
                });

            modelBuilder.Entity("ProjectSchoolApi.Models.Aluno", b =>
                {
                    b.HasOne("ProjectSchoolApi.Models.Professor", "Professor")
                        .WithMany("Alunos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
