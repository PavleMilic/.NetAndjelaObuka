
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using WebApplication1.models;
using WebApplication1.Services;

namespace WebApplication1.Data;


public class UserDbContext : DbContext
{
    private readonly IPasswordHasher _passwordHasher;
    public UserDbContext(DbContextOptions<UserDbContext> options, IPasswordHasher passwordHasher) : base(options) {
        _passwordHasher = passwordHasher;
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //=> optionsBuilder.UseLazyLoadingProxies();

    public DbSet<User> Users { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Permission> Permission { get; set; }
    public DbSet<RolePermission> RolePermission { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var salt1 = _passwordHasher.GenerateSalt();
        var hash1 = _passwordHasher.Hash("94", salt1);

        var salt2 = _passwordHasher.GenerateSalt();
        var hash2 = _passwordHasher.Hash("98", salt2);

        var salt3 = _passwordHasher.GenerateSalt();
        var hash3 = _passwordHasher.Hash("89", salt3);


        modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                FirstName = "Pavle",
                LastName = "Milic",
                Email = "pavle.milic@gmail.com",
                Age = 30,
                Jmbg = 1111,
                CityId = 1,
                UserName = "Pavle94",
                PasswordHash = hash1,
                Salt = salt1
            },
             new User()
             {
                 Id = 2,
                 FirstName = "Andjela",
                 LastName = "Filipovic",
                 Email = "andjela.filipovic@gmail.com",
                 Age = 26,
                 Jmbg = 2222,
                 CityId = 2,
                 UserName = "Andjela98",
                 PasswordHash = hash2,
                 Salt = salt2
             },
              new User()
              {
                  Id = 3,
                  FirstName = "Tanja",
                  LastName = "Dejkovic",
                  Email = "tanja.dejkovic@gmail.com",
                  Age = 34,
                  Jmbg = 3333,
                  CityId = 1,
                  UserName = "Tanja89",
                  PasswordHash = hash3,
                  Salt = salt3
              }
            );

        modelBuilder.Entity<City>().HasData(
            new City()
            {
                Id = 1,
                CityName = "Belgrade",
                CityState = "Serbia"

            },
            new City()
            {
                Id = 2,
                CityName = "Paris",
                CityState = "France"

            },
            new City()
            {
                Id = 3,
                CityName = "London",
                CityState = "England"

            }
            );
        modelBuilder.Entity<Role>().HasData(
            new Role()
            {
                RoleId = 1,
                RoleName = "Admin"
            },
           new Role()
            {
               RoleId = 2,
                RoleName = "Moderator"
            },
           new Role()
            {
                RoleId = 3,
                RoleName = "User"
            }
            );
        modelBuilder.Entity<Permission>().HasData(

            new Permission()
            {
                PermissionId = 1,
                PermissionName = "CreateContent"

            },
            new Permission()
            {
                PermissionId = 2,
                PermissionName = "UpdateContent"

            },
            new Permission()
            {
                PermissionId = 3,
                PermissionName = "DeleteContent"

            }

        );
        modelBuilder.Entity<UserRole>().HasData(

            new UserRole()
            {
                UserId = 1,
                RoleId = 1

            },
            new UserRole()
            {
                UserId = 2,
                RoleId = 2

            },
            new UserRole()
            {
                UserId = 3,
                RoleId = 3

            }

            );
        modelBuilder.Entity<RolePermission>().HasData(
            new RolePermission()
            {
                RoleId = 1,
                PermissionId = 1

            },
            new RolePermission()
            {
                RoleId = 2,
                PermissionId = 2

            },
            new RolePermission()
            {
                 RoleId = 3,
                 PermissionId = 3

            }
            );


        modelBuilder.Entity<User>()
           .HasOne(u => u.City)
           .WithMany(c => c.Users)
           .HasForeignKey(u => u.CityId);

        modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new { rp.RoleId, rp.PermissionId }); // definisanje many to many izmedju Role i Permission

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions)
            .HasForeignKey(rp => rp.RoleId);

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId);


        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId }); //many to many izmedju User i Role // slozeni primarni kljuc

        modelBuilder.Entity<UserRole>()
           .HasOne(ur => ur.User)
           .WithMany(u => u.UserRoles)
           .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
    }

}



