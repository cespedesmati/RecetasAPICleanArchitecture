using Domain.SeedWork;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Unit : AuditableBase
    {
        [Key]
        public Guid idUnit { get; set; }
        public string description { get; set; }
    }
}