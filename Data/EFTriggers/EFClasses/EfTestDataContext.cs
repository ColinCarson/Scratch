using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EFTriggers.EFClasses
{
    public class EfTestDataContext : DbContext
    {
        private const string schemaPrefix = "EFTest";

        public EfTestDataContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer<EfTestDataContext>(null);
        }

        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Configuration> Configurations { get; set; }


        public override int SaveChanges()
        {

            foreach(var entity in this.ChangeTracker.Entries().Where(p => p.State == System.Data.EntityState.Added ||
                                                                          p.State == System.Data.EntityState.Deleted ||
                                                                          p.State == System.Data.EntityState.Modified))
            {
                foreach(var auditEntry in GetAuditRecordsForChange(entity))
                {
                    this.AuditLogs.Add(auditEntry);
                }
            }

            return base.SaveChanges();
        }

        private IEnumerable<AuditLog> GetAuditRecordsForChange(DbEntityEntry dbEntityEntry)
        {
            List<AuditLog> auditLogs = new List<AuditLog>();

            // get table attribute
            var tableAttribute = dbEntityEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;
            var tableName = tableAttribute != null ? tableAttribute.Name : dbEntityEntry.Entity.GetType().Name;
            var keyName = dbEntityEntry.Entity.GetType().GetProperties().Single(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0).Name;


            if (dbEntityEntry.State == System.Data.EntityState.Added)
            {
                auditLogs.Add(new AuditLog
                {
                    Id = Guid.NewGuid(),
                    UserName = System.Environment.UserName,
                    EventDateUTC = DateTime.Now.ToUniversalTime(),
                    EventType = "Added",
                    TableName = tableName,
                    ObjectID = dbEntityEntry.CurrentValues.GetValue<object>(keyName).ToString(),
                    ColumnName = "ALL",
                    NewValue = "banana"
                });
            }

            else if (dbEntityEntry.State == System.Data.EntityState.Deleted)
            {
                auditLogs.Add(new AuditLog
                {
                    Id = Guid.NewGuid(),
                    UserName = System.Environment.UserName,
                    EventDateUTC = DateTime.Now.ToUniversalTime(),
                    EventType = "Deleted",
                    TableName = tableName,
                    ObjectID = dbEntityEntry.CurrentValues.GetValue<object>(keyName).ToString(),
                    ColumnName = "ALL",
                    NewValue = "banana"
                });
            }

            else if (dbEntityEntry.State == System.Data.EntityState.Modified)
            {
                auditLogs.Add(new AuditLog
                {
                    Id = Guid.NewGuid(),
                    UserName = System.Environment.UserName,
                    EventDateUTC = DateTime.Now.ToUniversalTime(),
                    EventType = "Modified",
                    TableName = tableName,
                    ObjectID = dbEntityEntry.CurrentValues.GetValue<object>(keyName).ToString(),
                    ColumnName = "ALL",
                    NewValue = "banana"
                });
            }

            return auditLogs;
        }
    }
}
