namespace HotelHub.Data.Models {
    /// <summary>
    /// Audit полета за всички наши таблици (без Identity). Попълват се автоматично в ApplicationDbContext.SaveChanges.
    /// </summary>
    public abstract class AuditableEntity {
        // UTC
        public DateTime CreatedAt { get; set; }

        // без FK → колона CreatedBy_ID
        public Guid? CreatedById { get; set; }

        // UTC
        public DateTime? ModifiedAt { get; set; }

        // без FK → колона ModifiedBy_ID
        public Guid? ModifiedById { get; set; }
    }
}
