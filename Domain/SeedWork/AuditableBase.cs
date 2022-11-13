using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SeedWork
{
    public abstract class AuditableBase
    {
        public string? CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTimeOffset? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
