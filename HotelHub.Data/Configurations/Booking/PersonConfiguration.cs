using HotelHub.Data.Models.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelHub.Data.Configurations.Booking {
    public class PersonConfiguration : IEntityTypeConfiguration<Person> {
        public void Configure(EntityTypeBuilder<Person> e) {
            e.ToTable("Persons", "booking", t =>
                t.HasCheckConstraint("CK_Persons_EGN", "LEN([EGN]) = 10 AND [EGN] NOT LIKE '%[^0-9]%'"));
            // nullable → филтриран UQ (WHERE EGN IS NOT NULL)
            e.HasIndex(x => x.EGN).IsUnique();
            // nullable → филтриран UQ (WHERE User_ID IS NOT NULL)
            // изтрит акаунт → персоната остава, User_ID става NULL
            e.HasOne(x => x.User).WithOne(u => u.Person)
                .HasForeignKey<Person>(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
