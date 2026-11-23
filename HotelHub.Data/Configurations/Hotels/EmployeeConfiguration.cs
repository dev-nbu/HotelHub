using HotelHub.Data.Models.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelHub.Data.Configurations.Hotels {
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee> {
        public void Configure(EntityTypeBuilder<Employee> e) {
            e.ToTable("Employees", "hotel", t =>
                t.HasCheckConstraint("CK_Employees_EndDate", "[EndDate] >= [HireDate]"));
            // цел на FK от Reservations
            e.HasAlternateKey(x => new { x.HotelId, x.Id });
            // един човек може да има няколко назначения, но само едно активно
            e.HasOne(x => x.Person).WithMany(p => p.Employments).HasForeignKey(x => x.PersonId);
            e.HasIndex(x => x.PersonId).IsUnique().HasFilter("[EndDate] IS NULL");
            // пълен индекс за историята на назначенията и FK проверката
            e.HasIndex(x => new { x.PersonId, x.EndDate });
        }
    }
}
