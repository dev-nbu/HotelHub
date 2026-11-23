using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelHub.Data.Configurations {
    /// <summary>
    /// Колони: ID / Име_ID. Ограничения и индекси: PK_ / FK_ / UQ_ / CL_ / IX_ + таблица + колони.
    /// Важи за всички таблици, включително Identity.
    /// </summary>
    public static class NamingConventions {
        public static void ApplyNamingConventions(this ModelBuilder builder) {
            var entities = builder.Model.GetEntityTypes().ToList();

            // 1) колони: Id → ID; XxxId → Xxx_ID за ключове, FK и Guid (напр. CreatedById без FK)
            foreach (var p in entities.SelectMany(e => e.GetDeclaredProperties())) {
                var isGuid = p.ClrType == typeof(Guid) || p.ClrType == typeof(Guid?);
                if (p.Name == "Id")
                    p.SetColumnName("ID");
                else if (p.Name.EndsWith("Id", StringComparison.Ordinal) && (isGuid || p.IsKey() || p.IsForeignKey()))
                    p.SetColumnName(p.Name[..^2] + "_ID");
            }

            // 2) ограничения и индекси
            foreach (var entity in entities) {
                var table = entity.GetTableName()!;
                var store = StoreObjectIdentifier.Table(table, entity.GetSchema());
                string Cols(IEnumerable<IReadOnlyProperty> ps) =>
                    string.Join("_", ps.Select(p => p.GetColumnName(store)));

                foreach (var key in entity.GetDeclaredKeys())
                    key.SetName($"{(key.IsPrimaryKey() ? "PK" : "UQ")}_{table}_{Cols(key.Properties)}");

                foreach (var fk in entity.GetDeclaredForeignKeys()) {
                    var principal = fk.PrincipalEntityType;
                    var pTable = principal.GetTableName()!;
                    var pStore = StoreObjectIdentifier.Table(pTable, principal.GetSchema());
                    var pCols = string.Join("_", fk.PrincipalKey.Properties.Select(p => p.GetColumnName(pStore)));
                    fk.SetConstraintName($"FK_{table}_{Cols(fk.Properties)}_{pTable}_{pCols}");
                }

                foreach (var ix in entity.GetDeclaredIndexes()) {
                    var prefix = ix.IsClustered() == true ? "CL" : ix.IsUnique ? "UQ" : "IX";
                    ix.SetDatabaseName($"{prefix}_{table}_{Cols(ix.Properties)}");
                }
            }
        }
    }
}
