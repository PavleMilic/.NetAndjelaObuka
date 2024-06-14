﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20240613113733_HashedPassword")]
    partial class HashedPassword
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CityState")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityName = "Belgrade",
                            CityState = "Serbia"
                        },
                        new
                        {
                            Id = 2,
                            CityName = "Paris",
                            CityState = "France"
                        },
                        new
                        {
                            Id = 3,
                            CityName = "London",
                            CityState = "England"
                        });
                });

            modelBuilder.Entity("WebApplication1.models.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PermissionId"));

                    b.Property<string>("PermissionName")
                        .HasColumnType("text");

                    b.HasKey("PermissionId");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            PermissionName = "CreateContent"
                        },
                        new
                        {
                            PermissionId = 2,
                            PermissionName = "UpdateContent"
                        },
                        new
                        {
                            PermissionId = 3,
                            PermissionName = "DeleteContent"
                        });
                });

            modelBuilder.Entity("WebApplication1.models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "Moderator"
                        },
                        new
                        {
                            RoleId = 3,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("WebApplication1.models.RolePermission", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermission");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            PermissionId = 1
                        },
                        new
                        {
                            RoleId = 2,
                            PermissionId = 2
                        },
                        new
                        {
                            RoleId = 3,
                            PermissionId = 3
                        });
                });

            modelBuilder.Entity("WebApplication1.models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Jmbg")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 30,
                            CityId = 1,
                            Email = "pavle.milic@gmail.com",
                            FirstName = "Pavle",
                            Jmbg = 1111,
                            LastName = "Milic",
                            PasswordHash = "i1ZqWU2NUMJpoG0pq3odBw==;gMinZia879x5TxE7qARbgftxLEfLsllxqcUu9wgMsiY=",
                            Salt = "pppp",
                            UserName = "Pavle94"
                        },
                        new
                        {
                            Id = 2,
                            Age = 26,
                            CityId = 2,
                            Email = "andjela.filipovic@gmail.com",
                            FirstName = "Andjela",
                            Jmbg = 2222,
                            LastName = "Filipovic",
                            PasswordHash = "hLxhu7EKlfq098pZNa9bRg==;EQrOJyyIFIwhI169AOpbPa/MPYr5T+szfapRWmfMK2o=",
                            Salt = "aaaa",
                            UserName = "Andjela98"
                        },
                        new
                        {
                            Id = 3,
                            Age = 34,
                            CityId = 1,
                            Email = "tanja.dejkovic@gmail.com",
                            FirstName = "Tanja",
                            Jmbg = 3333,
                            LastName = "Dejkovic",
                            PasswordHash = "2iCAh6hWPCM5JOs2teLalQ==;fOf0Kz4TBTjJMpMKyDrO0A8rqoNXkY+mGqsF3fur1DY=",
                            Salt = "tttt",
                            UserName = "Tanja89"
                        });
                });

            modelBuilder.Entity("WebApplication1.models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("WebApplication1.models.RolePermission", b =>
                {
                    b.HasOne("WebApplication1.models.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebApplication1.models.User", b =>
                {
                    b.HasOne("WebApplication1.models.City", "City")
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("WebApplication1.models.UserRole", b =>
                {
                    b.HasOne("WebApplication1.models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication1.models.City", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebApplication1.models.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("WebApplication1.models.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("WebApplication1.models.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
