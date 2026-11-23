using HotelHub.Data.Models.Auth;
using HotelHub.Data.Models.Hotels;
using System.ComponentModel.DataAnnotations;

namespace HotelHub.Data.Models.Booking {
    public class Person : AuditableEntity {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public required string FirstName { get; set; }

        [MaxLength(50)]
        public required string LastName { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(256)]
        public string? Email { get; set; }

        // NULL = човекът няма акаунт (напр. гост, записан от рецепцията)
        public Guid? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        // ЕГН е на човека, не на назначението; уникален, точно 10 цифри (CHECK в базата)
        [MaxLength(10)]
        public string? EGN { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = [];
        public ICollection<Employee> Employments { get; set; } = [];
    }
}
