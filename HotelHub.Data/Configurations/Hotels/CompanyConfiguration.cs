using HotelHub.Data.Models.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelHub.Data.Configurations.Hotels {
    public class CompanyConfiguration : IEntityTypeConfiguration<Company> {
        public void Configure(EntityTypeBuilder<Company> e) {
            e.ToTable("Companies", "hotel", t =>
                t.HasCheckConstraint("CK_Companies_EIK", "LEN([EIK]) IN (9, 13) AND [EIK] NOT LIKE '%[^0-9]%'"));
            e.HasIndex(x => x.EIK).IsUnique();
        }
    }
}
