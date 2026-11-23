using HotelHub.Data.Models.Nomenclatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelHub.Data.Configurations.Nomenclatures {
    public class MealPlanConfiguration : IEntityTypeConfiguration<MealPlan> {
        public void Configure(EntityTypeBuilder<MealPlan> e) {
            e.ToTable("MealPlans", "nom");
            e.HasIndex(x => x.Name).IsUnique();
        }
    }
}
