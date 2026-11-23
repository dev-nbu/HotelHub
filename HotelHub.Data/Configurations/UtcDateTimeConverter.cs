using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelHub.Data.Configurations {
    // при запис: Local се превръща в UTC, иначе се приема за UTC (без местене на часа)
    // при четене: маркира се като UTC (SQL Server не пази Kind)
    public class UtcDateTimeConverter() : ValueConverter<DateTime, DateTime>(
        v => v.Kind == DateTimeKind.Local ? v.ToUniversalTime() : DateTime.SpecifyKind(v, DateTimeKind.Utc),
        v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
}
