using HotelHub.Data.Models.Nomenclatures;

namespace HotelHub.Data.Models.Hotels {
    public class HotelRoomType : AuditableEntity {
        public Guid Id { get; set; }

        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;

        public Guid RoomTypeId { get; set; }
        public RoomType RoomType { get; set; } = null!;

        public decimal PricePerNight { get; set; }
    }
}
