using Identity.Models;
using Infrastructure.Hasher;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher();

            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "080b76ff-eef2-4960-877e-72bd520523ad",
                     Email="naumanzahid63@gmail.com",
                     NormalizedEmail="NAUMANZAHID63@GMAIL.COM",
                     FirstName="Muhammad",
                     LastName="Nauman",
                     UserName="Admin101",
                     NormalizedUserName="ADMIN101",
                     PasswordHash= hasher.HashPassword("Nauman@1"),
                     EmailConfirmed=true
                 },
                 new ApplicationUser
                 {
                     Id = "16212ab6-1ef1-435c-916d-f2b75c79ae3b",
                     Email = "naumanzahid99@gmail.com",
                     NormalizedEmail = "NAUMANZAHID699@GMAIL.COM",
                     FirstName = "Muhammad",
                     LastName = "Azam",
                     UserName = "USER101",
                     NormalizedUserName = "USER101",
                     PasswordHash = hasher.HashPassword("Nauman@1"),
                     EmailConfirmed = true
                 }
             );
        }
    }
}
