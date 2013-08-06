using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTriggers.EFClasses
{
    [Table("Configuration")]
    public class Configuration : AuditableEntityBase
    {
        [Key]
        public Guid ConfigurationId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
