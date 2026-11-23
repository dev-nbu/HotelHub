using HotelHub.Data.Models.Hotels;

namespace HotelHub.Data.Models.Booking {
    public class Reservation : AuditableEntity {
        public Guid Id { get; set; }

        // хотелът на резервацията: стаята и изхранването трябва да са от него
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;

        public Guid GuestId { get; set; }
        public Person Guest { get; set; } = null!;

        public Guid RoomId { get; set; }
        public Room Room { get; set; } = null!;

        public Guid HotelMealPlanId { get; set; }
        public HotelMealPlan HotelMealPlan { get; set; } = null!;

        // кой служител я е създал; NULL = гостът сам онлайн
        public Guid? CreatedByEmployeeId { get; set; }
        public Employee? CreatedByEmployee { get; set; }

        public DateOnly CheckIn { get; set; }

        public DateOnly CheckOut { get; set; }

        public int AdultsCount { get; set; }

        public int ChildrenCount { get; set; }

        // записва се при създаване, за да не се променя при смяна на тарифите
        public decimal TotalPrice { get; set; }

        public ReservationStatus Status { get; set; }
    }
}
