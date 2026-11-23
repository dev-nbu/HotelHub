using HotelHub.Data.Models.Nomenclatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelHub.Data.Configurations.Nomenclatures {
    public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType> {
        public void Configure(EntityTypeBuilder<RoomType> e) {
            e.ToTable("RoomTypes", "nom");
            e.HasIndex(x => x.Name).IsUnique();
        }
    }
}
