using HotelHub.Data.Models.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelHub.Data.Configurations.Booking {
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation> {
        public void Configure(EntityTypeBuilder<Reservation> e) {
            e.ToTable("Reservations", "booking", t => {
                t.HasCheckConstraint("CK_Reservations_CheckOut", "[CheckOut] > [CheckIn]");
                t.HasCheckConstraint("CK_Reservations_AdultsCount", "[AdultsCount] >= 1");
                t.HasCheckConstraint("CK_Reservations_ChildrenCount", "[ChildrenCount] >= 0");
                t.HasCheckConstraint("CK_Reservations_TotalPrice", "[TotalPrice] >= 0");
            });
            e.Property(x => x.Status).HasConversion<string>().HasMaxLength(20);
            e.HasOne(x => x.Guest).WithMany(p => p.Reservations).HasForeignKey(x => x.GuestId);
            // стаята, изхранването и служителят трябва да са от хотела на резервацията
            e.HasOne(x => x.Room).WithMany()
                .HasForeignKey(x => new { x.HotelId, x.RoomId })
                .HasPrincipalKey(x => new { x.HotelId, x.Id });
            e.HasOne(x => x.HotelMealPlan).WithMany()
                .HasForeignKey(x => new { x.HotelId, x.HotelMealPlanId })
                .HasPrincipalKey(x => new { x.HotelId, x.Id });
            e.HasOne(x => x.CreatedByEmployee).WithMany()
                .HasForeignKey(x => new { x.HotelId, x.CreatedByEmployeeId })
                .HasPrincipalKey(x => new { x.HotelId, x.Id });
        }
    }
}
