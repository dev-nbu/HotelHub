using System.ComponentModel.DataAnnotations;

namespace HotelHub.Data.Models.Hotels {
    public class Room : AuditableEntity {
        public Guid Id { get; set; }

        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;

        // (HotelId, RoomTypeId) сочи към HotelRoomTypes: хотелът трябва да предлага този тип стая
        public Guid RoomTypeId { get; set; }
        public HotelRoomType HotelRoomType { get; set; } = null!;

        [MaxLength(10)]
        public required string Number { get; set; }

        public int Capacity { get; set; }
    }
}
