using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTriggers.EFClasses
{
    public abstract class AuditableEntityBase
    {
        [Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
