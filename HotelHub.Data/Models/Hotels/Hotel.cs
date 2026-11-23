using System.ComponentModel.DataAnnotations;

namespace HotelHub.Data.Models.Hotels {
    public class Hotel : AuditableEntity {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(100)]
        public required string City { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        // 1–5, CHECK в базата
        public int? Stars { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }
    }
}
