using Domain.SeedWork;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Step : AuditableBase
    {
        [Key]
        public Guid idStep { get; set; } = Guid.NewGuid();
        public int nstep { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Guid idRecipe { get; set; }

        [ForeignKey("idRecipe")]
        public Recipe recipe { get; set; }
    }
}