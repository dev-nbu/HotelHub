using HotelHub.Data.Configurations;
using HotelHub.Data.Configurations.Auth;
using HotelHub.Data.Models;
using HotelHub.Data.Models.Auth;
using HotelHub.Data.Models.Booking;
using HotelHub.Data.Models.Hotels;
using HotelHub.Data.Models.Nomenclatures;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelHub.Data {
    // ICurrentUser е незадължителен: без него (seed, тестове) CreatedBy_ID / ModifiedBy_ID остават NULL
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUser? currentUser = null)
        : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options) {

        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<RoomType> RoomTypes => Set<RoomType>();
        public DbSet<MealPlan> MealPlans => Set<MealPlan>();
        public DbSet<HotelRoomType> HotelRoomTypes => Set<HotelRoomType>();
        public DbSet<HotelMealPlan> HotelMealPlans => Set<HotelMealPlan>();
        public DbSet<Room> Rooms => Set<Room>();
        public DbSet<Reservation> Reservations => Set<Reservation>();

        // ---------- audit: попълва се автоматично при всеки запис ----------
        public override int SaveChanges(bool acceptAllChangesOnSuccess) {
            ApplyAudit();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) {
            ApplyAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ApplyAudit() {
            var now = DateTime.UtcNow;
            var userId = currentUser?.UserId;
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>()) {
                if (entry.State == EntityState.Added) {
                    // ръчно зададените (напр. при импорт) се запазват
                    if (entry.Entity.CreatedAt == default) entry.Property(x => x.CreatedAt).CurrentValue = now;
                    if (entry.Entity.CreatedById == null) entry.Property(x => x.CreatedById).CurrentValue = userId;
                }
                else if (entry.State == EntityState.Modified) {
                    // през entry, за да се маркират като променени и без DetectChanges
                    entry.Property(x => x.ModifiedAt).CurrentValue = now;
                    entry.Property(x => x.ModifiedById).CurrentValue = userId;
                    // създаването никога не се презаписва
                    entry.Property(x => x.CreatedAt).IsModified = false;
                    entry.Property(x => x.CreatedById).IsModified = false;
                }
            }
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder) {
            // всички цени: decimal(10,2)
            builder.Properties<decimal>().HavePrecision(10, 2);

            // всички DateTime се пазят в UTC; при четене се маркират като UTC
            builder.Properties<DateTime>().HaveConversion<UtcDateTimeConverter>();
            builder.Properties<DateTime?>().HaveConversion<UtcDateTimeConverter>();
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            // Identity конфигурацията, задължително първо
            base.OnModelCreating(builder);

            // Identity таблиците в схема auth
            builder.ConfigureAuthSchema();

            // всички IEntityTypeConfiguration<T> от папка Configurations
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // нашите таблици: Restrict (не се трие запис, към който има връзки)
            // изрично зададеното с OnDelete (напр. SetNull за Person → User) не се пипа
            foreach (var fk in builder.Model.GetEntityTypes()
                         .Where(t => typeof(AuditableEntity).IsAssignableFrom(t.ClrType))
                         .SelectMany(t => t.GetForeignKeys())
                         .Where(fk => ((IConventionForeignKey)fk).GetDeleteBehaviorConfigurationSource() != ConfigurationSource.Explicit))
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            // последно, след цялата конфигурация
            builder.ApplyNamingConventions();
        }
    }
}
