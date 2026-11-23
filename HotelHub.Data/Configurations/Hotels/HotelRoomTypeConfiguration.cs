using HotelHub.Data.Models.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelHub.Data.Configurations.Hotels {
    public class HotelRoomTypeConfiguration : IEntityTypeConfiguration<HotelRoomType> {
        public void Configure(EntityTypeBuilder<HotelRoomType> e) {
            e.ToTable("HotelRoomTypes", "hotel", t =>
                t.HasCheckConstraint("CK_HotelRoomTypes_PricePerNight", "[PricePerNight] >= 0"));
            // UQ (Hotel_ID, RoomType_ID): една цена на тип стая в хотел; и цел на FK от Rooms
            e.HasAlternateKey(x => new { x.HotelId, x.RoomTypeId });
        }
    }
}
