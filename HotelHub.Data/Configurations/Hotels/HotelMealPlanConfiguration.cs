using HotelHub.Data.Models.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelHub.Data.Configurations.Hotels {
    public class HotelMealPlanConfiguration : IEntityTypeConfiguration<HotelMealPlan> {
        public void Configure(EntityTypeBuilder<HotelMealPlan> e) {
            e.ToTable("HotelMealPlans", "hotel", t => {
                t.HasCheckConstraint("CK_HotelMealPlans_AdultPrice", "[AdultPrice] >= 0");
                t.HasCheckConstraint("CK_HotelMealPlans_ChildPrice", "[ChildPrice] >= 0");
            });
            e.HasIndex(x => new { x.HotelId, x.MealPlanId }).IsUnique();
            // цел на FK от Reservations
            e.HasAlternateKey(x => new { x.HotelId, x.Id });
        }
    }
}
