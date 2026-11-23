using HotelHub.Data.Models.Booking;
using System.ComponentModel.DataAnnotations;

namespace HotelHub.Data.Models.Hotels {
    public class Employee : AuditableEntity {
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }
        public Person Person { get; set; } = null!;

        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;

        [MaxLength(50)]
        public required string Position { get; set; }

        public DateOnly HireDate { get; set; }

        // NULL = работи в момента; при преместване старият запис се затваря и се прави нов
        public DateOnly? EndDate { get; set; }
    }
}
