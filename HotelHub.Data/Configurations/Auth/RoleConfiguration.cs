using HotelHub.Data.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelHub.Data.Configurations.Auth
{
    // ролите влизат в базата с миграция (HasData)
    // всички стойности са константи, иначе всеки Add-Migration ще вижда "промяна"
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(
                Role("60c9d73b-b9c6-4453-8c2f-d25d5c5600fe", Roles.Admin),
                Role("3f4d177f-147d-4787-8a83-d3c471aea4a8", Roles.Receptionist),
                Role("e5f11cde-1422-44b5-a281-9541a23ae14d", Roles.Guest));
        }

        private static IdentityRole<Guid> Role(string id, string name) => new()
        {
            Id = Guid.Parse(id),
            Name = name,
            NormalizedName = name.ToUpperInvariant(),
            ConcurrencyStamp = id // фиксиран, за да не се генерира нов при всяка миграция
        };
    }
}