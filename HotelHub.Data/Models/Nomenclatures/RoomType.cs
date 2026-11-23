using System.ComponentModel.DataAnnotations;

namespace HotelHub.Data.Models.Nomenclatures {
    public class RoomType : AuditableEntity {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }
    }
}
