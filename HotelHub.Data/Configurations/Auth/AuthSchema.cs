using HotelHub.Data.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelHub.Data.Configurations.Auth {
    public static class AuthSchema {
        // Identity таблиците са от NuGet пакета, затова тук е само схемата
        public static void ConfigureAuthSchema(this ModelBuilder builder) {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers", "auth");
            builder.Entity<IdentityRole<Guid>>().ToTable("AspNetRoles", "auth");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AspNetUserRoles", "auth");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AspNetUserClaims", "auth");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AspNetRoleClaims", "auth");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AspNetUserLogins", "auth");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AspNetUserTokens", "auth");
        }
    }
}
