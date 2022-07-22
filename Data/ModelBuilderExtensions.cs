using System;
using BrianTech008Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using  Microsoft.AspNetCore.Identity;

namespace BrianTech008Api.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)

        {
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<Folder>()
              .HasData(
                new Folder { Id = 1, Name = "Tops", LastUpdatedBy = "BrianTech008", LastUpdatedOn = DateTime.UtcNow, PostedBy="BrianTech008", PostedOn=DateTime.UtcNow }

               );

            modelBuilder.Entity<IdentityRole>()
           .HasData(
             new IdentityRole
             {
                 Name = "Admin",
                 NormalizedName = "ADMIN",
             }

            );


            modelBuilder.Entity<IdentityRole>()
           .HasData(
             new IdentityRole
             {
                 Name = "Customer",
                 NormalizedName = "CUSTOMER",
             }

            );



            modelBuilder.Entity<User>()
                .HasData(
                new User { 
            UserName = "briantech008",
                    FirstName = "Brian",
                    LastName = "Tech008",
                    NormalizedUserName = "BRIANTECH",
            Email = "brriantech008@gmail.com",
            NormalizedEmail = "BRIANTECH008@GMAIL.COM",
          //  Role = "Admin",
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString(),
            PasswordHash = hasher.HashPassword(null, ""),
                    Gender = "male",
                });

           // modelBuilder.Entity<User>()
             //.HasData(
             //new User
             //{
                 //UserName = "admin",
                 //FirstName = "Admin",
                 //LastName = "User",
                 //NormalizedUserName = "Admin",
                 //Email = "admin@zuricosmetics.co.ke",
                 //NormalizedEmail = "ADMIN@ZURICOSMETICS.CO.KE",
                    // Role = "Admin",
                    //EmailConfirmed = true,
                 //LockoutEnabled = false,
                 //SecurityStamp = Guid.NewGuid().ToString(),
                 //PasswordHash = hasher.HashPassword(null, "Admin@zuric2022"),
                 //Gender = "female",
             //});


        }
    }
}
