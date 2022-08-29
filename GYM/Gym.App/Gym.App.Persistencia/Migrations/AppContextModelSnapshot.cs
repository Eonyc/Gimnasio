﻿// <auto-generated />
using System;
using Gym.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gym.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Gym.App.Dominio.Credential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("Gym.App.Dominio.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("CredentialId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NutritionId")
                        .HasColumnType("int");

                    b.Property<int?>("RoutineId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrackingId")
                        .HasColumnType("int");

                    b.Property<int?>("ValueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CredentialId");

                    b.HasIndex("NutritionId");

                    b.HasIndex("RoutineId");

                    b.HasIndex("TrackingId");

                    b.HasIndex("ValueId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Gym.App.Dominio.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CaloriesConsumed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Repetitions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Series")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Gym.App.Dominio.Nutrition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Eat")
                        .HasColumnType("int");

                    b.Property<string>("Menu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Nutritions");
                });

            modelBuilder.Entity("Gym.App.Dominio.Routine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BodyPart")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("Intensity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Routines");
                });

            modelBuilder.Entity("Gym.App.Dominio.Tracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TrackingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Trackings");
                });

            modelBuilder.Entity("Gym.App.Dominio.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Recommendation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("Gym.App.Dominio.Customer", b =>
                {
                    b.HasOne("Gym.App.Dominio.Credential", "Credential")
                        .WithMany()
                        .HasForeignKey("CredentialId");

                    b.HasOne("Gym.App.Dominio.Nutrition", "Nutrition")
                        .WithMany()
                        .HasForeignKey("NutritionId");

                    b.HasOne("Gym.App.Dominio.Nutrition", "Routine")
                        .WithMany()
                        .HasForeignKey("RoutineId");

                    b.HasOne("Gym.App.Dominio.Tracking", "Tracking")
                        .WithMany()
                        .HasForeignKey("TrackingId");

                    b.HasOne("Gym.App.Dominio.Nutrition", "Value")
                        .WithMany()
                        .HasForeignKey("ValueId");

                    b.Navigation("Credential");

                    b.Navigation("Nutrition");

                    b.Navigation("Routine");

                    b.Navigation("Tracking");

                    b.Navigation("Value");
                });

            modelBuilder.Entity("Gym.App.Dominio.Routine", b =>
                {
                    b.HasOne("Gym.App.Dominio.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId");

                    b.Navigation("Exercise");
                });
#pragma warning restore 612, 618
        }
    }
}
