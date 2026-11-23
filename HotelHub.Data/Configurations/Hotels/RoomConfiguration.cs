using HotelHub.Data.Models.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelHub.Data.Configurations.Hotels {
    public class RoomConfiguration : IEntityTypeConfiguration<Room> {
        public void Configure(EntityTypeBuilder<Room> e) {
            e.ToTable("Rooms", "hotel", t =>
                t.HasCheckConstraint("CK_Rooms_Capacity", "[Capacity] > 0"));
            e.HasIndex(x => new { x.HotelId, x.Number }).IsUnique();
            // цел на FK от Reservations
            e.HasAlternateKey(x => new { x.HotelId, x.Id });
            // хотелът трябва да предлага типа стая: (Hotel_ID, RoomType_ID) → HotelRoomTypes
            e.HasOne(x => x.HotelRoomType).WithMany()
                .HasForeignKey(x => new { x.HotelId, x.RoomTypeId })
                .HasPrincipalKey(x => new { x.HotelId, x.RoomTypeId });
        }
    }
}
