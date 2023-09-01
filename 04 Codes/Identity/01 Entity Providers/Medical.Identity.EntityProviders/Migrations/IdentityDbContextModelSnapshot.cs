﻿// <auto-generated />
using System;
using Medical.Identity.EntityProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Medical.Identity.EntityProviders.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    partial class IdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Medical.Identity.EntityProviders.Department", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = "670e499b-acfa-4f32-993b-ab3fdee89b89",
                            CreatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1146),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1149),
                            Name = "Human Resource"
                        },
                        new
                        {
                            Id = "23a437d1-4b44-48c9-b1fc-c6fd9a3b4b6b",
                            CreatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1188),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1188),
                            Name = "IT"
                        },
                        new
                        {
                            Id = "a36e0fab-ad4b-4e2f-822e-bcb26d4f1fdd",
                            CreatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1190),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1191),
                            Name = "Sales"
                        });
                });

            modelBuilder.Entity("Medical.Identity.EntityProviders.RefreshToken", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IssuedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("JwtId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Medical.Identity.EntityProviders.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = "3b5041b2-bfcf-410f-84a5-d7a0adf00f2b",
                            CreatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1320),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1320),
                            Name = "Staff"
                        },
                        new
                        {
                            Id = "ac8afc3a-5eb5-4055-8834-aa0df5c3ff6f",
                            CreatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1323),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1323),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = "c8c863d5-7778-48fd-9880-7b8e19c40dfe",
                            CreatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1325),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1325),
                            Name = "Manager"
                        },
                        new
                        {
                            Id = "8c4efc0f-ac86-48e7-b16e-b57721814272",
                            CreatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1340),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1340),
                            Name = "Doctor"
                        },
                        new
                        {
                            Id = "99cad2ed-a60f-43cf-b817-ea07cefe5dd8",
                            CreatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1342),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1343),
                            Name = "Nurse"
                        },
                        new
                        {
                            Id = "1110ec51-b084-4638-b170-5a49fdedd33c",
                            CreatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1345),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 1, 7, 24, 17, 433, DateTimeKind.Utc).AddTicks(1345),
                            Name = "Pharmacist"
                        });
                });

            modelBuilder.Entity("Medical.Identity.EntityProviders.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Medical.Identity.EntityProviders.UserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.HasIndex("RoleId", "UserId", "DepartmentId")
                        .IsUnique();

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Medical.Identity.EntityProviders.RefreshToken", b =>
                {
                    b.HasOne("Medical.Identity.EntityProviders.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Medical.Identity.EntityProviders.UserRole", b =>
                {
                    b.HasOne("Medical.Identity.EntityProviders.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medical.Identity.EntityProviders.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medical.Identity.EntityProviders.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Role");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
