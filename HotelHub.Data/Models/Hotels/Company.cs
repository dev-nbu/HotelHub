using System.ComponentModel.DataAnnotations;

namespace HotelHub.Data.Models.Hotels {
    public class Company : AuditableEntity {
        public Guid Id { get; set; }

        [MaxLength(200)]
        public required string Name { get; set; }

        // ЕИК: 9 или 13 цифри
        [MaxLength(13)]
        public required string EIK { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(256)]
        public string? Email { get; set; }
    }
}
