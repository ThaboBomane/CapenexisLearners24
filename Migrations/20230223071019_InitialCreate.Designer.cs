﻿// <auto-generated />
using CapenexisLeaners24.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CapenexisLeaners24.Migrations
{
    [DbContext(typeof(CapenexisLeaners24Context))]
    [Migration("20230223071019_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CapenexisLearners24.Models.Courses", b =>
                {
                    b.Property<int>("CoursesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoursesId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacillitatorId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CapenexisLearners24.Models.Facilitators", b =>
                {
                    b.Property<int>("FacilitatorsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacilitatorsId"));

                    b.Property<string>("FacilitatorsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacilitatorsSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacilitatorsId");

                    b.ToTable("Facilitators");
                });

            modelBuilder.Entity("CapenexisLearners24.Models.Learners", b =>
                {
                    b.Property<long>("LearnersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("LearnersId"));

                    b.Property<long>("LearnersIdentityNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("LearnersName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LearnersSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LearnersId");

                    b.ToTable("Learners");
                });
#pragma warning restore 612, 618
        }
    }
}
