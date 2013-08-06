using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTriggers.EFClasses
{
    [Table("AuditLog")]
    public class AuditLog
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public DateTime EventDateUTC { get; set; }
        [Required]
        public string EventType { get; set; }
        [Required]
        public string TableName { get; set; }
        [Required]
        public string ObjectID { get; set; }
        [Required]
        public string ColumnName { get; set; }
        public string OriginalValue { get; set; }
        public string NewValue { get; set; }
    }
}
