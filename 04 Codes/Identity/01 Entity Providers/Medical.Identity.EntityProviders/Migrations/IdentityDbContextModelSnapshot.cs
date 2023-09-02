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
                            Id = "7b281cf4-4ecb-4551-82f0-3981d6f3a0c4",
                            CreatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2437),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2439),
                            Name = "IT"
                        },
                        new
                        {
                            Id = "956a9aaf-cfd0-481b-a006-81569c33f303",
                            CreatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2443),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2443),
                            Name = "Sales"
                        },
                        new
                        {
                            Id = "fc47cfe0-42ef-4e6c-bcdd-3ee73322a4ae",
                            CreatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2445),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2445),
                            Name = "HR"
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
                            Id = "15a61590-2b36-4157-b46a-e72122cae6d7",
                            CreatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2584),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2584),
                            Name = "Staff"
                        },
                        new
                        {
                            Id = "1421c41b-eabc-4dbd-a270-dcdd0e3413b0",
                            CreatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2587),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2587),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = "db266e1f-71b9-4b55-8e6c-dcd9e3033651",
                            CreatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2589),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2589),
                            Name = "Manager"
                        },
                        new
                        {
                            Id = "bdb25065-340d-44fa-9e13-cc1b587a3c3a",
                            CreatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2591),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2591),
                            Name = "Doctor"
                        },
                        new
                        {
                            Id = "0eedf519-d163-480e-9903-d63f4fe87471",
                            CreatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2601),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2601),
                            Name = "Nurse"
                        },
                        new
                        {
                            Id = "f540a20e-35da-4b57-bc74-72b48ac89767",
                            CreatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2603),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2603),
                            Name = "Pharmacist"
                        },
                        new
                        {
                            Id = "22cd9bb1-e8fd-4d19-b7b5-e5b9f8765a94",
                            CreatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2605),
                            IsDeleted = false,
                            LastUpdatedAt = new DateTime(2023, 9, 2, 12, 34, 26, 945, DateTimeKind.Utc).AddTicks(2606),
                            Name = "Director"
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
