using HotelHub.Data.Models.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelHub.Data.Configurations.Hotels {
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel> {
        public void Configure(EntityTypeBuilder<Hotel> e) {
            e.ToTable("Hotels", "hotel", t =>
                t.HasCheckConstraint("CK_Hotels_Stars", "[Stars] BETWEEN 1 AND 5"));
        }
    }
}
