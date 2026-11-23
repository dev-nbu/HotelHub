using HotelHub.Data.Models.Nomenclatures;

namespace HotelHub.Data.Models.Hotels {
    public class HotelMealPlan : AuditableEntity {
        public Guid Id { get; set; }

        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;

        public Guid MealPlanId { get; set; }
        public MealPlan MealPlan { get; set; } = null!;

        public decimal AdultPrice { get; set; }

        public decimal ChildPrice { get; set; }
    }
}
